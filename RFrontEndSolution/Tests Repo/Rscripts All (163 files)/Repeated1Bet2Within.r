# Two within subject variables, one between
# Data from Bouton & Schwartzentruber (1985)
# Methods8, p. 486




data <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab14-11.dat", header = T)
names(data)
attach(data)

##  I should use "reshape," but I can't get it to work. This is pretty easy.
Phase <- factor(rep(1:2, each = 24, times = 4))
Cycle <- factor(rep(1:4, each = 48))
Group = factor(rep(1:3, each = 8,times = 8))
dv <- c(C1P1, C1P2, C2P1, C2P2, C3P1, C3P2, C4P1, C4P2)
Subj <- factor(rep(1:24, times = 8))

df <- cbind(Subj, dv, Group, Phase, Cycle)

cat("Means and sd by Group \n")
tapply(dv, Group, mean); tapply(dv, Group, sd)
cat("\n Means and sd by Cycle\n")
tapply(dv, Cycle, mean); tapply(dv, Cycle, sd)
cat("\n Means and sd by Phase\n")
tapply(dv, Phase, mean); tapply(dv, Phase, sd)

options(contrasts = c("contr.sum","contr.poly"))
model1 <- aov(dv ~ (Group*Cycle*Phase) + Error(Subj/(Cycle*Phase)), contrasts = contr.sum)
summary(model1)
coefficients(model1)



interaction.plot(Phase, factor(Group), dv, type="b", pch = c(2,4,6),
  legend = "F", col = c(3,4,6))
legend(1, 40, c("A-B", "A-A", "L-A-B"), col = c(4,6,3), text.col = "green4", lty = c(2, 1, 3), pch = c(4, 6, 2), merge = TRUE, bg = 'gray90')
