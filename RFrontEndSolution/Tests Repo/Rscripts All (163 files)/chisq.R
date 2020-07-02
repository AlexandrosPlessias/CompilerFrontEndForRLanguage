# Question on one-tailed Fisher Exact Test

tab1 <- matrix(c(33, 33, 508, 251),nrow = 2)

fisher.test(tab1, alternative = "two.sided")
fisher.test(tab1, alternative = "greater")
fisher.test(tab1, alternative = "less")

tab2 <- matrix(c( 33, 33,251, 508),nrow = 2)

fisher.test(tab2, alternative = "two.sided")
fisher.test(tab2, alternative = "greater")
fisher.test(tab2, alternative = "less")

# CochranMantelHaenszel

contintab <- as.table(array(c(353,207,17,8,120,205,202,391,138
,279,131,244,53,138,94,299,22,351,24,317),dim = c(2,2,5)))

mantelhaen.test(contintab)

#trying hand calc.
r1 <- c(560,325,417,191,373)
r2 <- c(25,593,375,393,341)
c1 <- c(370,322,269,147,46)
c2 <- c(215,596,523,437,668)
totsubk <- r1+r2

den1 <- (r1*r2*c1*c2)/((totsubk^2)*totsubk-1)
den <- sum(den1)

expect11 <- r1*c1/totsubk
obs11 <- c(353, 120, 138, 53,22)

num1 <- (abs(sum(obs11)-(sum(expect11))))
num <- (num1-.5)^2

cmh <- num/den
cmh
