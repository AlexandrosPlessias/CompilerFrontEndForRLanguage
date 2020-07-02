# Friedman's test versus randomized repeated measures anova

# We can take the data from the book and analyze it using Friedman's
# Test. That test basically ranks scores within subjects and then randomizes
# those rankings. 
#
# Then we can randomize the raw scores instead and carry out the same kind of
# procedure using the variance of the means rather than the variability of summed ranks.
# Finally, we can go back and run a standard repeated measures analysis of variance.

datafile <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab18-10.dat", header = TRUE)
attach(datafile)
cat("The names of the variables are ", names(datafile))

# The standard Friedman nonparametric test
newdata <- as.matrix(datafile[-1])            # Strip out the first variable, which is just the id number
result <- friedman.test(newdata)
print(result)
cat("\n\n")

# Now we will randomly order raw data within rows.
# We will take the variance of the means as our statistic. If the null is false, the variance
# of the sample means should be much greater than obtained under the null.
mean.samp.columns <- colMeans(newdata)
var.samp.means <- round(var(mean.samp.columns), digits = 2)
nreps = 10000
var.means <- numeric(nreps)
newmatrix <- matrix(0,17,3)
for (i in 1:nreps) {
  for (j in 1:17){
  newmatrix[j,] <- sample(newdata[j,],3, replace = FALSE)
  }
#  Now we have a new matrix that has the same data but randomized within subjects
  
col.means <- colMeans(newmatrix)
var.means[i] <- var(col.means)
}
hist(var.means, xlab = "Variance of Randomized Means", main = "", freq = FALSE)
arrows(8, .3, var.samp.means, .05)
text(8, .33, "Var. Sample Means")
text(8, .29, var.samp.means)
prob <- length(var.means[var.means >= var.samp.means])/nreps
text(10,.10,substitute(p-value == probability, list(probability = prob)))

##################################################################################
# Now for the standard analysis of variance.

library(car)

# Convert to long form.

datLong <- reshape(data = datafile, varying = 2:4, v.names = "outcome", timevar
= "time", idvar = "Subject", ids = 1:17, direction = "long")
detach(datafile)
attach(datLong)
aov.model <- aov(outcome~factor(time)+Error(factor(Subject)))
print(summary(aov.model))
