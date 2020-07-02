# split plot ANOVA 

class <- read.table('class.txt',header=T,as.is=T)

# convert group variables to factors
class$class.f <- as.factor(class$class)
class$method.f <- as.factor(class$method)
class$tutor.f <- as.factor(class$tutor)

# aov has more helper functions, but it only works correctly for
#  balanced data


class.aov <- aov(score~method.f*tutor.f+Error(method.f:class.f),data=class)

# aov complains that error is singular, 
#  but results seem to be correct

# the * generates main effects and all interactions (SAS's |)
# the : generates interaction (SAS's *)

# fixed effects go in the usual place
# random effects go in the Error() function.
#  need to specifically indicate that class and method are related
#  'all combinations of method and class', i.e. method.f:class.f does this

# if you replace Error(method.f:class.f) with Error(class.f)
#   Method is tested against the error MS, not the class MS

# helper functions include:

model.tables(class.aov,type='means')
# marginal means and cell means

model.tables(class.aov,type='means',se=T)
# if you try to get s.e's, you get told 'not yet implemented'
#   for a multiple e.u. model

summary(class.aov)
# gives you the anova table given separately for each
#  error term

# the residual standard error is the sqrt(MSE) for each stratum


# the alternative is to use the mixed model workhorse: 
#  lmer in the lme4 package

library(lme4)

class.lmer <- lmer(score~method.f*tutor.f+(1|method.f:class.f),data=class)

# fixed effects in the usual place
# random effects are indicated inside ()
#   by the parameter that varies (here, the intercept)
#   and the group that it varies by 
#     (here, all comb. of method and class)

# again, if you use class instead of class:method, method
#  gets tested against the MSerror

print(class.lmer)  # or summary(class.lmer)
# gives you estimates of the variance components
# the fixed effect estimates are the regression coefficients for
#  the columns of X variables used by R

anova(class.lmer)
# gives you an anova table, but it doesn't indicate
#  error df or give you p-values.

# if there is an option to do this, please let me know and
#  I will update this information

# if there is an easy way to get marginal means (especially for
#  unbalanced data), please let me know.

# for unbalanced data, my understanding is that the R tests 
#  are sequential (Type I), not type III.  The usual way to get
#  type III tests, using drop1(XXX, .~.) does not appear to work
#  with lmer objects.




