# A series of graphical plots, from simple to more comples.
# Type "?plot" to see the various optional parameters.
# Using reaction time data from Table 2.1
# IF ASKED TO CONFIRM PAGE CHANGE, CLICK IN U0PPER LEFT OF GRAPHIC
cat("\n \n \n IF ASKED TO CONFIRM PAGE CHANGE, CLICK IN UPPER LEFT OF GRAPHIC \n \n \n")
dat <- read.table(file = "http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab2-1.dat", header = TRUE)
########################################
     #or
     #setwd("C:/Users/Dave/Documents/webs/Methods8/DataFiles/")
     #dat <- read.table(file="Tab2-1.dat", header = TRUE)
########################################

attach(dat)

par(mfrow = c(2,3))   # Plots results in a 2 x 3 grid
par(ask = TRUE)

plot(RxTime) #Plots each observation from trials 1 - n --- Notice slightly increasing trend.

# Variations on Figure 2.1
hist(RxTime, breaks = 500, main = "Individual bins")  #Uses 500 bins to force bin width = 1
hist(RxTime, breaks = 30, main = "30 bins")    # Uses 30 bins to smooth things out

#########################################################################

RxTime.Sorted <- sort(RxTime)  # Place the observations in increasing order for later analyses.

# Now plot with normal distribution  and kernel density plot superimposed
# Plot histogram with probabilities on the ordinate
hist(RxTime.Sorted, breaks = 20, main = "Normal and Kernel \n Density Superimposed", probability = TRUE)
xfit <- seq(min(RxTime.Sorted), max(RxTime.Sorted), length = 50)
yfit <- dnorm(xfit, mean=mean(RxTime.Sorted), sd = sd(RxTime.Sorted))
lines(xfit, yfit, col = "blue")       #Fits normal curve
lines(density(RxTime), col = "red")   #Fits kernel density function

detach(dat)  #Cleaning up
#########################################################################
# Now use a different data set that is clearly bimodal to see diff. in kernel plot

anorexia <- read.table(file = "http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab11-5.dat", header = TRUE)
attach(anorexia)
# Select the cognitive-behavior treatment group
Gain2 <- Gain[Group == "2"]
hist(Gain2, breaks = 20, main = "Normal and Kernel \n Density Superimposed", probability = TRUE)
xfit <- seq(min(Gain2), max(Gain2), length = 50)
yfit <- dnorm(xfit, mean=mean(Gain2), sd = sd(Gain2))
lines(xfit, yfit, col = "blue")       #Fits normal curve
lines(density(Gain2), col = "red")   #Fits kernel density function

#########################################################################

# The following is an alternative way to do it using a function that we create
# named add.norm   Remove "#" to run

#add.norm<- function(m, s, r, lty=5,lwd=2)    #First create the function to be used below.
#  {
#  #
#  # adds normal density to a histogram or other plot
#  # m is mean, s is sd, r is range (optional)
#  #
#          if(missing(r) || length(r) != 2) r <- c(m - 3 * s, m + 3 * s)
#          x <- seq(r[1], r[2], length = 200)
#          y <- dnorm(x, m, s)
#          lines(x, y, lty=lty,lwd=lwd)
#  }
#
#  hist(RxTime,freq=FALSE)    # Same as probability = TRUE
#  	m <- mean(RxTime)
#  	s <- sd(RxTime)
#  	add.norm(m,s)      # Call the function above supplying it with m and s.
#

#####################################################################

# Now we will create a boxplot for the Everitt data combined across groups
par(mfrow = c(2,3))
par(ask = TRUE)
rm(Gain)         # Don't confuse it with an earlier variable
anorexia <- read.table(file = "http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab11-5.dat", header = TRUE)
attach(anorexia)
boxplot(Gain, data = anorexia , main = "Combined Data", ylab = "Weight Gain")

# Supply some nice group labels
Group.named <- factor(Group, levels = c(1, 2, 3), labels = c("Control", "Cog-Behav", "Family"))
boxplot(Gain~Group.named, data = anorexia, main = "Data by Group", ylab = "Weight Gain",
names = c("Control","Cog-Behav", "Family"))

######################################################################

# Stem-and-leaf displays

# Notice that the result is as printout rather than drawn on a graph
stem(Gain)  #From anorexia data
attach(dat)  #Make first data set available
stem(RxTime) #From Reaction Time data




#Figure 8.2 but with means at 50 and 60 with sd = 10


 par(fin = c(5,5))  # Adjust the size of the graphic so that it looks nice.
 x0 <- seq(-4,4,by =.01)   # X = -4, -3.9, ...+4
 ht<- dnorm(x0)
 xx0 <- x0*10+50
 plot(xx0, ht, type="l",  ylab="density", yaxt="s", xlab="Dependent Variable", xlim = c(10,90))
polygon(c(xx0[xx0>=1.645*10+50], 1.645*10+50), c(dnorm(x0[x0 >= 1.645]), 0), col = "gray")
 arrows(50, 0.02,66.45, 0.002, length = .125)
 text(49.0, 0.035, "z = +1.645")
 text(72, 0.30, substitute(beta))
 arrows(70, .30,57, 0.25, length = .125)
text(45, .40, expression(H[0])  )
 abline(v=50)

 par(new = TRUE)
#Figure 8.4
 x1 <- seq(-4,4,by =.1)
 x11 <- x1*10+60
 ht1<- dnorm(x1)
 plot(x11, ht1, type="l",   xlab = " ",yaxt="n", xlim = c(10,90))
 polygon(c(x11[x11<=1.645*10+50], 1.645*10+50), c(dnorm(x1[x1<=0.645]), 0), density = 15)
 arrows(75, 0.05,70, 0.0079, length = .125)
 text(76, 0.05, substitute(alpha))
 arrows(80,.1,70,.1, length = .065)
 text(82,.12,"Power")
text(67.75, .40, expression(H[1])  )
abline(v=60)
