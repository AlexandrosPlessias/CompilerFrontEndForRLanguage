# Conf. limits on effect size

# Suppose that F = 6.90 on 4 and 55 df
# Giancola study

library(MBESS)
limits <- conf.limits.ncf(F = 6.90, conf.level = .95, df.1 = 4, df.2 = 55)
lower <- limits$Lower.Limit
upper <- limits$Upper.Limit
cat("The lower and upper confidence limits on the non-centrality parameter (lambda) are \n")
cat(lower," and ", upper,"\n")            #Not shown in text

 # We want the root-mean-square standardized effect (RMSSE)

 #phi <- sqrt(lambda/(k-1)*n)
k = 5
n = 12
lambda.1 <- limits$Lower.Limit
lambda.2 <- limits$Upper.Limit
phi.1 <- sqrt(lambda.1/((k-1)*n))
phi.2 <- sqrt(lambda.2/((k-1)*n))
cat("The lower and upper confidence limits on RMSSE are \n")
cat(phi.1," and  ",phi.2)


#### Rewriting this for the Eysenck one-way example in Exercise 11.1

limits <- conf.limits.ncf(F = 9.08, conf.level = .95, df.1 = 4, df.2 = 45)
lower <- limits$Lower.Limit
upper <- limits$Upper.Limit
lower
upper # But this only gives us CI on ncp (lambda)
 # We want the root-mean-square standardized effect (RMSSE)

 #phi <- sqrt(lambda/(k-1)*n)
k = 5
n = 10
lambda.1 <- limits$Lower.Limit
lambda.2 <- limits$Upper.Limit
phi.1 <- sqrt(lambda.1/((k-1)*n))
phi.2 <- sqrt(lambda.2/((k-1)*n))
cat("The lower and upper confidence limits on RMSSE are \n")
cat(phi.1," and  ",phi.2)
