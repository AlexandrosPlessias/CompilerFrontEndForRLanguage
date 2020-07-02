# Benjamini-Hochberg LSU
# Need to install "Biobase", and then install "mutoss"   BUT first you need to install Biobase
# Biobase does not install in the usual way. To install this package, start R and enter:
#
#    source("http://bioconductor.org/biocLite.R")
#    biocLite("Biobase")
# You can install "mutoss" in the normal way.

   library(Biobase)
   library(mutoss)
# Using the example of Siegel's experiment from the book, enter the obtained p values in decreasing order 
# These are taken from Table 12.4
   pValues <- c(.726, .086, .041, .018, .00007, .00003, .00000, .00000, .00000, .00000)
   alpha = .05

   # There are two possible ways of doing this. The more traditional, in line with the text, is
sig.test <- linearStepUp(pValues, m = 10, q = alpha)        # m = number of hypothese tested, q = alpha level
cat("\n\n\t\tTraditional Benjamini-Hochberg (1995) Approach \n")
print(sig.test$Pvals)
    # These results look like those in Table 12.4.  BUT the column headed "rejected" should be labeled "H0"
                              #  a value of FALSE for rejected means that the null was rejected. It does NOT mean
                              #  that "rejected is false ." It means that "null is false."
    
    # Alternatively, we can find the exact adjusted probabilities.    This will give
    # p values for only the significant di8fferences, though 
    
exact.p <- BH(pValues, alpha)
      str(sig.test$Pvals)
	  