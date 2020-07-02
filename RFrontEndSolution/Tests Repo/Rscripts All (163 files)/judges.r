# R equivalent of judges.sas

judges <- read.table('judges.txt',as.is=T,header=T)

# need to convert judge # to a factor 
#  judges are numbered, so read.table() leaves as numbers
#  even without as.is=T.  
#  this is why I prefer to explicitly convert

judges$judge.f <- as.factor(judges$judge)


# fit the ANOVA model using either lm() or aov()

judges.lm <- lm(percent~judge.f, data=judges)
judges.aov <- aov(percent~judge.f, data=judges)

# calculate and print the anova table
anova(judges.lm)     # anova(judges.aov) gives same results

# here's what happens if you mistakenly forget the factor
anova(lm(percent~judge, data=judges))

# judge has 1 d.f.!!!  
#  You're fitting a linear regression, not an ANOVA model

# Stuff 'after' the fitting the ANOVA
#  Here's where R is not nearly as flexible as SAS

# tables of means, only for aov object

model.tables(judges.aov, type='means')

# BUT will only compute se's if equal # obs in each cell !!!!

# and from here on out, you're stuck, at least without 
#   hand coding things. There is a se.contrast function, but 
#   you can't specify the contrasts.  You need to use
#   sets of predefined contrasts (polynomials, helmert, ...)

# there may be appropriate functions in add on packages, 
#   but I haven't found them.


# the one thing that is nice is diagnostics

# e.f. a residual vs predicted value plot:
plot(predict(judges.lm), resid(judges.lm))






