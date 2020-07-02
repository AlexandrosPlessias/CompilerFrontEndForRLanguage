births <- read.table('birth.txt',header=T)

# fit a loess regression

birth.lo <- loess(netherlands~year, data=births)
plot(birth$year,predict(birth.lo))

# the span = argument to loess() is the smoothing parameter
#  higher = smoother (more like an overall quadratic)

# compare predicted values with those from a quadratic model

birth.lm2 <- lm(netherlands~year + I(year^2), data=births)
# the I() bit is to tell R to evaluate the formula inside
# an alternative is to compute year2 in the births data frame
# births$year2 <- births$year^2
# birth.lm2 <- lm(netherlands~year + year2, data=births)

plot(birth$year, predict(birth.lm2))
lines(birth$year,predict(birth.lo))

# would be nice to use anova() to compare the two fits, but
#  anova can only compare loess() to loess() or lm() to lm()

# trick loess into giving you a quadratic regression

birth.lo2 <- loess(netherlands~year, data=births, span=100)
anova(birth.lo2, birth.lo)

# trick loess into giving you a linear regression
birth.lo1 <- loess(netherlands~year, data=births, span=100, degree=1)
anova(birth.lo1, birth.lo)

# The mgcv library provides gam() which gives you smoothing splines
#  and generalized additive models (covered in 511)


# Breusch-Pagan test, need to assemble by specific computations

# just the linear regression
birth.lm <- lm(netherlands~year,data=births)

esq <- (45/0.00006542)*resid(birth.lm)^2
# need to replace 45 by N, 0.00006542 by SSE

bp <- lm(esq~births$year)
summary(bp)
# gives you the information for the Breush-Pagan test


# the cut() function breaks a continuous variable into groups
yeargroup <- cut(birth$year,breaks=seq(1949,1994,5))

# seq(1949, 1994, 5) gives 1949, 1954, 1959, ...
# breaks includes the lowest break in the first group
# so the first group includes 1949, 1950, 1951, 1952, and 1953.
# 1954 goes into the second group

# the result of cut() is a factor



