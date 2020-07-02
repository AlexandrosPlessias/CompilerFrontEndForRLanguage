# Binomial and Multinomial Distributions

#The program named binomial.R is probably better for the binomial, but we'll persevere

# Binomial
p = .45; q = .55   # Probabilities of success and failure
outcome = c(12, 9) # I want the probability of 12 successes and 9 failures
N = sum(outcome)
dbinom(x = outcome[1], size = N, prob = c(p))

# BUT for this problem it is easier to use the multinomial function.
dmultinom(x = outcome, prob = c(p,q))

# We really need the multinomial when we have more than two possible outcomes.   


# Suppose p <- c(.333, .5, .167)
# I want prob of getting x = c(4,5,1) in the 3 boxes
 x <- c(4,5,1)
 prob <- c(.333, .5, .167)
dmultinom(x=x,prob=prob)
#0.08085632
