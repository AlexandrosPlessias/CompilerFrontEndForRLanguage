# Some stuff for Chapter 9


# This data set is for stress and symptoms
data <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab9-2.dat",header = T)
data$lnSymptoms <- log(data$Symptoms)
head(data)
attach(data)
par(mfrow=c(3,2))

qqnorm(Symptoms, main = "Symptoms")
qqline(Symptoms)

qqnorm(data$lnSymptoms, main=expression(paste(Log[e]," Symptoms")))
qqline(data$lnSymptoms)
qqnorm(data$Stress, main = "Stress")
qqline(data$Stress)
stem(data$Stress)
stem(data$lnSymptoms)
boxplot(data$lnSymptoms, horizontal = T, main = "LnSymptoms")
boxplot(data$Stress, horizontal = T, main = "Stress")
        
options(digits = 7)
cat("Mean Stress = ",mean(Stress), "     st.dev Stress = ",sd(Stress), "\n\n")

#sum(Stress)
#sum(Stress^2)
cat("Mean lnSymptoms = ", mean(lnSymptoms), "     st. dev. lnSymptoms = ", sd(lnSymptoms), "\n\n")

#sum(lnSymptoms)
#sum(lnSymptoms^2)
#sum(Stress*lnSymptoms)
cat("The correlation between Stress and lnSymptoms = ",cor(Stress, lnSymptoms), "\n\n")


par(ask = TRUE)    # You will need to click in upper left to get next graph.

par(mfrow = c(3,2))
reg1 <- lm(lnSymptoms~Stress)
print(summary(reg1))
plot(lnSymptoms~Stress)
abline(reg1)

lrf <- loess(lnSymptoms~Stress)     # Draw a loess line through the data.
plot(lnSymptoms~Stress)
lines(spline(Stress, fitted(lrf)))      # fitted(lrf) is same as lrf$fitted

pred <- predict(reg1)
head(pred,12)
resid <- residuals(reg1)
head(resid,10)
#sum(resid)
#sum(resid^2)

# Cut the Stress variable into 5 intervals
temp <- Stress
cuttemp <- cut(temp, breaks = 5)
cuttemp <- ordered(cuttemp, labels = c("First", "Second", "Third", "Fourth","Fifth"))
par(fin=c(4,3))  #Set the width and height to allow xlabels to fit
plot(lnSymptoms~ cuttemp, xlab = "Quintiles of Stress")

# Now we will get a three dimensional plot of generated data where r = .9
library(MASS)
mu <- c(0,0)
sigma <- matrix(c(1, .9, .9, 1), 2, 2)
multvdata <-  mvrnorm(10000,mu = c(0,0), Sigma = sigma)
colnames(multvdata) <- c("col1","col2")
multvdata <- as.data.frame(multvdata)
attach(multvdata)
f2 <- kde2d(col1, col2, n = 50, h=c(width.SJ(col1),width.SJ(col2)))
persp(f2, phi = 15, theta = 35, d = 1, expand = .3, xlab = "X", box = F )
cat("The actual correlation for these data is ",cor(col1,col2))


# The following is from Maindonald and Braun and plots confidence limits
# on regression estimate
# Plot confidence limits on regression of Symptoms on Stress
# Adopted from Maindonald & Braun, p. 154.


reg <- lm(lnSymptoms~Stress)
summary(reg)
plot(lnSymptoms~Stress, ylab = "Log of Hopkin's Symptom Checklist Score",
   xlab = "Stress Score", pch=16)
abline(reg$coef, lty=1)
xy<-data.frame(Stress=pretty(Stress ,20))
yhat <- predict(reg, newdata=xy, interval="confidence")
ci <- data.frame(lower=yhat[,"lwr"], upper=yhat[,"upr"])
lines(xy$Stress, ci$lower, lty=3, lwd=2, col="black")
lines(xy$Stress, ci$upper, lty=3, lwd=2, col="black")

################ From exploit.R

# This came from Maindonald and Braun, p. 233. It doesn't seem 
# to always work the way I would expect.   I can't get it to pass variables properly.
# I'll leave it as a challenge
        CIcurves <- function(form=lnSymptoms~Stress, data = data, lty=1, col=3,
            newdata = data.frame(Stress=seq(from = 0, to = 80,by = 5 ))) {
          reg.lm <- lm(form, data=data)
          x <- newdata[,all.vars(form)[2]]
           hat <- predict(reg.lm, newdata=newdata, interval="confidence")
          lines(spline(x,hat[, "fit"]))
          lines(spline(x, hat[, "lwr"]),  col=col)
          lines(spline(x, hat[, "upr"]),  col=col)
          }

library(splines)
plot(Symptoms~Stress)
CIcurves(data = data)
CIcurves(form=Symptoms~Stress, data = data)
#The next line fits a spline with 3 knots
CIcurves(form=Symptoms~ns(Stress,3 ), data = data )

# With different variables
plot(lnSymptoms~Stress)
CIcurves(form=lnSymptoms~Stress, data = data)
CIcurves(form=lnSymptoms~ns(Stress,3 ), data = data )
          
# Now to the planets

par(mfrow = c(2,2))
rank <- c(1,2,3,4,5,6,7,8,9)
distance <- c(0.39, 0.72, 1.0, 1.52, 5.20, 9.54, 19.18, 30.06, 39.44)
lm1 <- lm(distance~rank)
plot(distance~rank, xlab = "Rank Distance", ylab = "Distance")
abline(lm1)
resid <- residuals(lm1)
lrf1 <- loess(resid~rank)
plot(resid~rank, xlab = "Rank Distance", ylab = "Residual")
lines(spline(rank, fitted(lrf1)))
lndist <- log(distance)
lm2 <- lm(lndist~rank)
plot(lndist~rank,xlab = "Rank Distance", ylab = "Log Distance")
abline(lm2)
resid2 <- residuals(lm2)

lrf <- loess(resid2~rank)
plot(resid2~rank, xlab = "Rank Distance", ylab = "Residual")
lines(spline(rank, fitted(lrf)))


