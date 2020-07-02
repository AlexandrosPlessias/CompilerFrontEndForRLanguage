# Binomial sampling as n increases
# Illusstrates that as simple size increases, the obtained proportion
# of successes approaches the true population proportion.
# Sample sizes vary from 1 to 500

# The population proportion varies for each plot.
# Not a terribly exciting result.  Very inelegant because it uses two loops.

par(mfrow = c(3,2))
p <- c(.5, .6, .7, .8, .9 , .95)
max.sample.size = 500

for (j in 1:6) {
    probs <- numeric(500)     # Resets results before next pass
    for (i in 1:max.sample.size)   {
       probs[i] <- rbinom(1,i,p[j])/(i)
    }
plot(probs, ylim = c(0,1), xlab = "Sample Size", ylab = "Obtained Proportion")
legend(250, .3, paste("p = ", p[j]),   bty = "n")
}
   