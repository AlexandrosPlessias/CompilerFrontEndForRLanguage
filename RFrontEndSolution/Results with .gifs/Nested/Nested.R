# Nested designs

data<- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Nested.dat",
 header = TRUE)
attach(data)
Gender <- factor(Gender)
Therapist <- factor(Therapist)
# First with the both factors fixed but Therapist nested within Gender

model1 <- lm(ResponseTime~Gender + Therapist %in% Gender)
cat("\n\n\t\t Revised F and p-values for model with both variables considered fixed\n\n")
print(anova(model1))

# Notice that in both effects were divided by the residual term, which 
# works fine if both are fixed.

# But if Therapist is random, then the error term for Gender is
# MS(Gender/Therapist)
model3 <- anova(model1)
Fgender <- model3$"Mean Sq"[1]/model3$"Mean Sq"[2]
model3$"F value"[1] <- Fgender

model3$"Pr(>F)"[1] <- pf(q = Fgender,df1 = model3$Df[1],df2 = model3$Df[2])
cat("\n\n\t\t Revised F and p-values for model with Therapist random\n\n")
print(model3)
