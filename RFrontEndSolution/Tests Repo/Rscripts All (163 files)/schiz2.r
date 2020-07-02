# R functions to plot data from a block design
#   illustrated using the schiz2 data frame

# code to create schiz2 from the raw data (schiz.txt)
#  is in schiz.r

# plot data, putting pair # on the X axis

# done in two parts: put up the frame, 
#  then use text to label points with the trt
plot(schiz2$pair,schiz2$y,type='n')
text(schiz2$pair,schiz2$y,substring(schiz2$trt,1,1))

# the substring is used to truncate trt names to 1 character

# a plot using the block mean as the X axis

bmean <- tapply(schiz2$y, schiz2$pair, mean)
# easy to compute block means for each block

# the hard part is merging this info with the data
# if blocks are numbered 1, 2, ... I

schiz2$bmean <- bmean[schiz2$pair]

# If they are not sequentially numbered, have to match:
schiz2$bmean <- bmean[match(schiz2$pair,sort(unique(schiz2$pair)))]

# after the data manipulation, plotting is easy

plot(schiz2$bmean,schiz2$y,type='n')
text(schiz2$bmean,schiz2$y,substring(schiz2$trt,1,1))

