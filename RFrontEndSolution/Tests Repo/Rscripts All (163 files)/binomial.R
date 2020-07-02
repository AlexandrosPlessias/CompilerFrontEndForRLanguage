# Binomial distribution with p = .30 and n = 50.
# Created Figure 5.6
 # You are asked to specify p, the probability of success on any trial,
 # and n, the number of trials
cat('Enter number of observations \n') ;n <- scan(nmax = 1)
cat('Enter the probability of success \n') ;p <- scan(nmax = 1)
successes <- c(0:n)

y <- dbinom(successes, n, p)  #If you want cumulative distrib, change to "pbinom"
plot(y, type = "h", xlab = "Number of successes", ylab = "Probability")
