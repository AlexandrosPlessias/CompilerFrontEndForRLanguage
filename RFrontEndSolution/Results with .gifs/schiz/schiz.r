schiz <- read.table('schiz.txt',as.is=T,header=T)

# two ways to do a paired t-test:
t.test(schiz$unaff - schiz$aff)
t.test(schiz$unaff,schiz$aff,paired=T)

# and two ways to do Wilcoxon signed rank test:
wilcox.test(schiz$unaff - schiz$aff)
wilcox.test(schiz$unaff,schiz$aff,paired=T)

# can also do a sign test, but need to code from scratch by
#  counting # + and # - signs, then computing binomial tail
#  probability, probably by using pbinom()
#   

# need to reshape the data (one obs per row) to use blocks
#  N.B. the reshape package has much more powerful methods
#    to reshape data sets

# here's a brute force approach, to create columns with 
#  appropriate information

schiz2 <- data.frame(pair=rep(schiz$pair,2),
       trt = rep(c('unaffected','affected'),c(15,15)),
       y=c(schiz$unaff,schiz$aff) )

schiz2.aov <- aov(y~as.factor(pair) + as.factor(trt),data=schiz2)
anova(schiz2.aov)

# as before, R's facilities for 'after the ANOVA' are limited
# here's how to get means for each block and for each trt

model.tables(schiz2.aov,type='means')

# you can get Tukey HSD intervals for all pairwise differences:
TukeyHSD(schiz2.aov)

# this includes both trt (what you prob. want) and
#    pair (that you prob. don't want)

# you can restrict, but the which = has to match the model term
#   exactly:

TukeyHSD(schiz2.aov, which = 'as.factor(trt)')   # works
TukeyHSD(schiz2.aov, which = 'trt')              # doesn't

# unless you've already converted trt to a factor, so the model
#  only has trt

# There are at least 3 ways to fit a model with blocks as a random
#   effect, including lme() in the nlme package and 
#   lmer() in the nlme package.  
# Again, it is exceedingly difficult to move beyond tests, so the
#  use of these functions will have to wait until 511
