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

/* 
	Always parse R files with filter before grammar parse.
    We strip NL inside expressions.
 */

parser grammar RFilter;

options { tokenVocab=R; }

stream : (elem|NL|';')* EOF ;	

eat :   (NL {((IWritableToken)$NL).Channel = TokenConstants.HiddenChannel;} )+ ;

elem:   op eat?
    |   atom
    |   '{' eat? (elem|NL|';')* '}'
    |   '(' (elem|eat)* ')'	
    |   '[' (elem|eat)* ']'
    |   '[[' (elem|eat)* ']' ']'
    |   'function' eat? '(' (elem|eat)* ')' eat?
    |   'for' eat? '(' (elem|eat)* ')' eat?
    |   'while' eat? '(' (elem|eat)* ')' eat?
    |   'if' eat? '(' (elem|eat)* ')' eat?
    |   'else' eat? {

		/* 10.4.5 Flow control elements (from R-lang manual)
		R contains the following control structures as special syntactic constructs
		if ( cond ) expr
		if ( cond ) expr1 else expr2
		-> The expressions in these constructs will typically be compound expressions. 	
		*/	

		/*
		And the "input" attribute from the abstract class Parser (which your 
		generated parser extends from) now has an underscore ("_input") in front of it.
		Lt(-2) : Predicates minus 2 positions/tokens from current.
		*/

        IWritableToken tok = (IWritableToken) _input.Lt(-2); 
        if ( ((IToken)tok).Type.Equals(NL))	// (if (_input.Lt(-2) == NL) ) 
			tok.Channel= TokenConstants.HiddenChannel; 
			// I set the token's Channel from Default to HiddenChannel.
			// Anything on different channel than DEFAULT_CHANNEL is not parsed by parser.
        }
    ;

atom:   'next' | 'break' | ID | STRING | HEX | INT | FLOAT | COMPLEX | 'NULL'
    |   'NA' | 'NA_integer_' | 'NA_real_' | 'NA_complex_' |'NA_character_'| 'Inf' 
	| 'NaN' | 'TRUE' | 'FALSE'
    ;


op  :   '+'|'-'|'*'|'/'|'^'|'<'|'<='|'>='|'>'|'=='|'!='|'&'|'&&'|USER_OP|
        'repeat'|'in'|'?'|'!'|'='|':'|'~'|'$'|'@'|'<-'|'<<-'|'->'|'->>'|'='|'::'|':::'|
        ','|'||'| '|'
    ;