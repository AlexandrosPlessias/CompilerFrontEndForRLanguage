# two way ANOVA 

# R assumes data files are in row-column format
# ratweight2.txt is in that format

rat <- read.table('ratweight2.txt',header=T, as.is=T)

# I prefer to read columns as is and explicitly convert 
#  those I want to factors.  That avoids much confusion
#  when a column of numbers is to be considered a factor.
# others are very comfortable with the default behaviour

# the reshape package provides a way to transpose and reshape
#  data.  I still find it easier to manipulate data in SAS
#  because you have access to a data programming language

# convert amount and type to factors
rat$amount.f <- as.factor(rat$amount)
rat$type.f <- as.factor(rat$type)

rat.lm <- lm(gain~amount.f + type.f + amount.f:type.f, data=rat)

# the : indicates the interaction between two factors

# the * indicates all main effects and interactions

rat.lm2 <- lm(gain~amount.f*type.f, data=rat)

# fits exactly the same model.

# print out the anova table
anova(rat.lm)

# aov() is a wrapper to lm() that adds useful info for ANOVA models

rat.aov <- aov(gain~amount.f + type.f + amount.f:type.f, data=rat)

# you can get the anova table
summary(rat.aov)  # or anova(rat.aov)

# R's facilities for 'beyond the ANOVA table' are limited

# you can get tables of marginal means and their se's

model.tables(rat.aov, se=T, type='means')
# model.tables does not work for lm() results

# and differences among pairs and adjusted p-values
#  using Tukey's HSD

TukeyHSD(rat.aov)

# se.contrast() provides a way to get the se of a contrast
# but it doesn't give you the estimate of that contrast!!
# you have to compute that by hand????
# If someone knows something to the contrary, please let me know

# I don't know any equivalent of the SAS 'slice'.


# more importantly, and hence, NOTE and HUGE warning:  
#  All the R functions work best (sometimes only work) 
#   when  the data is balanced!!!!

# when the data is unbalanced, R's built-in functions 
#   don't work well

# R reports type I (sequential) SS.
# You can get type III SS by specifically requesting 
#  an orthogonal set of contrasts (e.g. contr.helmert, 
#  see contrasts for how to change the contrast), 
#  then using drop1()

# model.tables() reports some sort of marginal mean, 
#  but it is not the average of cell means

# model.tables() is completely misleading 
#   if you are missing a cell in a factorial design,
#  the marginal means are not estimable, but
#    model.tables() still reports something!!

# TukeyHSD() has the same problem
#  Worse, it doesn't even give you a warning that the
#    design is unbalanced.

# My sense is that you can get R to provide valid answers to questions, 
#  but you have to work at it and you have to know a lot of details
#    (e.g. choice of constrast matrices)
#  Who would know that you have to reset the default contrasts
#    to get valid type III tests?
#  This is especially true if you want answers that go beyond the ANOVA
#   table.  You have to work very hard to get those sorts of answers
#   from R.  SAS makes everything much easier.


# If anyone has information to the contrary,
#  especially for unbalanced data, please let me know.


