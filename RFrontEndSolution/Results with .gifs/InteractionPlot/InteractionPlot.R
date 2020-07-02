data <- read.table(file.choose(), header = TRUE)     # Sec13-5.dat or Spilich.dat
head(data)
attach(data)
Task <- factor(Task, levels = c(1, 2, 3), labels = c("PattReg", "Cognitive", "Driving"))
Smkgrp <- factor(Smkgrp, levels = c(1,2,3), labels = c("Nonsmoking", "Delayed", "Active"))
interaction.plot(x.factor = SmokeGrp, trace.factor = Task, response = Errors, fun = mean, legend = TRUE)
