# Demonstration of resampling statistics for paired observations

# This begins with a standard t test on paired differences.
# Then we see one way to use a randomization test to do the same thing
# without worrying overmuch about the shape of the distribution.
# Then we see a very elegant way to accomplish nearly the same thing, but the
# R code is far from transparent.

# We are using a data file where the means are roughly equal--The moon illusion
# with eyes elevated and eyes level. I have added some observations so that the sampling
# distribution of the differences is not close to normal.

datafile <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/MoonEyes.dat", header = TRUE)
attach(datafile)
cat("The names of the variables are ",names(datafile), "\n")
diff <- Elevated - Level
sample.mean <- mean(diff)
cat("The sample mean differences is ", sample.mean, "\n")
# Plot a histogram of the differences
hist(diff)
xv <- seq(-3,3,.01)
yv <- dnorm(xv)
par (new = TRUE)
plot(xv, yv, type = "l", col = "blue", xlim = c(-2.5, 0.5), xlab = "", yaxt = "n", ylab = "")

# First we will run a standard t test

t.result <- t.test(Elevated, Level, paired = TRUE, conf.level = .95)
print(t.result)
cat("The t-test gives a probability under the null of ",t.result$p.value,"\n\n")

# Now to continue
nreps <- 2^14          # Normally I would use 10,000, but I want the number of samples here to
                       # match the number of possible permutations
means.random <- numeric(nreps)     # Set to hold all obtained means




####################################################################################
# There are two ways to run a randomization (permutation) test. When there are a great many 
# possible arrangements of the data, it is easiest to take a (very large) random sample of them
# and then assume that this set is a good reflection of what you would have if you took all 
# possible sets. That is the common approach.

# The other way is to actually calculate all possible permutations, using each one once. I would
# call that a "permutation" test. It is exact. This turns out to be a lot simpler, at least in this
# case, than you might think.

# We will use both approaches.

# Now we will randomly assign the sign of the difference
unsigned.diff <- abs(diff)
n <- length(unsigned.diff)
for (i in 1:nreps) {
  signs <- sample(c(1, -1), size = n, replace = TRUE)  # Draw 14 obs randomly from 1, -1
  signed.diff <- unsigned.diff*signs
  means.random[i] <- mean(signed.diff)       # Calculate the mean with that arrangement of signs
}

# The question is what percentage of those differences are greater than or equal to
# plus or minus sample.mean
percent.above <- length(means.random[means.random >= abs(sample.mean)])/nreps
percent.below <- length(means.random[means.random <= abs(sample.mean)*(-1)])/nreps
percent.extreme <- percent.above + percent.below

cat("The randomization test gives a probability under the null of", percent.extreme, "\n\n")


####################################################################################
# Now we will do things a bit differently by taking all possible permutations of the
# signs rather than just a very large random sample of them. There are 2^14 = 16,384 of them. 
# This leads to a truly exact test.

# The code looks formidable, but type ?expand.grid to see what that does, and then
# submit the messy stuff a section at a time. You can see what is happening by printing out each
# result as it is calculated.

unsigned.Diff <- abs(diff)      # Convert the differences to positive values
                                # We already had this, but this makes the section stand alone

aa <- as.data.frame(matrix(rep(c(-1,1),14), nr =2))
permutations <- as.matrix(expand.grid(aa))
head(permutations)              # Notice how the rows change as you go down

# By matrix multiplication you can multiply the different patterns of +/- 1 by the
# vector of differences. This will give you the sum of the differences

allsums <- permutations %*% unsigned.diff
   #     We could have put all of that together in one unreadable line
   #     > allsums <- as.matrix(expand.grid(as.data.frame(matrix(rep(c(-1,1),14), nr
   #     + =2)))) %*% unsigned.diff        Thanks to Bert Gunter for giving this approach

# If we want means, divide by n = 14
allmeans <- allsums/n

percent.above2 <- length(allmeans[allmeans >= abs(sample.mean)])/nreps
percent.below2 <- length(allmeans[allmeans <= (abs(sample.mean)*(-1))])/nreps
percent.extreme2 <- percent.above2 + percent.below2
cat("The permutation test probability under the null is = ",percent.extreme2,"\n\n")

# Note that this returns almost exactly the same result as the randomization procedure.


####################################################################################
# Finally, let's use the standard Wilcoxon Signed-Ranks Matched-pairs Test'
# Ignore warning messages--or else modify data trivially to prevent ties
#      For example, Level[3] <- 2.03001; Level[14] = 2.75001
nonpar <- wilcox.test(Elevated, Level, alternative = "two.sided", paired = TRUE, conf.int = TRUE)
cat("For the Wilcoxon test the p value under the null is ", nonpar$p.value,"\n\n")

# The choice of test clearly makes a difference, though not for randomizations.
