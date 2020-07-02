# fit multiple regression in R

brain <- read.table('brain.txt',as.is=T, header=T)

brain$loggest <- log(brain$gest)
brain$logbrain <- log(brain$brain)
brain$logbody <- log(brain$body)
brain$loglitter <- log(brain$litter)

brain.lm <- lm(logbrain ~ logbody + loglitter + loggest, data=brain)

summary(brain.lm)
# print out coefficients, se's, individual tests, and other info

# need to use explicit model comparison to construct F tests

brain.lm2 <- lm(logbrain ~ logbody  + loggest, data=brain)
 # model with loglitter = 0

anova(brain.lm2,brain.lm)
 # gives F test of loglitter = 0

# can also get F test for each term using drop1()
drop1(brain.lm, .~., test='F')

brain.lm3 <- lm(logbrain ~ logbody, data=brain)
 # model with log gest= 0 and loglitter = 0
anova(brain.lm3,brain.lm)


brain$littgest <- brain$loglitter - brain$loggest
brain.lm4 <- lm(logbrain ~ logbody + littgest, data=brain)
 # model with loglitter + loggest = 0
 # reasoning behind littgest described in lecture

anova(brain.lm4,brain.lm)

# to test loggest + loglitter = 1, need to expand prev. approach
#  substituting the constraint and simplifying, you see you need
#  Y = logbrain - loggest

brain$braingest <- brain$logbrain - brain$loggest
brain.lm5 <- lm(braingest ~ logbody + littgest, data=brain)

# can't use anova() because Y has changed.
#  could compare error SS by hand

# can fit desired model, keeping logbrain as response by 
#  specifying loggest as an offset (a fixed constant)

brain.lm5 <- lm(logbrain ~ logbody + littgest, offset = loggest, data=brain)
anova(brain.lm5)

# same as SAS test3 from proc reg.

# N.B. if H0 was something like loggest + loglitter = 2, would need
#  compute a new variable with 2*loggest, can not specify a formula
#  as an offset


# residuals from lm()
#  obtained as before

brain.resid <- resid(brain.lm)

# to get lag residuals, use appropriate indexing
n <- length(brain.resid)

plot(brain.resid[1:(n-1)], brain.resid[2:n])
# index deletion is a bit shorter but more opaque
# plot(brain.resid[-n], brain.resid[-1])

# can get just the lag-1 correlation
cor(brain.resid[-n], brain.resid[-1])

# or a bunch of  lag correlations, 
#  what is called an autocorrelation function
acf(brain.resid)



# demonstration of partial regression 
brain.plm1 <- lm(logbrain~logbody + loglitter, data=brain)
brain.plm2 <- lm(loggest~logbody + loglitter, data=brain)

brain.plm3 <- lm(resid(brain.plm1) ~ -1 + resid(brain.plm2) )

summary(brain.plm3)
