# Power demonstration
# The idea is to draw data from a situation where the null is false, and
# the calculate the percentage of times a resampling program rejects the null.
# It should reject with p = power.

# You can change the group means, the st. dev., or the sample sizes
# install.packages("pwr")
library(pwr)
nreps = 10000
n.C <- 20
n.T <- 20
n <- 20  #for convenience I will stick with equal sample sizes
results <- numeric(nreps)
df = 2*n - 2
mu.C <- 9.64; mu.T <- 6.58
sd.C <- 3.17; sd.T <- 3.03
s.pooled <- sqrt((((n-1)*sd.C^2 + (n-1)*sd.T^2))/((n-1 + n-1)))
d <- (mu.C - mu.T)/s.pooled     
ncp <- delta <- d*sqrt(n/2)                                                
tcrit = qt(.975,df,0)      #Calculates the two-tailed critical value of t on df degrees of freedom

for (i in 1:nreps) {
  data.C <- log(rnorm(n.C, mu.C, sd.C)+20)
  data.T <- log(rnorm(n.T, mu.T, sd.T)+20)
  results[i] <- t.test(data.C, data.T, alternative = "two.sided", mu = 0)$statistic
  }

countpos <- length(results[results > tcrit])            # Calculates results greater than +- tcrit                                                                                              
countneg <- length(results[results < -1*tcrit])
percent <- (countpos + countneg)/nreps

# Now calculate and print power

 # Calculation of power
library(pwr)    #You may have to install this
  print(pwr.t.test(n = 20, d = d, sig.level = .05, type = "two.sample"))


hist(results, breaks = 50, xlab = "Obtained t Values", probability = TRUE, main = "", xlim = c(-4,6), ylim = c(0,.45))
xv <- seq(-4,6.99,.01)             # Sets us up to plot smooth distribution and shading
yv <- dt(xv, df, ncp = ncp)        # Calculates density at each value of t from -4 to +6.99
par(new = T)
plot(xv, yv, "l", new = T,  xlim = c(-4,6), ylim = c(0,.45), xlab = "", ylab = "")
polygon(c(xv[xv >= tcrit],tcrit),c(yv[xv>=tcrit],yv[xv==6.99]),density = 20, xlab = "", ylab = "", col = "blue")
polygon(c(xv[xv <= -1*tcrit],-1*tcrit),c(yv[xv<= -1*tcrit],0),density = 20, xlab = "", ylab = "", col = "red")         # Would shade negative tail, but no values occurred down there.
text(x = 5, y = .3, paste( "Area =",percent, "\n = est. power"))
arrows(x0 = 4.75, y0 = .27, x1 = 3, y1 = .1, length = .20, code = 2, col = "red")
arrows(x0 = -1, y0 = .10, x1 = 2.02, y1 = 0, length = .10, code = 2, angle = 20)
text(-2, .12, paste("Crit. Value = ",round(tcrit, 3)))



