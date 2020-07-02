# Try with metafor
install.packages("metafor")  #Remove "#" for first run
library(metafor)

dat <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab17-2.dat",header = TRUE)
dat2 <- as.data.frame(na.omit(dat))
attach(dat2)

n1 <- n2 <- round(N/2,0)

# Set up new variable names for convenience
d <- ES2
vard <- (n1+n2)/(n1*n2) + d^2/(2*(n1+n2))
SEd <- sqrt(vard)
W <- 1/vard
dbar <- sum(W*d)/sum(W)
vdbar <- 1/sum(W)
SEdbar <- sqrt(vdbar)

CIlower <- dbar - 1.96*SEdbar
CIupper <- dbar + 1.96*SEdbar
cat("mean d = ",dbar,"\n")
cat("Lower limit = ",CIlower, "\n")
cat("Lower limit = ",CIupper, "\n")

Q <- sum(W*d^2)-(sum(W*d)^2/sum(W))
C <- sum(W) - sum(W*d)/sum(W)
df <- length(W)-1
Tsqr <- (Q-df)/C

contrasts(Type) <- c("contr.sum", "contr.poly")
reduced.model <- rma.uni(yi=d, sei = SEd, method = "FE")   #Fixed Model
full.model <- rma.uni(yi = d, sei = SEd, method = "FE", mods = ~factor(Type))
moddiff <- anova.rma.uni(full.model, reduced.model, digits = 4)
# The results look backward, but I'll worry about that later.

moddiff$fit.stats.f
