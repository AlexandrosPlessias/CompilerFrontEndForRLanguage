

# Goal: To read in a simple data file, and look around it's contents.

# Suppose you have a file "x.data" which looks like this:
#        1997,3.1,4
#        1998,7.2,19
#        1999,1.7,2
#        2000,1.1,13
# To read it in --

A <- read.table("x.data", sep=",",
                col.names=c("year", "my1", "my2"))
nrow(A)                                 # Count the rows in A

summary(A$year)                         # The column "year" in data frame A
                                        # is accessed as A$year

A$newcol <- A$my1 + A$my2               # Makes a new column in A
newvar <- A$my1 - A$my2                 # Makes a new R object "newvar"
A$my1 <- NULL                           # Removes the column "my1"

# You might find these useful, to "look around" a dataset --
str(A)
summary(A)
library(Hmisc)          # This requires that you've installed the Hmisc package
contents(A)
describe(A)



# Goal: To read in a simple data file where date data is present.

# Suppose you have a file "x.data" which looks like this:
#        1997-07-04,3.1,4
#        1997-07-05,7.2,19
#        1997-07-07,1.7,2
#        1997-07-08,1.1,13

A <- read.table("x.data", sep=",",
                col.names=c("date", "my1", "my2"))
A$date <- as.Date(A$date, format="%Y-%m-%d")
       # Say ?strptime to learn how to use "%" to specify
       # other date formats. Two examples --
       # "15/12/2002"  needs "%d/%m/%Y"
       # "03 Jun 1997" needs "%d %b %Y"

       # Actually, if you're using the ISO 8601 date format, i.e.
       # "%Y-%m-%d", that's the default setting and you don't need to
       # specify the format.

A$newcol <- A$my1 + A$my2               # Makes a new column in A
newvar <- A$my1 - A$my2                 # Makes a new R object "newvar"
A$my1 <- NULL                           # Delete the `my1' column
summary(A)                              # Makes summary statistics

