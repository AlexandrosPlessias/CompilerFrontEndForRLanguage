# Generate all permutations of a set of values

#  permn is a function, in library combinat, to generate all possible permuations of the vector x

# install.packages("combinat")  #Remove # for first time
library(combinat)

# Generate permutations of 4 numbers
x <- c(2,5,6,8)     # The vector you want to permute
y <- permn(x)
cat("Generate permutations of 4 numbers")
print(y)               # This will print out the 24 possible permuations, one at a time.

# Generate permutations of first n integers
n <- 7
cat("Generate permutations of first n integers")
print(permn(n))  # There are 5040 permutations.

# Now go to combinations
# Generate cominations of 5 things taken 5 at a time (silly--there will only be one)
x <- c(2,4,6,3,7)
cat("Generate cominations of 5 things taken 5 at a time (silly--there will only be one)")
print(combn(x,5))

# Combinations of x taken 3 at a time-- there are 10
cat("Combinations of x taken 3 at a time-- there are 10")
print(combn(x,3))

# We can get the mean of each combination
cat("We can get the mean of each combination")
print(combn(x, 3, fun = mean))    # fun = mean says to apply the mean function within R
