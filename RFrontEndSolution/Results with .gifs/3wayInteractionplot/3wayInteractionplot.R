# Three way factorial plots

driving <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab13-14.dat", header = T)
head(driving)
#  A B C DV
#1 1 1 1  4
#2 1 1 1 18
#3 1 1 1  8
#4 1 1 1 10
#5 1 2 1 23
#6 1 2 1 15

colnames(driving) <- c("Experience", "Road", "DayNight", "dv")
# The following gives us a standard two dimensional plot of variable A versus variable C

par(mfrow = c(2,2))

interaction.plot(x.factor = driving$"DayNight", trace.factor = driving$Experience, response = driving$dv,
 fun = mean, legend = F,  type = "l", lwd = 3,ylim = c(5,30),  axes=F,
trace.label="Experience", xlab = "Day vs Night", ylab = "Mean Number Corrections", main = "Two-Way Plot" )
axis(1, at=1:2)
axis(2, at=seq(5,30,5))
text(1.5, 29, "Inexperienced")
text(1.5, 9, "Experienced")

interaction.plot(x.factor = driving$"DayNight", trace.factor = driving$Road, response = driving$dv,
fun = mean, legend = F,  type = "l", lwd = 3,ylim = c(5,30),  axes=F,
trace.label="Road Condition", xlab = "Day vs Night", ylab = "Mean Number Corrections", main = "Two-Way Plot" )
axis(1, at=1:2)
axis(2, at=seq(5,30,5))
text(1.5, 27, "Dirt")
text(1.5, 20, "Second Class")
text (1.5, 10, "First Class")

# Now we will go to a three dimensional plot by first splitting the data by day versus night.
 driving1 <- subset(driving, driving$DayNight == 1)
 driving2 <- subset(driving, driving$DayNight == 2)

#Now we do separate two dimensional plots for Day and then for Night.

interaction.plot(x.factor = driving1$Road, trace.factor = driving1$Experience, response = driving1$dv,
fun = mean, legend = F,  type = "l", lwd = 2,ylim = c(5,40),  axes=F,
trace.label="Experience", xlab = "Road", ylab = "Mean Number Corrections")
title (main = "Day")
axis(1, at=1:3)
axis(2, at=seq(5,40,5))
text(1.5, 22, "Inexperienced")
text(1.5, 9, "Experienced")

interaction.plot(x.factor = driving2$Road, trace.factor = driving1$Experience, response = driving1$dv,
fun = mean, legend = F,  type = "l", lwd = 2,ylim = c(5,40),  axes=F,
trace.label="Experience", xlab = "Road", ylab = "Mean Number Corrections")
title (main = "Night")
axis(1, at=1:3)
axis(2, at=seq(5,40,5))
text(1.5, 22, "Inexperienced")
text(1.5, 9, "Experienced")



