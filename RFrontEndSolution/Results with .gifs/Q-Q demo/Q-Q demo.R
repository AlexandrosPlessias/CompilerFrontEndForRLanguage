# Demonstration of Q-Q plots

par(mfrow = c(2,3))
par(bg = "springgreen")    # Just to make things pretty
normal <- rnorm(100)
chi <- rchisq(100, 3)
hist(normal, breaks = 25, main = "Sample from normal distribution",
  xlab = "X values")
qqnorm(normal, main="QQ-plot for normal sample", xlab = "obtained quantiles",
ylab = "Expected quantiles")
qqline(normal)

#Now plot the probability distribution,  and add normal curve
hist(normal, breaks = 25, main = "Sample from normal distribution",
  xlab = "X values", probability = TRUE, xlim = c(-3,3))
par(new = TRUE)
curve(dnorm,-3,3, , xlim = c(-3,3))

# Now use chisquare discribution, which is not normal
standard.chi <- (chi - mean(chi))/sd(chi)
hist(standard.chi, breaks = 25, main = "Sample from normal distribution",
  xlab = "X values")
qqnorm(standard.chi, main = "Q-Q plot for nonnormal sample", xlab = "obtained quantiles", ylab = "Expected quantiles")
qqline(standard.chi)


###Now Q-Q using Everitt's cog. behav. therapy data
par(ask = TRUE)   #This will pause so that you can see above graphics. Click upper left.
par(mfrow = c(2,2))
data <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Ex14-21.dat", header = T)
attach(data)
Pctgain <- (Posttest-Pretest)/Pretest
qqnorm(Pctgain, main = "Q-Q plot of percentage gain" )
qqline(Pctgain)
Gain = Posttest - Pretest
Gain <- (Gain-mean(Gain))/sd(Gain)
qqnorm(Gain, main = "Q-Q plot of weight gain")
qqline(Gain)

# QQ Plot of RxTime data
RxTimeData <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Ex2-1.dat", header = T)
attach(RxTimeData)
qqnorm(y = RxTime, main = "Q-Q Plot for RxTime", xlab = "Theoretical Quantiles",
  ylab = "Obtained Quantiles")
qqline(RxTime)
  