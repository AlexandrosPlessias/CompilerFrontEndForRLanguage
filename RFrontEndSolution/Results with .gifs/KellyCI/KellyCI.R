# Confidence limits on effect size
# Using Kelly's MBESS software and the ci.smd
# This function pools the variances.

# Example Uses data on homophobia from study by Adams et al.

dat <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab7-5.dat", 
    header = TRUE)
    
attach(dat)
Group <- factor(Group)
# First run a t test comparing the means of the two groups.
means <- tapply(Arousal, Group, mean)
meandiff <- means[1] - means[2]
stdev <- tapply(Arousal, Group, sd)
sizes <- tapply(Arousal, Group, length)
cat("Group Means \n",means, "\n")
cat("Group St. Dev. \n",stdev, "\n")
cat("Group Sizes \n",sizes, "\n" )
cat("Difference in Group Means \n", meandiff, "\n \n")

t <- t.test(Arousal ~ Group, alternative = "two.sided", conf.level = .95)
print(t)

# Now we can look at effect sizes.
# Install MBESS by using Packages/Install Packages from the R console.

library(MBESS)

# ncp is taken as the obtained t value and is a starting point.

print(ci.smd(ncp = t$statistic, n.1 = sizes[1], n.2 = sizes[2], conf.level = .95))

   # You could replace "ncp = t$statistic" pr  "ncp = 2.49" with smd = 0.62 (calculated value of d)
   # For example
   #sp <- sqrt(((sizes[1]-1)*(stdev[1]^2)+(sizes[2]-1)*(stdev[2]^2))/(sizes[1]+sizes[2]-2))
   #d <- meandiff/sp
   #ci.smd(smd = d, n.1 = sizes[1], n.2 = sizes[2], conf.level = .95)



print(ci.smd(smd = 0.62, n.1 = 35, n.2 = 29))

#If we thought of the nonhomophobic group as a control group, we could use its
#standard deviation in calculating d.

# s(control) = 12.201
 print(ci.smd.c(ncp = 2.5319, n.E = 35, n.C = 29))
#  OR
print(ci.smd.c(smd.c = .635775, n.E = 35, n.C = 29))
