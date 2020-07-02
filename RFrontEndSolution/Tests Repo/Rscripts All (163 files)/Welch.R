#  Welch test with unequal variances

# Read in the data with the dependent variable labeled dv and the grouping variable
# labeled group.
# Alternatively, you could modify this to read in means, variances, and sample size.

data <- read.table(file.choose(), header = TRUE)
attach(data)
# To fit with rest of code I need to rename my variables
# I am using Table 11.6
dv =  After
group = Group
ni <- tapply(dv, group, length)
means <- tapply(dv, group, mean)
variance <- tapply(dv, group, var)
# then specify the sample sizes

wk <- ni/variance
xbarprime <- sum(wk*means)/sum(wk)
   a <- (means-xbarprime)^2
   b <- sum(wk*a)   
   k <- length(means)
num <- b/(k-1)

den <- 1 + 2*(k-2)/(k^2-1)*sum((1/(ni-1))*(1-wk/sum(wk))^2 )
Fprime <- num/den
dfprime <- (k^2-1)/(3*sum((1/(ni-1))*(1-wk/sum(wk))^2 ))

cat("Welch's Fprime = ", Fprime,"\n")
cat("Welch's df =      ", dfprime, "\n")
