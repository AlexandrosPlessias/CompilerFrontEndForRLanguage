# This will generate data with a specified intercorrelation matrix
# If empirical = T, then the matrix will have the exact correlatons,
# otherwise it will sample from those parameters.

# This is a very simple function to use and has multiple applications.

library(MASS)
Sigma = matrix(c(1, .33, -.34, .33, 1, -.60, -.34, -.60, 1), nrow = 3) 
mu = c(0,0,0)
dat <- mvrnorm(n = 45,mu ,Sigma , empirical = T)
