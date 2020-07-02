# Fisher's Exact Test for tables greater than 2 X 2.

# Uses Example in Table 6.6

datmat <- matrix(c(512, 227, 59, 18, 54, 37, 15, 12), nrow = 4)
chisq.test(datmat, correct = FALSE)
fisher.test(datmat, conf.int = TRUE, simulate.p.value = TRUE)     # conf.int
 #applies only to 2x2 table
 