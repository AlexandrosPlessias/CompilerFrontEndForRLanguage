# computing probabilties and quantiles in R

# computing T quantile for one d.f. 
# arguments are probability, d.f.

qt(0.975, 10)

# can also provide many d.f. or probabilities

qt(0.975, c(10,20))

# going backward: computing probability from T value
# arguments are value, d.f.

pt(2, 10)

# and can apply to many 

pt(2, c(10,20))

# same for Chi-square: only one indicated

qchisq(0.975,10)
pchisq(38.2,20)

# often want upper tail prob. (default is lower)
pchisq(38.2,20,lower=F)

# which is same as 1-pchisq(38.2,20)
