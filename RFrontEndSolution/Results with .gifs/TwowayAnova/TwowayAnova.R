### Howell Table 13.2 ###
## A x B anova  Eysenck example
# Read in data and factor() Age and Condition
par(mfrow=c(2,2))
Eysenck <- read.table("http://www.uvm.edu/~dhowell/methods7/DataFiles/Tab13-2.dat",
 header = TRUE)
Eysenck$subj <- factor(1:100)
Eysenck$Condition <- factor(Eysenck$Condition, levels = 1:5, labels = c("Counting",
     "Rhyming", "Adjective", "Imagery","Intention"))
Eysenck$Age <- factor(Eysenck$Age, levels = 1:2, labels = c("Old","Young"))
attach(Eysenck)
#Compute the anova and then print out the result
result <- anova(aov(Recall~Condition*Age, data = Eysenck))
print(result)
plot(Recall~Condition)

#better Yet!  Maybe
# This should allow me to get Type III SS. But when I use "type = "III" " I get a
# strange answer even though the design is orthogonal. If I use "type = II" with
# this orthogonal designs I get the right answer. Odd because this should give
# legitimate type III SS whether the design is orthogonal or not.
library(car)
resultsCar <- aov(Recall~Condition*Age, data = Eysenck )
Anova(resultsCar, type = "II")
Anova(resultsCar, type = "III")
################################################################################

# Now to get Simple Effects

# I am going to test each effect with its own error term, though you could
# pool the error terms if you wish.


old.dat <- subset(Eysenck, Eysenck$Age == "Old")
young.dat <- subset(Eysenck, Eysenck$Age == "Young" )

results1 <-anova(aov(Recall ~ Condition, data = old.dat) )
cat("\n\n\t\tResults for older subjects\n")
print(results1)
plot(Recall~Condition, data = old.dat, main = "Older Subjects")

results2 <-anova(aov(Recall ~ Condition, data = young.dat) )
cat("\n\n\t\tResults for younger subjects\n")
print(results2)
plot(Recall~Condition, data = young.dat, main = "Younger Subjects")
