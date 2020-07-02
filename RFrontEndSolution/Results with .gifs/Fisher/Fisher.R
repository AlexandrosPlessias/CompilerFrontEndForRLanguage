# Question on one-tailed Fisher Exact Test
# The purpose of this code is to examine the results using Fisher's Exact Test to
# conduct one tailed and two-tailed tests.

# SPSS gives the probabilites as .007 and .005 for the two and one-tailed
# tests for both of the tables analyzed below.

table1 <- matrix(c(33, 33, 508, 251),nrow = 2)

# First the standard chi-square test
print(chisq.test( table1, correct = FALSE, simulate.p.value = TRUE))
# If you should want Yates' correction, change to "correct = TRUE"
# The chisq test can also be run by simulating tables and counting percentage
# of tables more extreme than the one we have.

# Then Fisher's Exact Test with various alternatives
print(fisher.test(table1, alternative = "two.sided"))
print(fisher.test(table1, alternative = "greater"))
print(fisher.test(table1, alternative = "less"))

table2 <- matrix(c( 33, 33,251, 508),nrow = 2)

print(chisq.test( table2, correct = FALSE))

print(fisher.test(table2, alternative = "two.sided"))
print(fisher.test(table2, alternative = "greater"))
print(fisher.test(table2, alternative = "less"))

# Now we will use the Mantel-Haenszel test for a 2 x 2 x 5 table
# CochranMantelHaenszel

contintab <- as.table(array(c(353,207,17,8,120,205,202,391,138
,279,131,244,53,138,94,299,22,351,24,317),dim = c(2,2,5)))

print(mantelhaen.test(contintab))
