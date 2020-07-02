# Plot confidence limits on regression of Symptoms on Stress
# Adapted from Maindonald & Braun, p. 154.
# See the bottom of this program for a much simpler way to run it.
data <- read.table(file.choose(), header=T)   # You want Table 9-2.dat
attach(data)
reg <- lm(lnSymptoms~Stress)
summary(reg)
plot(lnSymptoms~Stress, ylab = "Ln(Hopkin's Symptom Checklist Score)", xlab = "Stress Score", pch=16)
abline(reg$coef, lty=1)
N <- length(lnSymptoms)
df = N-2
# First get SE for confidence interval on mean
se.mean <- predict(reg, se.fit = TRUE)
se.mean$se.fit
# Now get SE for confidence interval on prediction
se.pred <- sqrt(se.mean$se.fit^2 + se.mean$residual.scale^2)
se.pred
a <- reg$coeff[1]
b <- reg$coef[2]
print(a)
print(b)
yhat <- predict(reg)


cimeanlower <- yhat + qt(0.025,df)*se.mean$se.fit
cimeanupper <- yhat + qt(0.9755,df)*se.mean$se.fit


cipredlower <- yhat + qt(0.025,df)*se.pred
cipredupper <- yhat + qt(0.9755,df)*se.pred
#Get them in order so that I can draw smooth lines
 cis <- data.frame(Stress, cimeanlower, cimeanupper, cipredlower, cipredupper, lnSymptoms)
 newdata <- cis[order(Stress),]
lines(newdata$Stress,newdata$cimeanlower, lty=1, lwd=3, type = "l",col="gray")
lines(newdata$Stress,newdata$cimeanupper, lty=1, lwd=3,type = "l", col="gray")
lines(newdata$Stress,newdata$cipredlower, lty=2, lwd=3,type = "l", col="red")
lines(newdata$Stress,newdata$cipredupper, lty=2, lwd=3,type = "l", col="red")
text(6, 4.55,"Prediction Interval")
arrows(11.88,4.73,11.88, 4.07, code = 3)

text( 50.25,4.70,"CI for array mean")
arrows(45.25, 4.77, 45.25, 4.61, code = 3)
################ From exploit.R

#Doing it the simple way.
# The code above works just fine, but someone wrote a function called asbio, which 
# can be downloaded using "packages/install package(s)" from the R Console.
  
library(asbio)      
x <- data$Stress
y <- data$lnSymptoms
plotCI.reg(x,y)

# The following is the function that was written within asbio. Because you
# have loaded that library, the function already exists, and you don't
# have to code it. I show it only for completeness. 
# Notice that using this function I only have to load the data, define x and y,
# and call the function using x and y. This would create about a five line program
# instead of the one that I created above. What could be simpler?

# The following is commented out because it is only for show.
#plotCI.reg <- function (x, y, conf = 0.95, CI = TRUE, PI = TRUE, reg.col = 1, 
#    CI.col = 2, PI.col = 4, reg.lty = 1, CI.lty = 2, PI.lty = 3, 
#    reg.lwd = 1, CI.lwd = 1, ...) 
#{
#    lm.temp <- lm(y ~ x)
#    CI <- predict(lm.temp, level = conf, interval = "conf")
#    PI <- predict(lm.temp, level = conf, interval = "prediction")
#    min.max.Y <- c(min(y, PI[, 2]), max(y, PI[, 3]))
#    plot(x, y, ylim = min.max.Y, ...)
#    abline(lm(y ~ x), lty = reg.lty, lwd = reg.lwd, col = reg.col)
#    o <- order(x)
#    lines(x[o], CI[, 2][o], col = CI.col, lty = CI.lty, lwd = CI.lwd)
#    lines(x[o], CI[, 3][o], col = CI.col, lty = CI.lty, lwd = CI.lwd)
#    lines(x[o], PI[, 2][o], col = PI.col, lty = PI.lty, lwd = CI.lwd)
#    lines(x[o], PI[, 3][o], col = PI.col, lty = PI.lty, lwd = CI.lwd)
#    summary(lm.temp)
#    return(o)
#}
#plotCI.reg(x,y)
