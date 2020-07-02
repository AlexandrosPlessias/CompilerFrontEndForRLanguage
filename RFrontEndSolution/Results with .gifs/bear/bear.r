# stepwise regression in R

# N.B. I have always used SAS for stepwise and all subsets regression.
# The following is intended to get you started.  I have no personal
#  experience with any of the following functions.

# stepwise regression.  R takes a different perspective, using AIC.
#  this has the benefit of being a common criterion for many sorts
#  of models.

# first define and fit the full model

bear <- read.table('bear.txt',header=T)
bear.lm <- lm(weight~.,data=bear)

# the . on the right hand side indicates all numeric variables

# then walk through a add/delete algorithm based on AIC
#  the resulting model is stored in bear.step

bear.step <- step(bear.lm)

# all subsets regression:
# the leaps() in the leaps package implements all subsets regression

# my philosophy towards packages has been conservative.  There are
# great packages and some poor packages.  leaps() is widely cited, but
# I haven't any experience with it.  Hence, I can't and won't make
# any recommendations.


