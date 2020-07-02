# Calculate power for correlation coefficients
# install.packages("pwr")
library(pwr)  #You may have to first install pwr.

n = 50
r = .30
power <- pwr.r.test(n,r,sig.level = .05)
print(power)
