# Sampling Distribution of the mean for distribution like that in Table 7.1
# These are data on the psychomotor development index of the Bayley scales


data <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab7-1.dat", header = TRUE)
attach(data)
par(mfrow = c(3,1))

# First print out the raw data, which we will treat as a population.
hist(PDIscore, breaks = 25, density = 10, main = "Distribution of Raw Data")

# Then draw 10000 samples from this "population" (with replacement) and plot sampling distrib. of mean.
nreps = 10000
meanest <- colMeans(data)   #This just gives us the mean of our "population."
samplemeans <- numeric(nreps)
for (i in 1:nreps) {
  bootsample <- sample(PDIscore, size = 56, replace = TRUE)
  samplemeans[i] <- mean(bootsample)
  }

hist(samplemeans, breaks = 50, main = "Means of Bootstrap Samples", xlab = "Means")
arrows(100,350,meanest, 0)
text(x = 100, y = 400,paste("pop. mean = ",meanest))
cat("The mean of the sample means = ", mean(samplemeans), "\n")

# There is a simpler way, but the above makes clear what is happening.
# install.packages("asbio")
library(asbio)
newresult <- bootstrap(PDIscore, statistic = mean, R = 10000)
print(newresult)
hist(newresult$samples, breaks = 50, main = "Result Using Bootstrap Function \n in asbio Library")
