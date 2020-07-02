#  Plotting and computing Box Cox transformation

# using the judges data as an example
judges <- read.table('c:/philip/stat500/data/judges.txt',as.is=T,header=T)

# calculate the mean for each group
#  syntax for tapply is Y variable, grouping variable, function to apply to each group

jmean <- tapply(judges$percent,judges$judge,mean)

# repeat to get sd for each group
jsd <- tapply(judges$percent,judges$judge,sd)

# plot them, using a log scale for X and Y
plot(jmean,jsd,log='xy')

# calculate the regression slope
lm(log(jsd) ~ log(jmean))
