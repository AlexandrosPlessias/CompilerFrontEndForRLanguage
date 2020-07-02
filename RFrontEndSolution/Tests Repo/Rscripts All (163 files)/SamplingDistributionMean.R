# Sampling distribution in Chapters 7
# Looks as samplinbg distribution if you vary n and if you vary underlying population

# Plots the sampling distribution of the mean when drawing from a normal distribution
#               By changing "n" in the commands below you can see how the shape
#               of the distribution depends on sample size.
#               Removing "#" allows for sampling from other distributions
#               The axes on the graph change when you change sample size, so the
#               curve doesn't APPEAR to get any steeper, though it really does.

# The first set of graphs show what happens when we sample from different, and non-normal,
# distributions. (Thge normal, the chi-square, and the exponential.
# The last two plots show the distribution when the null is true and when it is false.

# Run SampDistMeansVaryN.R if you want to see how the distribution changes as
# you change the sample size.

n <- 20                        # Sample size
nreps <- 10000                 # Number of replications
sample.mean <- numeric(nreps)  # Variable to store means
par(mfrow = c(3,2))

sample.normal <- rnorm(n = 1000, mean = 35, sd = 15)  #Just to see what distrib. looks like
for (i in 1:nreps) {
  sample <- rnorm(n = n,mean =  35, sd = 15)  # 100 normal obs with mean = 35 and sd = 15
  sample.mean[i] <- mean(sample)       # Calculate means for each sample and store them.
}  
   
# Now plot out the large sample and the means
hist(sample.normal, breaks = 50, main = "Distribution of Normal Population", xlab = "")
hist(sample.mean, breaks = 50, main = "Distribution of Sample Mean \n for Normal", xlab = "Mean")

# The chi-square distribution on 6 df is quite skewed
 sample.chisq <- rchisq(1000, df = 6)
 for (i in 1:nreps) {
    sample <- rchisq(100, 6)
    sample.mean[i] <- mean(sample)
    }
hist(sample.chisq, breaks = 50, main = "Distribution of Chi-square Population", xlab = "")
hist(sample.mean, breaks = 50, main = "Distribution of Sample Mean \n for Chi-Square", xlab = "Mean")
    
# Now we will draw from an exponential distribtution, which is very skewed. Let n = 10
# First a histogram of the exponential itself
sample.expon <- rexp(n = 10000, rate = 1.5)
hist(sample.expon, breaks = 50, main = "Exponential Distribution")

# Then the distribution of means
means.exp <- numeric(nreps)
for (i in 1:nreps) {
  sample.first.exp <- rexp(n = 10, rate = 1.5)
  means.exp[i] <- mean(sample.first.exp)
  }
hist(means.exp, breaks = 50, main = "Distribution of Means  \n for Exponential", xlab = "Mean ")

################################################################################

#  Now plot distribution of mean differences when H0 is true
mean.diff <- numeric(nreps)
for (i in 1:nreps) {
   sample.first <- rnorm(n = 100, mean = 35, sd = 15)
   sample.second <- rnorm(n = 100, mean = 35, sd = 15)
   mean.diff[i] <- mean(sample.first) - mean(sample.second)
}
par(ask = TRUE)  
print("You will be asked if you want to go on to the next graphics screen.")
print("Click on 'Next' in upper left of graphics screen.")
hist(mean.diff, breaks = 50, main = "Distribution of Mean \n Differences", xlab = "Mean Difference H0 true")
  # Notice that the distribution is centered on 0.0
  
#  Now plot distribution of mean differences when H0 is false
mean.diff <- numeric(nreps)
for (i in 1:nreps) {
   sample.first <- rnorm(n = 100, mean = 35, sd = 15)
   sample.second <- rnorm(n = 100, mean = 45, sd = 15)
   mean.diff[i] <- mean(sample.first) - mean(sample.second)
   }
hist(mean.diff, breaks = 50, main = "Distribution of Mean \n Differences", xlab = "Mean Difference Ho false")
  # Notice that the distribution is centered on -10.0
  
  
  # You can sample from other distributions --some of which we have used.
    # sample <- rexp(n = 100, rate = 1)           # for exponential
    # sample <- rchisq(n = 100, df = 1, ncp = 0)  # for chi-sq on 1 df
    # sample <- runif(n = 100, min = 0, max = 1)  # for uniform (rectangular) distrib.
    # sample <- rpois(n = 100, lambda =  1)       # for poisson with mean = lambda
    # sample <- rbinom(n = 100, size = 10, p = .7 # Draw 100 samples of 10 items with p(success) = .70   
    