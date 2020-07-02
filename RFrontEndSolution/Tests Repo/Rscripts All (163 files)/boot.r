# boot.r  -  very simple code used to generate the 500 bootstrap
#  samples from the lab 1 exercise.


lab2bigd <- lab2bigr <- rep(0,500)
a <- lab1$Y[1:10]    # data from group A
b <- lab1$Y[11:20]   # data from group B

for (i in 1:500) {
   ma <- mean(sample(a,10,repl=T));
   mb <- mean(sample(b,10,repl=T))
   
   lab2bigd[i] <- mb - ma;
   lab2bigr[i] <- mb/ma;
   }
   
lab2bigd <- sort(lab2bigd)
lab2bigr <- sort(lab2bigr)
  
     