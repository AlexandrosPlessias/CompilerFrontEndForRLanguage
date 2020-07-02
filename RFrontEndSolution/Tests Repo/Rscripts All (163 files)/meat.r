# read the data
meat <- read.table('meat.txt',header=T,as.is=T)

# and create a log time variable
meat$logtime <- log(meat$time)

# set up a new data set with points to make predictions at
meat.new <- data.frame(time=seq(1,5,0.5))
meat.new$logtime <- log(meat.new$time)

# fit the regression, logtime is NOT a factor
meat.lm <- lm(ph~logtime,data=meat)

# print a summary.  There are also functions to print
#  coefficients, coef(), and anova table (anova()

summary(meat.lm)

# make predictions at each point in the original data set
meat.pred <- predict(meat.lm)

# make predictions at each point in the new data set
# returns a vector, convenient for plotting
meat.pred <- predict(meat.lm,newdata=meat.new)
meta.pred

# include se.fit with the predictions, returns a list
meat.pred <- predict(meat.lm,newdata=meat.new,se.fit=T)
meat.pred

# additional arguments to predict provide intervals
#  either confidence intervals
meat.pred <- predict(meat.lm,newdata=meat.new,interval='confidence')
meat.pred

# or prediction intervals
meat.pred <- predict(meat.lm,newdata=meat.new,interval='prediction')
meat.pred

# matplot is convenient for plotting these
matplot(meat.new$logtime,meat.pred,type='l',lty=c(1,2,2),col=c(1,2,2))

# the ANOVA lack of fit test is easy to do in R.  
# The appropriate F test is the test of the as.factor(X) term

# doing lof test when X = time
meat.lof <- lm(ph~time+as.factor(time),data=meat)
anova(meat.lof)

# doing lof test and again when X = log(time)
meat.lof <- lm(ph~logtime+as.factor(time),data=meat)
anova(meat.lof)
