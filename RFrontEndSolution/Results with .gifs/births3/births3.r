births <- read.table('birth.txt',header=T)

# There is a durbin-watson test function in both the car and lmtest
#   libraries.
# I don't have any experience with either, so I can't make a
#   recommendation.  

# regression with ar(1) errors.  Requires the nlme library.

library(nlme)

birth.ar <- gls(netherlands~year,data=birth,corr=corAR1(0,~1))

# gls() is the generalized least squares estimation function
# corAR1() specifies an ar(1) correlation.  
#  The first value  is the initial value for the ar(1) correlation.
#    This is iteratively updated, so in a well-behaved problem, 
#    the choice doesn't matter.   
# The second specifies the time variable and optionally groups 
#    of independent obs.  If obs are in time order ~1 suffices.

# gls() does not provide the Kenward-Rogers adjustments, so the
#  results will be somewhat different from SAS
