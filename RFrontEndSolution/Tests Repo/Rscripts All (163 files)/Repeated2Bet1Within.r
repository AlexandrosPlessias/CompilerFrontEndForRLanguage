# Two between subject variables, one within
# Data from St. Lawrence et al.(1995)
# Methods8, p. 479

#  Note: In data file each subject is called a Person, and I convert that to a factor.
# In reshape, it creates a variable called "subject," but that is not what I want to use.
#  In aov the model is based on Person, not subject.


data <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab14-7.dat", header = T)
head(data)
# Create factors
data$Condition <- factor(data$Condition)
data$Sex <- factor(data$Sex)
data$Person <- factor(data$Person)

attach(data)

#Reshape the data

dataLong <- reshape(data = data, varying = 4:7, v.names = "outcome", timevar
= "Time", idvar = "subject", ids = 1:40, direction = "long")
detach(data)
dataLong$Time <- factor(dataLong$Time)
attach(dataLong)

tapply(outcome, Sex, mean)
tapply(outcome, Condition, mean)
tapply(outcome, time, mean)
options(contrasts = c("contr.sum","contr.poly"))
model1 <- aov(outcome ~ (Condition*Sex*factor(Time)) + Error(Person/(Time)))

summary(model1)
