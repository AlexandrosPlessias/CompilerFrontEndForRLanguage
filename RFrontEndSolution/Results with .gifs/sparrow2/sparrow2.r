# residual plots, Levene's test and Wilxocon test in R
#  using sparrow data as the example

sparrow <- read.table('sparrow.txt',as.is=T,header=T)

# create new variable lhumerus with the log of the humerus
sparrow$lhumerus <- log(sparrow$humerus)

# use lm() to fit t-test model to get residuals
#  fate must be a factor, 
#  read.table automatically converts character info to factors
#   if OMIT as.is=T.  But, numeric values not converted
#  I prefer to do explicitly, so you get a factor whether or not
#   values are character.
#  Many different approaches here; once you know what's going on,
#   do what works best for you.  

sparrow$fate.f <- as.factor(sparrow$fate)

sparrow.lm <- lm(humerus ~ fate.f, data=sparrow)

anova(sparrow.lm)
# print the F test, corresponds to t-test

# diagnostic plots based on residuals

qqnorm(resid(sparrow.lm))
#  qqplot for normal distribution

plot(predict(sparrow.lm),resid(sparrow.lm))
#  residual vs predicted value plot

plot(predict(sparrow.lm),abs(resid(sparrow.lm)))
#  abs(residual) vs predicted value plot

# Levene's test
sparrow$absresid <- abs(resid(sparrow.lm))
t.test(sparrow$absresid[sparrow$fate=='died'],
       sparrow$absresid[sparrow$fate=='alive'],
       var.equal=T)

# Wilcoxon rank sum test
wilcox.test(sparrow$humerus[sparrow$fate=='died'],
       sparrow$humerus[sparrow$fate=='alive'] )

# by default, uses "continuity correction", a detail
#  we haven't talked about
#  it improves fit of test statistic to normal distribution

# Wilcoxon rank sum test, with exact p-value
wilcox.test(sparrow$humerus[sparrow$fate=='died'],
       sparrow$humerus[sparrow$fate=='alive'],
       correct=F, exact=T )

# algorithm used by R does not work if there are ties
#  in the data (i.e. two or identical values)
