# correlation statistics 

# matrix of correlations (or just the correlation if 2 variables)
cor(meat)

# same using Spearman rank correlation
cor(meat,method='spearman')

# t-test of correlation = 0 and Fisher confidence interval
cor.test(meat$time,meat$ph)
