# Smoking and Nicotine Gum

dat <- read.table(("http://www.uvm.edu/~dhowell/methods8/DataFiles/SmokingGum.dat"), header = TRUE)
attach(dat)
RiskRatio <- (SuccessT/TotalT)/(SuccessC/TotalC)
lnRR <- log(RiskRatio)
VarlnRR <- 1/SuccessT + 1/TotalT + 1/SuccessC + 1/TotalC
SERR <- sqrt(VarlnRR)
lowerCI <- exp(lnRR - 1.96*SERR)
upperCI <- exp(lnRR + 1.96*SERR)
# Now consolidate over all studies
weight <- 1/VarlnRR
summaryRR <- exp(sum(weight*lnRR)/sum(weight))
SEsummary <- sqrt(1/sum(weight))
lowerSummary <- exp(summaryRR - 1.96*SEsummary)
upperSummary <- exp(summaryRR + 1.96*SEsummary)
cat("The summary risk ratio is = ",summaryRR,"\n")
cat("The confidence limits on summary risk ratio are = \n",lowerSummary,"   and   ",upperSummary,"\n")

#Testing for heterogeneity
Q <- sum(weight*lnRR^2)-(sum(weight*lnRR)^2/sum(weight))
C <- sum(weight) - sum(weight*lnRR)/sum(weight)
df <- length(weight)-1
Tsqr <- (Q-df)/C
cat("Our obtained value of Q is \n",Q)
cat("The critical value of chi-square on ",df," degrees of freedom is \n",qchisq(.95,df))
