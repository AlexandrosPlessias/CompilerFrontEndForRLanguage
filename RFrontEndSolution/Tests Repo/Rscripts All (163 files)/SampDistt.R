# Sampling Distribution of t
# Try using different values of n to change df

par(mfrow = c(1,1))
nreps <- 10000
cat('Enter number of observations for t. \n') ;n <- scan(nmax = 1)
results <- numeric(nreps)
df <- n-1
for (i in 1:nreps) {
  data <- rnorm(n = n, mean = 25,sd = 5)      # Draw sample of size n with mean = 25 and s = 5
  # Now calculate a t test on these data for H0: mu = 25  (i.e. H0 true)  Repeat nreps times
  results[i] <- t.test(data, mu = 25)$statistic    #t value against H0: mu = 25
  }
  
  #results now holds 10,000 t statistics
results <- results[results >= -6]      # Toss out very extreme values
results = results[results <= 6]        # to keep histogram looking reasonable
hist(results, breaks = 50, main = "Sampling Distribution of t  with \n t and normal distribution superimposed ",
    xlim = c(-5,5), ylim = c(0,.5), probability = TRUE)
legend(3,.3,paste("df = ", df))
par(new = TRUE)    # To superimpose the plots

plot(function(x) dt(x, df = 5, ncp = 0), -5,5, ylim = c(0.00, 0.5), col = "red", ylab = " ")
arrows(2,.45,0, .38, length = .125)
text(2.1, .45, "t distrib", col = "red")
par(new = TRUE)
plot(function(x) dnorm(x, 0,1), -5,5, ylim = c(0.00, 0.5), col = "blue", ylab = " ")
arrows(-2,.45,0, .40, length= .125)
text(-2.1,.45, "normal distrib.", col = "blue")
a <- length(results[abs(results) >= qt(p = .975, df = df)])
b <- length(results[abs(results) >= 1.96])
cat (paste('Proportion of replications exceeding tabled value of t at alpha = .05 \n',a/nreps,'\n' ))
cat (paste('Proportion of replications exceeding z = +- 1.96 for alpha = .05 \n',b/nreps,'\n' ))
