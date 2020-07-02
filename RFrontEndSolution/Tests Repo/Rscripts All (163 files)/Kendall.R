
# Kendall's tau and other correlation coefficients

# Data on Alcohol and Tobacco expenditures in Great Britain
Alc <- c(4.02, 4.52, 4.79, 4.89, 5.27, 5.63, 5.89, 6.08, 6.13, 6.19, 6.47)
Tob <- c(4.56, 2.92, 2.71, 3.34, 3.53, 3.47, 3.20, 4.51, 3.76, 3.77, 4.03)
cor.test(Alc,Tob,alternative = "two.sided", method = "kendall", ,exact = TRUE)
cor.test(Alc,Tob,alternative = "two.sided", method = "spearman", ,exact = TRUE)
cor.test(Alc,Tob,alternative = "two.sided", method = "pearson", ,exact = TRUE)

#  OUTPUT for Kendall
#        Kendall's rank correlation tau
#
#data:  Alc and Tob 
#T = 37, p-value = 0.1646
#alternative hypothesis: true tau is not equal to 0 
#sample estimates:
#      tau 
#0.3454545 

#Alternative solution--remove # for following lines
#library(Kendall)
#Kendall(Alc, Tob)
