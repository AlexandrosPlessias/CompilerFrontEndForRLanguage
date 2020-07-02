# REML estimation of variance components

# there are two basic packages for mixed models
#  nlme, with the lme function
#  lme4, with the lmer function

# the syntax to specify random effects differs slightly.

# the following illustrates lmer, which is slightly more flexible
#  and a lot faster 

wool <- read.table('wool.txt',header=T)
#  after reshaping wool.txt into row column format

library(lme4)
 

# there is an outlier, remove that before continuing
#  (could also use subset=() in the lmer call

wool2 <- wool[wool$clean < 62,]

wool.vc <- lmer(clean~(1|bale),data=wool2)
wool.vc

# random effects in lmer are specified as the quantity that
#  varies (here the intercept) and the grouping variable
#  here the bale.  
# for simple (e.g. 1-way random effects) uses, does not need
#  to be a factor.  Does't hurt to make it so.  
# because bale is numeric, it isn't automatically convert to 
#  a factor in read.table()

# lmer only allows REML (or full ML) estimation.

# bale needs to be a factor to use Nested effects (wool2.r)

wool2$bale.f <- as.factor(wool2$bale)
wool.vc <- lmer(clean~(1|bale.f),data=wool2)
wool.vc
