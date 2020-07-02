# Calculate descriptive statistics on data

# install.packages("psych")   # Remove "#" for first run
library(psych)                # Package of functions applicable to Psychology

datapsych <- read.table("http://www.uvm.edu/~dhowell/methods8/DataFiles/Tab2-1.dat", header = TRUE)

### Alternative ways to read data
#datapsych <- read.table("C:/Users/Dave/Documents/Webs/methods8/DataFiles/Tab2-1.dat")
# or, combine the next two lines
#setwd("C:/Users/Dave/Documents/webs/Methods8/DataFiles/")
#datapsych <- read.table("Tab2-1.dat")


head(datapsych)
attach(datapsych)
# Type ?describe to see the options for the describe command
output <- describe(RxTime)
print(output)
hist(RxTime)
