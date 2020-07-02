bacillus <- read.table('bacillus2.txt',header=T)

# construct indicator variables, == is the R is.equal logical
# reference group coding, with Placebo as the reference

bacillus$a1 <- bacillus$trt == 'Ab1'
bacillus$a2 <- bacillus$trt == 'Ab2'
bacillus$a3 <- bacillus$trt == 'Pl'

# a1, a2, and a3 are logicals (F or T), but they are interpreted
#  (at least most of the time) as 0 or 1

a.lm <- lm(post~a1+a2,data=bacillus)
a0.lm <- lm(post~ +1, data=bacillus)  # intercept only model
anova(a0.lm, a.lm)   # overall ANOVA 
coef(a.lm)           # coefficients

# effects coding
bacillus$a1 <- bacillus$trt == 'Ab1'
bacillus$a2 <- bacillus$trt == 'Ab2'

bacillus$a1[bacillus$trt=='Pl'] <- -1
bacillus$a2[bacillus$trt=='Pl'] <- -1

b.lm <- lm(post~b1+b2,data=bacillus)
anova(a0.lm, b.lm)
coef(b.lm)

# cell means coding.  
# the following should work

c.lm <- lm(post~-1 + a1 + a2 + a3, data=bacillus)
  
# the -1 suppresses the intercept

# BUT, R interprets the logicals as factors when 
#  there isn't an intercept.  Wierd!
#  I think I have an explanation but would appreciate
#    any insight from an R guru

# To fit the cell means model, we need to convert the
#  indicator variables to integers (0 or 1)

bacillus$n1 <- as.integer(bacillus$a1)
# as.numeric() would also work
bacillus$n2 <- as.integer(bacillus$a2)
bacillus$n3 <- as.integer(bacillus$a3)
anova(a0.lm,c.lm)
coef(c.lm)


# R handles non-full rank X matrices gracefully

d.lm <- lm(post~a1 + a2 + a3, data=bacillus)
# or d.lm <- lm(post~n1 + n2 + n3, data=bacillus)

anova(d.lm)
coef(d.lm)

# if you use summary(), you get the appropriate
#  warning about singularities
summary(d.lm)


# You can see the X matrix automatically generated 
#  by R for factor variables by looking at the output
#  from model.matrix()

bacillus$trt.f <- as.factor(bacillus$trt)

model.matrix(post~trt.f,data=bacillus)

# and can change the contrast coding using contrasts=

model.matrix(post~trt.f,data=bacillus, 
  contrasts=list(trt.f=contr.SAS) )

# the named element is the factor and the value is
#   a specified set of contrasts
# R provides functions for:
#  contr.sas: "SAS" contrasts, reference = last
#  contr.sum: effect contrasts, sum to 0
#  contr.helmert: each group to average of subsequent ones
#  contr.poly: orthogonal polynomials
#  contr.treatment: reference contrasts to specified group

#  the default is contr.treatment using 1st group as ref.

