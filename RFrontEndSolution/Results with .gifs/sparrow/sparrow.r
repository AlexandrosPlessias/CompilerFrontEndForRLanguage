sparrow <- read.table('sparrow.txt',as.is=T,header=T)

# create new variable lhumerus with the log of the humerus
sparrow$lhumerus <- log(sparrow$humerus)

# traditional equal variance t-test
t.test(sparrow$humerus[sparrow$fate=='died'],
       sparrow$humerus[sparrow$fate=='alive'], 
       var.equal=T)

# formula interface to same test, explicitly indicating a factor
t.test(humerus~as.factor(fate), data=sparrow, var.equal=T)

# if omit var.equal, get Welch t-test (discussed next week)
