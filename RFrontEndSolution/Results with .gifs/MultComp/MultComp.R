#   Muoltiple Comparison Tests
# Giancola and Corman. 2007  Oneway design

# This code should be revised just to help it make more sense.
# Calculations for Welch test are done step-by-step to keep parentheses straight.

library(Hmisc)
library(car)
library(asbio)
n <- 12
ni <- c(12,12,12,12,12)
wk <- numeric(10)


g1 <- c( 1.28, 1.35, 3.31, 3.06, 2.59, 3.25, 2.98, 1.53, -2.68,
   2.64, 1.26 , 1.06)
g2 <- c(   -1.18, 0.15, 1.36, 2.61, 0.66, 1.32, 0.73, -1.06, 
   0.24, 0.27, 0.72, 2.28)
g3 <- c(-0.41, -1.25, -1.33, -0.47, -0.60, -1.72, -1.74, -0.77, 
  -0.41, -1.20, -0.31, -0.74)
g4 <- c(-0.45, 0.54, -.98, 1.68, 2.25, -0.19, -.90, 0.78, .05, 2.69, .15, 0.91)
g5 <- c(2.01,0.40, 2.34, -1.80, 5.00, 2.27, 6.47, 2.94, 0.47, 
   3.22, 0.01, -0.66)
dv <- c(g1, g2, g3, g4, g5)

grp <- factor(rep(1:5,each = 12))
data <- data.frame(dv, grp)
head(data)
means <- tapply(dv, grp, mean)
GM <- mean(dv)
stdev <- tapply(dv, grp, sd)
variance <- tapply(dv, grp, var)
names(means) <- c("D0", "D2", "D4", "D6", "D8" )
names(stdev) <- c("D0", "D2", "D4", "D6", "D8")
names(variance) <- c("D0", "D2", "D4", "D6", "D8")
print("Group Means")
print(means)
print("Group Standard Deviations") 
print(stdev)
MSwithin <- sum(stdev^2)/length(stdev)


# Now the standard analysis of variance. I used Anova(), but could equally have used anova()
model1 <- lm(dv~grp)
print(Anova(model1))

# Pairw.test comes from the asbio package and handles a variety of tests.

Tukey <- Pairw.test(dv, grp, conf.level = .95, method = "Tukey")
cat("\n\n Results of the Tukey test \n")
print(Tukey); cat("\n\n")

LSD <- Pairw.test(dv, grp, conf.level = .95, method = "LSD")
cat("\n\n Results of the LSD test \n")
print(LSD); cat("\n\n")

Bonferroni <- Pairw.test(dv, grp, conf.level = .95, method = "Tukey")
cat("\n\n Results of the Bonferroni test \n")
print(Bonferroni); cat("\n\n")

Scheffe <- Pairw.test(dv, grp, conf.level = .95, method = "Scheffe")
cat("\n\n Results of the Scheffe test \n")
print(Scheffe); cat("\n\n")


# You can also use the p.adjust function in the stats: library, but I
# haven't wuite figured that out to my satisfaction. See also p.adjust in stats package

p <- c(.0717, 5e-05, .0124, .04525, .83208, .02122, .88829, .05305, 3e-05, .03277) # p from LSD
p.adjust.methods <- c("holm", "hochberg", "hommel", "bonferroni", "BH", "BY", "fdr", "none")
p.adjust(p = p, method = p.adjust.methods, n = length(p))
p.adjust(p = p, method = "fdr", n = length(p))
