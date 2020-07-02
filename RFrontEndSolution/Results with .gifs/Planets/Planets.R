# Distance from the Sun--Table 9.7
par(mfrow = c(2,3))
Rank <- 1:9
Distance <- c(0.39, 0.72, 1, 1.52, 5.20, 9.54, 19.18, 30.06, 39.44)
mass <- c(.055, .815, 1, .107, 317.83, 95.159, 14.536, 17.147, .002)
model1 <- lm( Distance~Rank)
model1
plot(Distance~Rank)
abline(model1)
Residuals <- model1$residuals
plot(Residuals~Rank)
lrf <- loess(Residuals~Rank)
lines(spline(Rank, fitted(lrf)))
lnDist <- log(Distance)
model2 <- lm(lnDist~Rank)
plot(lnDist~Rank)
abline(model2)

resid <- model2$residuals
plot(resid~Rank)
lrf <- loess(resid~Rank)
lines(spline(Rank, fitted(lrf)))

# Now add mass as a predictor
model3 <- lm(lnDist~Rank + mass)
resid3 <- model3$residuals
plot(model3$fitted.values)
abline(model3)
plot(resid3~Rank)
lrf <- loess(resid3~Rank)
lines(spline(Rank, fitted(lrf)))

# Predict distance of Eris from sun
model3 <- lm(log(Distance) ~ Rank)
pred <- model3$coefficients[1] + model3$coefficients[2]*10
pred
preddist <- exp(pred)
cat("The predicted location of a 10th planet would be ",preddist," Astronomical
 Units from the sun.\n")
cat("Eris is 96.7 AU from the sun. Wow!!")



###############################################################################
#Now redo after adding Eris, which is 96.7 AU
# Distance from the Sun--Table 9.7
par(mfrow = c(2,2))
Rank <- 1:10
Distance <- c(0.39, 0.72, 1, 1.52, 5.20, 9.54, 19.18, 30.06, 39.44, 96.7)
model1 <- lm( Distance~Rank)
model1
plot(Distance~Rank)
abline(model1)
Residuals <- model1$residuals
plot(Residuals~Rank)
lrf <- loess(Residuals~Rank)
lines(spline(Rank, fitted(lrf)))
lnDist <- log(Distance)
model2 <- lm(lnDist~Rank)
plot(lnDist~Rank)
abline(model2)

resid <- model2$residuals
plot(resid~Rank)
lrf <- loess(resid~Rank)
lines(spline(Rank, fitted(lrf)))

model3 <- lm(log(Distance) ~ Rank)
pred <- model3$coefficients[1] + model3$coefficients[2]*10
pred
preddist <- exp(pred)
cat("The predicted location of a 10th planet would be ",preddist," Astronomical
 Units from the sun.\n")
cat("Eris is 96.7 AU from the sun. Wow!!")


