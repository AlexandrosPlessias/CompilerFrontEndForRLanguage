# Case diagnostics

brain <- read.table('brain.txt',as.is=T, header=T)

brain$loggest <- log(brain$gest)
brain$logbrain <- log(brain$brain)
brain$logbody <- log(brain$body)
brain$loglitter <- log(brain$litter)

brain.lm <- lm(logbrain ~ logbody + loglitter + loggest, data=brain)

rstandard(brain.lm)
# internally standardized residuals

rstudent(brain.lm)
#  externally studentized residuals (use MSE(-i))

influence.measures(brain.lm)
# computes (and prints) DFBETA's, DFFITS, Cook's D and Hii
#  also computes the covariance ratio, which I don't use,
#  but it's there if in case you want it.

# result of influence.measures has class infl.
# can access each bit (e.g. to plot) by burrowing into the infl 
#  class structure, or you can access each diagnostic by specific
#  functions.

# N.B. A plot of only one thing uses 1:N as the X axis

plot(dffits(brain.lm))
plot(cooks.distance(brain.lm))
plot(hatvalues(brain.lm))

dfb <- dfbetas(brain.lm)
# there are four columns because k=3, 
# plot each column of dfbetas
oldpar <- par(mfrow=c(2,2), mar=c(3,4,2,1)+0.1)
for (i in 1:4) { plot(dfb[,i]); title(dimnames(dfb)[[2]][i])}
par(oldpar)


