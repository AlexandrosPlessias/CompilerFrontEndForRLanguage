
# Chapter 11 analyses
# Run the basic Anova

# install(car)   #Delete this after first use.
library(car)   #Loads special ANOVA functions and data
setwd("C:\\Users\\Dave\\Documents\\Methods8\\Chapters\\Chapter11")

recall <- c(9,8,6,8,10,4,6,5,7,7,
            7,7,6,6,6,11,6,3,8,7,
            11,13,8,6,14,11,13,13,10,11,
            12,11,16,11,9,23,12,10,19,11,
            10,19,14,5,10,11,14,15,11,11)
cond <- factor(rep(1:5, each=10))
eysenck <-data.frame(cond, recall)
levels(eysenck$cond) <- c("Counting","Rhyming","Adjective","Imagery","Intention")
head(eysenck,25)   #Prints out the first 25 cases of the data
options(contrasts = c("contr.sum","contr.poly"))

model1 <- lm(recall~cond, data = eysenck)
Anova(model1, type = "III")
# Sampling Distribution of F for Eysenck with Equal Means
nreps <- 10000
Fdist <- numeric(nreps)
group <- factor(rep(1:5, each = 10))
for (i in 1:nreps) {
  grp1 <- rnorm(10, 10.06, 1.83)
  grp2 <- rnorm(10, 10.06, 2.13)
  grp3 <- rnorm(10, 10.06, 2.49)
  grp4 <- rnorm(10, 10.06, 4.50)
  grp5 <- rnorm(10, 10.06, 3.74)
  dv <- c(grp1, grp2, grp3, grp4, grp5)
  model <- anova(lm(dv~group))
  Fdist[i] <- model$"F value" 
  }
  par(mfrow = c(1,1)) 
  hist(Fdist, breaks = 50,font.lab = 3, font.main = 3,xlab = "F  (df = 4,45)", 
    ylab = "Relative Frequency", yaxt = "n", density = 10, main = "F distribution")
    box (col = "grey")
  arrows(9.08, 300,9.08,0, length = .1) 
  text(9, 340, font = 3,"F = 9.08")
  