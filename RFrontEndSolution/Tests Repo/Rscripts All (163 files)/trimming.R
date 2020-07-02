# Compute means, st. dev. and trimmed statistics for a variable.
# Requires the "psych" and "asbio" libraries

library(psych)
library(asbio)

dat <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab2-1.dat", header = TRUE)
head(dat)
attach(dat)

sampmean <-mean(RxTime)
sampmedian <- median(RxTime)
sampsd <- sd(RxTime)
n <- length(RxTime)

cat("The mean and median are ", sampmean, " and ", sampmedian,"\n")
cat("The sample standard deviation is ", sampsd, "\n")
cat("There are ",n," observations \n")
describe(RxTime)         # Alternative method of getting what we want


# Generate a 10% trimmed sample    Requires asbio

trimmed.sample <- trim.me(RxTime, trim = .10)
cat("The trimmed sample is \n")
trimmed.sample
trimmed.mean <- mean(trimmed.sample)
trimmed.sd <- sd(trimmed.sample)
cat("The mean of the trimmed sample is ", trimmed.mean,"\n", "The standard deviation is ", trimmed.sd, "\n")

# Generate a 10% Winsorized sample and its standard deviation   Requires psych
winsor.sample <- winsor(RxTime, trim = .10)
cat("The Winsorized sample is \n")
winsor.sample
winsor.mean <- mean(winsor.sample )
winsor.sd <- sd(winsor.sample)
cat("The mean of the Winsorized sample is ", winsor.mean,"\n", "The standard deviation is ", winsor.sd, "\n")

# Now we can plot all three distributions on the same graph
par(mfrow = c(3,1))
# Because the range of the trimmed sample is shorter than of the raw data,  I had to specify the break points to
# make things come out even.
hist(RxTime, breaks = seq(30,130,5), col = "blue", xlim = c(min(RxTime), max(RxTime)),
  density = 10, ylim = c(0,60), xlab = "Reaction Time")
  legend(80, 45, substitute(Mean == a,list(a = sampmean)), bty = "n")
  legend(80,30,substitute(sd == a,list(a = sampsd)),col = "blue", bty = "n")


hist(trimmed.sample, breaks = seq(30,130,5), col = "red", xlim = c(min(RxTime), max(RxTime)),
    density = 20, ylim = c(0,60), xlab = "Reaction Time")
  legend(80, 45, substitute(Mean == a,list(a = trimmed.mean)), bty = "n")
  legend(80,30,substitute(sd == a,list(a = trimmed.sd)),col = "blue", bty = "n")
  
hist(winsor.sample, breaks = seq(30,130,5), col = "green", xlim = c(min(RxTime), max(RxTime)),
  density = 20, ylim = c(0,60), xlab = "Reaction Time")
    legend(80, 45, substitute(Mean == a,list(a = winsor.mean)), bty = "n")
  legend(80,30,substitute(sd == a,list(a = winsor.sd)), bty = "n")
  