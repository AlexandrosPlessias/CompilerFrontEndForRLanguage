# Demonstration of resampling statistics for independent observations

# This begins with a standard t test on independent groups.
# Then we see one way to use a randomization test to do the same thing
# without worrying overmuch about the shape of the distribution.
# Then we see a very elegant way to accomplish nearly the same thing, but the
# R code is far from transparent.

# We are using a data file where the means are roughly equal--The size of the moon illusion
# with eyes elevated and eyes level. I have added some observations so that the sampling
# distribution of the differences is not close to normal.

datafile <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab18-2.dat", header = TRUE)
attach(datafile)
Group <- factor(Group)
cat("The names of the variables are ",names(datafile), "\n")
means <- tapply(dv, Group, mean)
sd <- tapply(dv, Group, sd)
n.s <- tapply(dv, Group, length)
samp.mean.diff <- means[1] - means[2]
cat("The sample mean differences is ", samp.mean.diff , "\n")
# Plot a histogram of the differences
par(mfrow = c(2,2))
grp1 <- dv[Group == 1]
grp2 <- dv[Group == 2]
hist(grp1, main = "Group 1 = Success", xlim = c(5,25))
xv <- seq(min(grp1),max(grp1),.1)    # Next three lines superimpose a normal distrib on each group
yv <- dnorm(xv, mean = mean(grp1), sd = sd(grp1))
par (new = TRUE)
plot(xv, yv, type = "l", col = "blue", xlim = c(5,25), xlab = "", yaxt = "n", ylab = "")
hist(grp2, main = "Group 2 = Fail", xlim = c(5,25))
xv <- seq(min(grp2),max(grp2),.1)
yv <- dnorm(xv, mean = mean(grp2), sd = sd(grp2))
par (new = TRUE)
plot(xv, yv, type = "l", col = "blue", xlim = c(5,25), xlab = "", yaxt = "n", ylab = "")
cat("NOTE: Group 1 (Success) is clearly not normally distributed")

#############################################################################################################
# First we will run a standard t test

t.result <- t.test(dv~ Group, paired = FALSE, conf.level = .95)
print(t.result)
cat("The t-test gives a probability under the null of ",t.result$p.value,"\n\n")


# Now to continue using randomization test
# Leave Group as is, but randomly reorder the dv and get mean difference

nreps = 1000
meandiff <- numeric(nreps)
for (i in 1:nreps) {
  newdata <- sample(dv, size = length(dv), replace = FALSE)
  newmeans <- tapply(newdata, Group, mean)
  meandiff[i] <- newmeans[1] - newmeans[2]
  }

# We want a two-tailed test, so we can work with absolute values.
absdiff <- abs(meandiff)
prob <- length(absdiff[absdiff >= abs(samp.mean.diff)] )/nreps

cat("The randomization test gives a probability under the null of " , prob, "\n\n")

#######################################################################################################################

# In theory we could do something like with did with paired samples and compute all possible permutations of
# the dv. However that would be factorial(67) = 3.647111e+94, which is about 3.6 with 94 0s after it. Not feasible!!
# I know that many of those have the same (rearranged) data in the same group, but that still leaves 9.3649e+15,
# which is still unreasonable even if I knew how to draw only permutations with scores changing groups.


####################################################################################
# Finally, let's use the standard Wilcoxon Rank-Sum Test'

nonpar <- wilcox.test(dv~Group, alternative = "two.sided", paired = FALSE, conf.int = TRUE)

cat("For the Wilcoxon test the p value under the null is ", nonpar$p.value,"\n\n")
cat("      Ignore warning about ties--there are bound to be ties with this much data \n\n")
cat("This is remarkable agreement, but we have a large data set, even if one group is badly skewed", "\n\n")
