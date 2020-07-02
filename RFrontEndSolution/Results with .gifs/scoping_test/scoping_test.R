d =2;

k <- function (){
  y <- 5
  
  f <- function() {
    
    g <- function(x) {
      d = d-1;
      cat("d = ",d)
      
      if ( d < 3){ k() }
      else{ f() }
      
      result = x+y;
      cat("\nresult = ",result)
      return (g)
    }
    
    return(g)
  }
  
  return (f) 
}

m = 45;

xx <- k()  # xx points to f
xxx <- xx() #xxx points to g
xxxx <-xxx(3)

