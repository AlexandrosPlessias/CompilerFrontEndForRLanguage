# Bootstrapping difference between two medians
# This uses an algorithm suggested by Manly (2007), pp. 116-117

# It gives a result that looks odd to me--the median differences are not centered
# on 0.00 even though each sample has been centered.

#Uses data from Ex7-31 in 7th edition Everitt's Control vs CogTherapy'
# A t-test on these data gives a t of -1.68.

datafile <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Ex7-31.dat", header = T)
head(datafile)       # The variables are id, dv, Group, with dv as the dep. var.
attach(datafile)

dv <- Gain
GMed <- median(dv)
medians <- tapply(dv, Group, median)   # Calculate group medians
obt.median.diff <- medians[1] - medians[2]

dv1 <- dv[Group == 1]             # Set up separate groups
dv2 <- dv[Group == 2]
dv1 <- dv1 - median(dv1) + GMed      # The medians of dv1 and dv2
dv2 <- dv2 - median(dv2) + GMed      # are now equal (at 19.75 in this example)
#       dv2 <- dv1     # See end of code
n1 <- length(dv1)
n2 <- length(dv2)

nreps <- 10000                              # Number of replications
sample.median.diff <- numeric(nreps)        # Variable to hold median differences
for (i in 1:nreps) {
  median1 <- median(sample(dv1,size = n1,replace = TRUE ))
  median2 <- median(sample(dv2,size = n2,replace = TRUE ))
  sample.median.diff[i] <- median1 - median2     # Accumulate median differences under null
}

abs.median.diff <- abs(obt.median.diff)           # Get absolute value to make next calc. easier
above <- length(sample.median.diff[sample.median.diff > abs.median.diff])  # Count number greater
below <- length(sample.median.diff[sample.median.diff < (-1)*abs.median.diff])# than obtained diff
pextreme <- (above + below)/nreps
cat("\n\n Probability under null of more extreme median difference than obtained =", pextreme,"\n\n")

hist(sample.median.diff, main = "Null Median Differences", breaks = 25)
text(-7,1500,paste("Obt median diff = \n",obt.median.diff, "\nprob. under null = \n", pextreme))

# The next two are for comparative purposes.
print(wilcox.test(formula = dv~Group, alternative = "two.sided", paired = FALSE))
print(t.test(dv~Group))

       # Ignore error message

# I repeated the above but forced the two samples to be equal by inserting dv2 <- dv1.
# The distribution in no longer skewed, but the probabilities come out to be approx. .40.

# (Sprent suggests a different test which is a binomial test on the proportions
#  in the two samples that are less than the common mean.)
