#R for repeated measures
library(car)
data <- read.table(("http://www.uvm.edu/~dhowell/methods8/DataFiles//Tab14-3.dat"), header = TRUE)

# data$subject <- factor(1:9)   subject is already a variable in the data set.
datLong <- reshape(data = data, varying = 2:6, v.names = "outcome", timevar
= "time", idvar = "subject", ids = 1:9, direction = "long")
attach(datLong)

time <- factor(time)
Subject <- factor(Subject)
options(contrasts=c("contr.sum","contr.poly"))
modelAOV <- aov(outcome~factor(time)+Error(factor(Subject)), data = datLong)
print(summary(modelAOV))

###########################################################################
#
#Error: factor(Subject)
#          Df Sum Sq Mean Sq F value Pr(>F)
#Residuals  8  486.7   60.84
#
#Error: Within
#             Df Sum Sq Mean Sq F value Pr(>F)
#factor(time)  4 2449.2   612.3   85.04 <2e-16 ***
#Residuals    32  230.4     7.2
#---
#Signif. codes:  0 ‘***’ 0.001 ‘**’ 0.01 ‘*’ 0.05 ‘.’ 0.1 ‘ ’ 1
   #
###########################################################################

plot(time, outcome, pch = c(2,4,6), col = c(3,4,6))
lines(gmeans)
legend(4, 30, c("same", "different", "control"), col = c(4,6,3),
                      text.col = "green4",  pch = c(4, 6, 2),
                      merge = TRUE, bg = 'gray90')
