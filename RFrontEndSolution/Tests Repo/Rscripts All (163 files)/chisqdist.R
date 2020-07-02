# Chisq distribution by resampling

par(mfrow = c(2,1))
nreps <- 1000
y <- numeric(250)                                   
result <- numeric(nreps)
for (i in 1:nreps) {
  x <- runif(825,0,1)      # Create a contingency table with about 35% of observations
                           # in row 1 and 8% in column 1. Total sample size = 825.
                           # Rows and columns are independent, so H0 = true.
                           # Then calculate chi-square and repreat nreps times.
  row <- factor(ifelse(x < 0.3442,1,2))
  xx <- runif(825,0,1)
  column <- factor(ifelse(xx < .08,1,2)  )
  table <- table(row,column)
  result[i] <- chisq.test(table, correct = F)$statistic                             
  } 
  ########### 

hist(result, xlim = c(0,10), ylab = "Density",  xlab = "Chi Square",
    main = "Chi Square Distribution \n 1df", yaxt = "n",   probability = T, breaks = 50)

par(new = T) 
  s <- seq(0, 9.9, by = .05)
  y <- dchisq(s,df = 1, ncp = 0)
  # Now overlay chi-square distribution for 1 df
plot(s,y, "l", xlim = c(0,10),  yaxt = "n", col = "red")

arrows(5,.2,3.84,1-pchisq(3.84,1), length = .07, col = "red")
text(6,.25,"3.84, p = .05")
result <- sort(result)
polygon(c(result[result>=3.84],3.84),c(dchisq(result[result >= 3.84],1),0), col = "red")

#--------------------------------------------------------------

# Now repeat the whole thing with a 3 X 4 table
nreps = 1000
result2 <- numeric(nreps) 
pr <- numeric(3); pc <- numeric(4)       # Row and Column probabilities
pr <- c(.2, .3, .5)
pc <- c(.1, .4, .3, .2)
 ### Remove # on next 2 lines to enter your own p values
#print("Enter 3 probabilities summing to 1.00 for rows"); pr = scan(nmax = 3)
#print("Enter 4 probabilities summing to 1.00 for columns"); pc = scan(nmax = 4)
                        
for (i in 1:nreps) {
  x <- runif(825,0,1)      # Create a contingency table with about pr[1]% of observations
                           # in row 1, etc. and rc[1]% in column 1. Total sample size = 825.
                           # Rows and columns are independent, so H0 = true.
  x[x <= pr[1]] <- 1
  x[x <= sum(pr[1]+pr[2])] <- 2
  x[x <1] <- 3                                 
  
  y <- runif(825,0,1)
  y[y <= pc[1]] <- 1
  y[y <= sum(pc[1],pc[2])] <- 2
  y[y <= sum(pc[1],pc[2],pc[3])] <- 3
  y[y < 1] <- 4
  table <- table(x,y) 

  result2[i] <- chisq.test(table, correct = F)$statistic                             
  } 
  ########### 

hist(result2, xlim = c(0,15), ylab = "Density",  xlab = "Chi Square",
    main = "Chi Square Distribution \n 6 df",    probability = T, breaks = 50)

par(new = T) 
  s <- seq(0, 15, by = .01)
  y <- dchisq(s,df = 6, ncp = 0)
  # Now overlay chi-square distribution for 1 df
plot(s,y, "l", xlim = c(0,15),  yaxt = "n", col = "red")

arrows(10,.12,12.59,.03, length = .07, col = "red")
text(10,.125,"12.59, p = .05")
result2 <- sort(result2)
polygon(c(result2[result2>=12.59],12.59),c(dchisq(result2[result2 >= 12.59],6),0), col = "blue")
