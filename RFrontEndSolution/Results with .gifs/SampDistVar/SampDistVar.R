# Sampling distribution of the variance
# This program uses both small and large sample sizes to illustrate the difference.
# This program does not do bootstrapping because it recreates the sample from a
# population at each iteration.

nreps = 10000
cat("\nEnter sample size for small sample size plot \n"); nsmall <- scan("", nmax = 1)

cat("\nEnter sample size for large sample size plot \n"); nlarge <- scan("", nmax = 1)

sampdist.var.small <- numeric(nreps)
sampdist.var.large <- numeric(nreps)
par(mfrow = c(3,2 ))
for (i in 1:nreps)  {   
  # Draw sample of size nsmall from normal with mean = 5 and sd = sqrt(50)
  sample.small <- rnorm(nsmall, 5,7.0711)     # Refreshed on each iteration.                                 
  sampdist.var.small[i] <- var(sample.small)
  }
  
hist(sampdist.var.small,
   main = paste('Sampling Distribution of Variance \n with sample size = ',nsmall),
   xlab = 'Sample Variance',
   xlim = c(0,250),
   ylim = c(0,1500),
   breaks = 50)
abline(v = mean(sampdist.var.small))
legend(40,800,paste("Mean is ",round(mean(sampdist.var.small),4)), bty = "n")


qqnorm(sampdist.var.small)
qqline(sampdist.var.small)

for (i in 1:nreps)  {
  sample.large <- rnorm(nlarge, 5,7.0711)
  sampdist.var.large[i] <- var(sample.large)
  }

hist(sampdist.var.large,
   main = paste('Sampling Distribution of Variance \n with sample size = ',nlarge),
   xlab = 'Sample Variance',
   xlim = c(0,250),
   ylim = c(0,1000),
   breaks = 50)
abline(v = mean(sampdist.var.large))
legend(40,800,paste("Mean is ",round(mean(sampdist.var.large),4)), bty = "n")

qqnorm(sampdist.var.large)
qqline(sampdist.var.large)

# Remember that s^2 is an unbiased estimate of the population variance, so
# the mean of the variances should be very close to 50, our population variance.


# You might think that we should be able to replicate this with bootstrapping,
# but that's not true. The bootstrap starts with 1 sample and resamples it. Therefore
# if the variance of that sample happens to be way less than 50, so will the 
# variances of the subsamples. I fell into that trap.

#But to sneak in the bootstrap just to show it,
#
#library(asbio)
#sample.asbio <- rnorm(nlarge, mean = 5, sd = 7.0711)
#newresult <- bootstrap(sample.asbio, statistic = var, R = 10000)
#hist(newresult, breaks = 50, main = paste("Result Using Bootstrap Function \n 
#in asbio Library--n = ", nlarge), xlim = c(0,250), ylim = c(0,1000))
#abline(v = mean(newresult)) 
#legend(40,800,paste("Mean is ",round(mean(newresult),4)), bty = "n")
# 
#qqnorm(newresult)
#qqline(newresult)
