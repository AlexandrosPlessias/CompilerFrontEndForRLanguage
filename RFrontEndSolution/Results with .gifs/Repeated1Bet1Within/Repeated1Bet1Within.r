# This was written by Joshua Wiley, in the Psychology Department at UCLA.
#  Modified for one between and one within for King.dat by dch

### Howell Table 14.4 ###
## Repeated Measures ANOVA with 2 variables
## Read in data, convert to 'long' format, and factor()

dat <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab14-4.dat", header = TRUE)


head(dat)

dat$subject <- factor(1:24)
datLong <- reshape(data = dat, varying = 2:7, v.names = "outcome", timevar
= "time", idvar = "subject", ids = 1:24, direction = "long")

datLong$Interval <- factor(rep(x = 1:6, each = 24), levels = 1:6, labels = 1:6)
datLong$Group <- factor(datLong$Group, levels = 1:3, labels = c("Control",
"Same", "Different"))

str(datLong)
attach(datLong)

cat("Group Means","\n")
cat(tapply(outcome, Group, mean),"\n")
cat("\nInterval Means","\n")
cat(tapply(outcome, Interval, mean),"\n")

# Actual formula and calculation
King.aov <- aov(outcome ~ (Group*Interval) + Error(subject/(Interval)), data = datLong)

# Present the summary table (ANOVA source table)
print(summary(King.aov))

interaction.plot(Interval, factor(Group), outcome, fun = mean, type="b", pch = c(2,4,6),
  legend = "F", col = c(3,4,6), ylab = "Mean of Outcome",)
legend(4, 300, c("Same", "Different", "Control"), col = c(4,6,3), text.col = "green4", lty = c(2, 1, 3), pch = c(4, 6, 2),merge = TRUE, bg = 'gray90')

detach(datLong)
### End ###

