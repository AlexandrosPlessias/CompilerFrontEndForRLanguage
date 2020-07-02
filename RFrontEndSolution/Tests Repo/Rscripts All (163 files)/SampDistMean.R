# Sampling distribution of the mean
# Allows for differing sample sizes

nreps = 10000
cat("\nEnter sample size for small sample size plot \n")
nsmall <- scan("", nmax = 1)
cat("\nEnter sample size for large sample size plot \n")
nlarge <- scan("", nmax = 1)
sampdist.mean.small <- numeric(nreps)
sampdist.mean.large <- numeric(nreps)
par(mfrow = c(2,2 ))
for (i in 1:nreps)  {
  sample <- runif(nsmall, 0,100)
  sampdist.mean.small[i] <- mean(sample)
  }
  
hist(sampdist.mean.small,
   main = paste('Histogram of Sampling Distribution \n with sample size = ',nsmall),
   xlab = 'Sample Mean',
   xlim = c(0,100),
   ylim = c(0,2000),
   breaks = 25)
   
for (i in 1:nreps)  {
  sample <- runif(nlarge, 0,100)
  sampdist.mean.large[i] <- mean(sample)
  }
  
qqnorm(sampdist.mean.small)
qqline(sampdist.mean.small)

hist(sampdist.mean.large,
   main = paste('Histogram of Sampling Distribution \n with sample size = ',nlarge),
   xlab = 'Sample Mean',
   xlim = c(0,100),
   ylim = c(0,2000),
   breaks = 25)
   
qqnorm(sampdist.mean.large)
qqline(sampdist.mean.large)
