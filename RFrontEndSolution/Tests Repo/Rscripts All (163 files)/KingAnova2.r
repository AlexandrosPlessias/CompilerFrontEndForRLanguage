#R for repeated measures
library(car)
data <- read.table(("http://www.uvm.edu/~dhowell/methods8/DataFiles/KingLong.dat"), header = TRUE)
   # Data are already in long form.
####################################################################
# > head(data)                                                     #
#  group subj interval  dv                                         #
#   1     1    1        1 150                                      #
#   2     1    1        2  44                                      #
#   3     1    1        3  71                                      #
#   4     1    1        4  59                                      #
#   5     1    1        5 132                                      #
#   6     1    1        6  74                                      #
####################################################################
attach(data)
kingaov <- aov(outcome~factor(Group)* factor(Interval)+Error(factor(subject)))
print(summary(kingaov))

###########################################################################
#   Error: factor(subj)                                                   #
#                 Df Sum Sq Mean Sq F value Pr(>F)                        #
#   factor(group)  2 285815  142908     7.8 0.0029 **                     #
#   Residuals     21 384722   18320                                       #
#   ---                                                                   #
#   Signif. codes:  0 ‘***’ 0.001 ‘**’ 0.01 ‘*’ 0.05 ‘.’ 0.1 ‘ ’ 1        #
#                                                                         #
#   Error: Within                                                         #
#                                   Df Sum Sq Mean Sq F value Pr(>F)      #
#   factor(interval)                 5 399737   79947   29.85 <2e-16 ***  #
#   factor(group):factor(interval)  10  80820    8082    3.02 0.0022 **   #
#   Residuals                      105 281199    2678                     #
#   ---                                                                   #
#   Signif. codes:  0 ‘***’ 0.001 ‘**’ 0.01 ‘*’ 0.05 ‘.’ 0.1 ‘ ’ 1        #
###########################################################################

interaction.plot(Interval, factor(Group), outcome, type="b", pch = c(2,4,6),
  legend = "F", col = c(3,4,6))
legend(4, 300, c("same", "different", "control"), col = c(4,6,3),
                      text.col = "green4", lty = c(2, 1, 3), pch = c(4, 6, 2),
                      merge = TRUE, bg = 'gray90')


detach(datLong)
