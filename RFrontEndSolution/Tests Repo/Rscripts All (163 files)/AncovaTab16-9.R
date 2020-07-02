
# Analysis of Covariance
# Data from Table 16.7

library(car)   #Loads special ANOVA functions and data
dat <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab16-7.dat", header = TRUE)
#  Variables are Group, Pretest, Posttest

attach(dat)
Group <- as.factor(Group)
    #Pretest not converted to factor because it is the covariate

options(contrasts = c("contr.sum", "contr.poly"))
print(contrasts(Group))

# Because we have a balanced design, much of what follows is the same whether we
# use anova or Anova. The complete Ancova in Table 16.9 is reproduced by
# Anova but not anova, but that is just dependent on how you want to partition the SS. Both
# are legitimate.

print(anova(aov(Posttest~Group + Pretest)))   # Uses anova from base package--Type I by default)
print(anova(aov(Posttest~Pretest+Group)))     # Reversal of order for other Type I SS)
print(Anova(aov(Posttest~Group + Pretest)))   # Uses Anova from car package--Type II by default--Table 16.9)
print(Anova(aov(Posttest~Group + Pretest, type = 3)))     #No diff. because no interaction
full.model <- lm(Posttest~Group + Pretest)
print(anova(full.model))       # Table 16.8a  Sum of Group and Pretest SS = 82.644
grp.model <- lm(Posttest~Group)
print(anova(grp.model))        # Table 16-8b
cov.model <- lm(Posttest~Pretest)
print(anova(cov.model))        # Table 16.8c

print(Anova(full.model))
