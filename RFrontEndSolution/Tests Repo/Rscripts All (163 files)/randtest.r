# randtest.r  -  very simple code used to generate the 500 randomization
#  samples from the lab 1 exercise.

n <- dim(lab1)[1]
na <- table(lab1$group)[1]

lab1bigd <- lab1bigr <- rep(0,500)

for (i in 1:500) {
  s <- sample(1:n,na); 
  ma <- mean(lab1$Y[s]); 
  mb <- mean(lab1$Y[-s]);
  lab1bigd[i] <- mb - ma;
  lab1bigr[i] <- mb/ma;
  }
  
lab1bigd <- sort(lab1bigd)
lab1bigr <- sort(lab1bigr)
  
  
