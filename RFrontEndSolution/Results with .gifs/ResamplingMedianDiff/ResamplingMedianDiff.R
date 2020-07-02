# RAndomization test on difference between two medians

datafile <- read.table("http://www.uvm.edu/~dhowell/methods7/DataFiles/Ex7-31.dat", header = T)
head(datafile)
attach(datafile)
dv <- Gain      # Name needs to be modified to identify the appropriate dep. var.
n1 <- length(Group[Group == 1])
n2 <- length(Group[Group == 2])
N = n1 + n2
medians <- tapply(dv, Group, median)   # Calculate group medians
obt.median.diff <- medians[1] - medians[2]
nreps <- 10000                              # Number of replications
sample.median.diff <- numeric(nreps)        # Variable to hold median differences
for (i in 1:nreps) {
  newsample <- sample(dv, N, replace = FALSE)
  newmedians <- tapply(newsample, Group, median)
  sample.median.diff[i] <- newmedians[1] - newmedians[2]     # Accumulate median differences under null
}


obt.median.diff <- abs(obt.median.diff)           # Get absolute value to make next calc. easier
above <- length(sample.median.diff[sample.median.diff >= obt.median.diff])  # Count number greater
below <- length(sample.median.diff[sample.median.diff <= (-1)*obt.median.diff])# than obtained diff
pextreme <- (above + below)/nreps
cat("\n\n Probability under null of more extreme median difference than obtained =", pextreme,"\n\n")

hist(sample.median.diff, main = "Null Median Differences", breaks = 25)
text(2.85,1200,paste("Obt median diff = \n",obt.median.diff, "\nprob. under null = \n", pextreme))

print(t.test(dv~Group))
