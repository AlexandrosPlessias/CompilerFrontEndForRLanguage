# REML estimation of variance components
#  nested effects (farm, bales in farm)
#  using lmer

wool <- read.table('wool.txt',header=T)
#  after reshaping wool.txt into row column format

library(lme4)
 
# there is an outlier, remove that before continuing
#  (could also use subset=() in the lmer call

wool2 <- wool[wool$clean < 62,]

# create farm, could also use match() 
# bales 1 and 2 are from farm SE, 3-5 from SW, and 6 and 7 from C

wool2$farm <- rep(c('SE','SW','C'),c(2,3,2))[wool2$bale]

# convert both bale and farm to factors so can nest

wool2$farm.f <- as.factor(wool2$farm)
wool2$bale.f <- as.factor(wool2$bale)

wool.vc <- lmer(clean~(1|farm/bale),data=wool2)
# farm/bale indicates farm , then bale nested in farm (bale:farm) 

# can also specify both explicitly
wool.vcb <- lmer(clean~(1|bale) + (1|farm:bale),data=wool2)
