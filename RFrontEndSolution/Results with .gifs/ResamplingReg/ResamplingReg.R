# # Resampling Regression

# This program looks at two separate multiple regression equations for predicting
# combined SAT scores for Gruber's data.
# It finds the empirical cutoff points for the 95% confidence interval.
# It plots the results and prints out the confidence limits.

dat <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab15-1.dat",
sep = "\t", header = TRUE)
attach(dat)
nreps <- 1000   #Set number of replications
b1 <- numeric(nreps)
b2 <- numeric(nreps)
# Using Expend and LogPcxtSat
model1 <- lm(SATcombined~Expend + LogPctSAT)
b1obs <- model1$coeff[2]
b2obs <- model1$coeff[3]
# Start resampling
for (i in 1:nreps) {
sample.50 <- sort(sample(nrow(dat),50,replace = TRUE))   #Create a sample of row nmumbers
sampdata <- dat[sample.50,]             #Sample those rows
model2 <- lm( sampdata$SATcombined~sampdata$Expend + sampdata$LogPctSAT)
b1[i] <- model2$coeff[2]
b2[i] <- model2$coeff[3]
}
seb1 <- sd(b1)   #Compute standard errors--not necessarily needed
seb2 <- sd(b2)
cat("Results using Expend and LogPctSAT as predictors \n")
cat("The standard errors of b1 and b2 are: ",seb1, seb2, "\n")
par(mfrow=c(2,2))
hist(b1, breaks = 100, main = "b1 for Expenditure")
hist(b2, breaks = 100, main = "b2 for Log Percent Taking SAT")

#Compute percentage of resamples that exceed limits.
      

lower.limit <- .025*nreps; upper.limit <- .975*nreps
b1 <- sort(b1)
b2 <- sort(b2)
cat(" The lower limit of b1 = ", b1[lower.limit], "\n")
cat(" The upper limit of b1 = ", b1[upper.limit], "\n")
cat(" The lower limit of b2 = ", b2[lower.limit], "\n")
cat(" The upper limit of b2 = ", b2[upper.limit], "\n \n \n")

#*******************************************************************    
cat("Results using Expend and PTratio as predictors \n")
# Now replacing LogPctSAT with PTratio to get a non-significant variable


b1 <- numeric(nreps)
b2 <- numeric(nreps)
model3 <- lm(SATcombined~Expend + PTratio)
b1obs <- model3$coeff[2]
b2obs <- model3$coeff[3]
# Start resampling
for (i in 1:nreps) {
sample.50 <- sort(sample(nrow(dat),50,replace = TRUE))   #Create a sample of row nmumbers
sampdata <- dat[sample.50,]             #Sample those rows
model4 <- lm( sampdata$SATcombined~sampdata$Expend + sampdata$PTratio)
b1[i] <- model4$coeff[2]
b2[i] <- model4$coeff[3]
}
seb1 <- sd(b1)   #Compute standard errors--not necessarily needed
seb2 <- sd(b2)
cat("The standard errors of b1 and b2 are: ",seb1, seb2, "\n")
hist(b1, breaks = 100, main = "b1 for Expenditure")
hist(b2, breaks = 100, main = "b2 for Pupil/Teacher Ratio")

#Compute confidence limits on b1 and b2

lower.limit <- .025*nreps; upper.limit <- .975*nreps
b1 <- sort(b1)
b2 <- sort(b2)
cat(" The lower limit of b1 = ", b1[lower.limit], "\n")
cat(" The upper limit of b1 = ", b1[upper.limit], "\n")
cat(" The lower limit of b2 = ", b2[lower.limit], "\n")
cat(" The upper limit of b2 = ", b2[upper.limit], "\n")
