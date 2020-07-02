# Example of chi-square for a contingency using Jankowski et al,'s data

    # Notice how the following offers use a way to name variables and their levels.
data <- array(c(512,227,59,18,
                54,37,15,12),
                dim = c(4,2),
                dimnames = list(
                  ChildAbuse = c("None", "1", "2", "3"),
                  AdultAbuse = c("No", "yes")
                  ))

result <- chisq.test(data, correct = FALSE)  # Error message just means an exp. freq < 5.
print(result)
result$observed
result$expected
cat("The warning message results whenever an expected frequency is less than 5.","\n")

# The following will give Fisher's Exact Test
print(fisher.test(data))

#The following computes a simulation with fixed marginals
fisher.test(data, simulate.p = TRUE)

# Now we will look at another way of making these calculations that focusses
# on odds ratios. You can learn more by typing ?oddsratio on the command line
# after you have loaded the epitools library
# install.packages("epitools")
library(epitools)
result = oddsratio(data, verbose = T)
print(result)

# You can also use
print(oddsratio.fisher(data, conf.level = 0.95))
