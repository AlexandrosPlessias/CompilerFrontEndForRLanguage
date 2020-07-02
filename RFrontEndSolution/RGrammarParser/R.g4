/*
 [The "BSD licence"]
 Copyright (c) 2017 Alexandros Plessias
 All rights reserved.

 Redistribution and use in source and binary forms, with or without
 modification, are permitted provided that the following conditions
 are met:
 1. Redistributions of source code must retain the above copyright
    notice, this list of conditions and the following disclaimer.
 2. Redistributions in binary form must reproduce the above copyright
    notice, this list of conditions and the following disclaimer in the
    documentation and/or other materials provided with the distribution.
 3. The name of the author may not be used to endorse or promote products
    derived from this software without specific prior written permission.

 THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
 IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
 IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
 INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
 DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
 THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
 (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
 THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
*/


grammar R;

@parser::members {
	public int M_SyntaxErrors{
		get {  return _syntaxErrors;}
	}
}

prog:   (   expressions+=expr (';'|NL) |   NL )* EOF 
    ;

expr:   arraybase=expr '[[' arrayoffset=sublist ']' ']'				#exprIndexingByVectors		// '[[' follows R's yacc grammar
    |   arraybase=expr '['  arrayoffset=sublist ']'					#exprIndexingBasic
    |   left=expr op=('::'|':::') right=expr						#exprSingleDoubleColonsOperators                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
    |   left=expr op=('$'|'@') right=expr							#exprDollarAtOperators		// Indexing tagged lists may be done using  $.
    |   <assoc=right> left=expr '^' right=expr						#exprExponentiationBinary
    |   op=('-'|'+') expr											#exprMinusOrPlusUnary
    |   left=expr ':' right=expr									#exprColonOperator			//It creates the series of numbers in sequence for a vector.
    |   left=expr USER_OP right=expr								#exprWrappedWithPercent		// anything wrapped in %: '%' .* '%'
    |   left=expr op=('*'|'/') right=expr							#exprMultiplicationOrDivisionBinary
    |   left=expr op=('+'|'-') right=expr							#exprMinusOrPlusBinary
    |   left=expr op=('>'|'>='|'<'|'<='|'=='|'!=') right=expr		#exprComparisons
    |   '!' expr													#exprNotUnary
    |   left=expr op=('&'|'&&') right=expr							#exprAndBinary           // Vectorized Or Not Vectorized.
    |   left=expr op=('|'|'||') right=expr							#exprOrBinary            // Vectorized Or Not Vectorized.
    |   '~' expr													#exprTildeUnary          //Used For Model Formulae.
    |   left=expr '~' right=expr									#exprTildeBinary         //Used For Model Formulae.
    |   left=expr op=('<-'|'<<-'|'='|'->'|'->>'|':=') right=expr	#exprAssignmentOpetators // Using leftward or rightward operators.
    |   'function' '(' funargs=formlist? ')' functionbody=expr		#exprDefineFunction      // define function. function ( arglist ) body
    |   funid=expr '(' funargs=sublist ')'							#exprCallFunction        // call function
    |   '{' exprlist '}'											#exprCompound		     // compound statement
    |   'if' '(' ifcond=expr ')' thenbody=expr						#exprIfStatement	
    |   'if' '(' ifcond=expr ')' thenbody=expr 'else' elsebody=expr	#exprIfElseStatement
    |   'for' '(' ID 'in' for_list=expr ')' for_body=expr			#exprFor  
    |   'while' '(' whilecond=expr ')' whilebody=expr				#exprWhile           // Repeat until statement1 evaluates to FALSE.
    |   'repeat' expr												#exprRepeat          // Repeat statement until find break.
    |   '?' expr													#exprHelp		     // Produces the function documentation.
	|   left=expr '?' right=expr									#exprHelpForMethods	 // Looks for the overall methods documentation. 
																						 //I add this exist in gram.y have lowest priority.
    |   'next'														#exprNextStatement
    |   'break'														#exprBreakStatement
    |   '(' expr ')'												#exprParenthesis
    |   ID										#exprID
    |   STRING									#exprSTRING
    |   HEX										#exprHEX
    |   INT										#exprINT
    |   FLOAT									#exprFLOAT
    |   COMPLEX									#exprCOMPLEX
    |   'NULL'									#exprNULL			// NULL is used to indicate the empty object.
    |   'NA'									#exprNA			    // NA is used to for absent data values.
	|	'NA_integer_'							#exprNAInteger	    // NA is used to for absent integer values.
	|	'NA_real_'								#exprNAReal		    // NA is used to for absent	real values.
	|	'NA_complex_'							#exprNAComplex	    // NA is used to for absent complex values.
	|	'NA_character_'							#exprNACharacter	// NA is used to for absent character values.
    |   'Inf'									#exprInf			// Inf denotes infinity.
    |   'NaN'									#exprNaN			// NaN is not-a-number in the IEEE floating point calculus(i.e. 1/0 and 0/0).
    |   'TRUE'									#exprTRUE
    |   'FALSE'									#exprFALSE
;

exprlist
    :   expr ((';'|NL) expr?)*
    |	
    ;

formlist : form (',' form)* ;

form:   ID
    |   ID '=' expr
    ;

sublist : sub (',' sub)*
	;

sub :   expr
	|   ID '='
    |   STRING '='
    |   'NULL' '='
    |
    ;


HEX :  HEXADEMICAL | HEX_FLOATING_CONSTANTS ;

fragment
HEXADEMICAL:   '0' ('x'|'X') HEXDIGIT+ [Ll]? ;

// Hexadecimal floating point constants are supported using C99 syntax, e.g. ‘0x1.1p1’.
// The p separates the base number from the exponent.
// I add this for PR#15753 and PR#15976.
fragment
HEX_FLOATING_CONSTANTS :   '0' ('x'|'X') HEXDIGIT+ ('p'|'P') '-'? HEXDIGIT+ [Ll]? ;

INT :   DIGIT+ [Ll]? ;

fragment
HEXDIGIT : ('0'..'9'|'a'..'f'|'A'..'F') ;

FLOAT:  DIGIT+ '.' DIGIT* EXP? [Ll]?
    |   DIGIT+ EXP? [Ll]?
    |   '.' DIGIT+ EXP? [Ll]?
    ;

fragment
DIGIT:  '0'..'9' ; 

fragment
EXP :   ('E' | 'e') ('+' | '-')? INT ;

COMPLEX
    :   INT 'i'
    |   FLOAT 'i'
    ;

STRING
    :   '"' ( ESC | ~[\\"] )*? '"'
    |   '\'' ( ESC | ~[\\'] )*? '\''
    |   '`' ( ESC | ~[\\'] )*? '`'
	|   '`\\``'	// ## PR#15621 backticks could not be escaped
    ;

fragment
ESC :   '\\' [abtnfrvx"'\\]  // I add x for "fa\xE7ile".   
    |   UNICODE_ESCAPE
    |   HEX_ESCAPE
    |   OCTAL_ESCAPE
    ;

fragment
UNICODE_ESCAPE
    :   '\\' 'u' HEXDIGIT HEXDIGIT HEXDIGIT HEXDIGIT
    |   '\\' 'u' '{' HEXDIGIT HEXDIGIT HEXDIGIT HEXDIGIT '}'
    ;

fragment
OCTAL_ESCAPE
    :   '\\' [0-3] [0-7] [0-7]
    |   '\\' [0-7] [0-7]
    |   '\\' [0-7]
    ;

fragment
HEX_ESCAPE
    :   '\\' HEXDIGIT HEXDIGIT?
    ;

// https://cran.r-project.org/doc/manuals/R-lang.html#Identifiers
ID  :   '.'	// i add this for "reg-tests-1c -> function(.)"
	|	'.' (LETTER|'_'|'.') (LETTER|DIGIT|'_'|'.')*	// gel also special ... and ..DIGIT
    |   LETTER (LETTER|DIGIT|'_'|'.')*
    ;
    
fragment LETTER  : [a-zA-Z] ;

USER_OP :   '%' .*? '%' ;	// Used for special operators (as matrix product, outer product, kronecker product,  mattching etc).

COMMENT :   '#' ~[\r\n]* -> channel(HIDDEN); // I use this non-gready method : http://stackoverflow.com/questions/23976617/parsing-single-line-comments

// Match both UNIX and Windows newlines
NL      :   '\r'? '\n' ;

WS      :   [ \t\u000C]+ -> skip ; // The (-> skip) completely drops the token.