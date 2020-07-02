# Compiler Front End For R Language
In the present work we study the structure of the front end of the statistical language R [Version 3.3.2 (2016-10-31)], which consists of a lexical analyzer and two parsers, one acts as grammar filter and the other is the grammar itself. For each input will produce a parse tree, an abstract syntax tree (AST), the illustration of syntax tree, the representation of abstract syntax tree (AST) and a symbol table.

In front end (FE) of the compiler implemented several design patterns, which are object oriented so allow us to easily maintain the code but also the best organization. Finally they made several tests and analyzes on the results in order to have correct both the grammar and the work as a whole.

The dissertation refers to the design of the front end compiler for the R language. The R language has a large user base (about 2 million) and this makes it very interesting in terms of applications in the design of digital systems for acceleration. the processing of its programs. There aren't many reliable R-language development tools on the market, with the exception of RStudio, which I'll cover later. For starters this is a great way to get started.

The most important technical difficulty was "the creation of the R grammar since it was not available somewhere", so it had to be developed from scratch. Appropriate tools such as ANTLR were also used to objectively approach the problem and the C# language to implement the design patterns of the visitor, the observer, the repeater and the façade.
