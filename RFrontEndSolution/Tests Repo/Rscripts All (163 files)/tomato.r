# I am assuming that you have used FileChange Dir to set the
#   appropriate working directory

tomato - read.table('tomato.txt',as.is=T,header=T)
#  header=T says that the first line contains variable names
#  as.is suppresses conversion of character strings to factors
#     It is not required to read the file.
#     I prefer to do that conversion explicitly when needed
#     Others prefer factors.

print(tomato)
#  print the contents of the data frame
#  If you are working at the console, you can omit the print()

tomato2 - tomato[tomato$group==1,]
#  subset the tomato data frame

print(summary(tomato2))
#  print a short summary of the data set from the console
#  if executing the file, need print(summary(tomato2))

# on-the fly subsetting, equivalent of where in SAS
print(summary(tomato[tomato$group==1,]))

# by group processing
by(tomato,tomato$group,summary)

# below are graphics produced using the base R package
#  the lattice package provides another approach

hist(tomato2$yield)
# a histogram of the tomato2 yield

par(mfrow=c(2,1))
by(tomato$yield,tomato$group,hist)
# histograms of both groups arranged one below the other

par(mfrow=c(1,1))
boxplot(split(tomato$yield,tomato$group))
#  a boxplot with groups side-by-side

plot(as.factor(tomato$group),tomato$yield)
# a dotplot of the observations in each group
# converting the group to a factor provides a nice plot
#   even if group is a character string
#
