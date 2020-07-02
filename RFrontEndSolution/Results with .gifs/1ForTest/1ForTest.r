
# examples from filter...

#Works here:
if (1==0) { print(1) } else { print(2) }

#and correctly gets error here:
if (1==0) { print(1) }
 else { print(2) }

#this works too:
if (1==0) {
	if (2==0) print(1)
        else print(2)
}

# example from any-all.r

if (is.list(input))
    do.call(f, c(input, list(na.rm = na.rm)))
else 
	f(input, na.rm = na.rm)
			