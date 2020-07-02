using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime.Tree;
using RGrammarParser;
using RFrontEnd.ASTComposite;
using RFrontEnd.ASTVisitor.Visitors;
using RFrontEnd.ASTVisitor.Visitors.ASTScopesVisitor;

namespace RFrontEnd
{

    class RFacade{


        /// <summary> This method filter a R file with "RFilter" and parse it with "R"</summary>
        /// <param name="loc"> The R file.</param>
        /// <returns> The number of errors in file (NumberOfSyntaxErrors) at filtering and parsing. </returns>
        static int Parse(string loc)
        {

            // Reads characters from a byte stream in a particular encoding.
            StreamReader reader = new StreamReader(loc);

            // Vacuum all input from a Reader/InputStream and then treat it like a char[] buffer. 
            // Can also pass in a String or char[] to use.              
            AntlrInputStream input = new AntlrInputStream(reader);

            /* A lexer is recognizer that draws input symbols from a character stream. lexer grammars result in a subclass of this object. 
               A Lexer object uses simplified match() and error recovery mechanisms in the interest of speed. 
             */    
            RLexer lexer = new RLexer(input);

            /* This class extends BufferedTokenStream with functionality to filter token streams to tokens on a particular channel(tokens 
             * where Token.getChannel() returns a particular value). This token stream provides access to all tokens by index or when calling 
             * methods like BufferedTokenStream.getText(). The channel filtering is only used for code accessing tokens via the lookahead 
             * methods BufferedTokenStream.LA(int), LT(int), and LB(int). By default, tokens are placed on the default channel(Token.DEFAULT_CHANNEL), 
             * but may be reassigned by using the->channel(HIDDEN) lexer command, or by using an embedded action to call Lexer.setChannel(int). 
             * Note: lexer rules which use the->skip lexer command or call Lexer.skip() do not produce tokens at all, so input text matched by such a 
             * rule will not be available as part of the token stream, regardless of channel.
             * 
             *  A collection of all tokens fetched from the token source. The list is considered a complete view of the input once fetchedEOF is set to true.
             */
            CommonTokenStream tokens = new CommonTokenStream(lexer);

            // Print tokens BEFORE filtering.
            //tokens.Fill(); // Get all tokens from lexer until EOF
            //Console.WriteLine("BEFORE");
            //foreach (IToken tok in tokens.GetTokens())
            //{
            //    Console.WriteLine(tok);
            //    //Console.WriteLine(tok.Text);
            //}

            RFilter filter = new RFilter(tokens);   // Parse with filter.
            filter.stream();                        // Call start rule: stream .
            tokens.Reset();                         // Reset all the token (actually use seek(0) for reuse)

            //Print tokens AFTER filtering.
            //Console.WriteLine("AFTER");
            //foreach (IToken tok in tokens.GetTokens())
            //{
            //    Console.WriteLine(tok);
            //    Console.WriteLine(tok.Text);
            //}

            RParser parser = new RParser(tokens);   // Parse with RParser.
            IParseTree tree = parser.prog();      // Call start rule: prog .

            PTPrinter PTvisitor = new PTPrinter(loc);
            PTvisitor.Visit(tree);

            ASTGenerator ast = new ASTGenerator();
            ast.Visit(tree);

            ASTPrinter ASTVisitor = new ASTPrinter(loc);
            ASTVisitor.Visit(ast.M_Root);

            ASTScopeVisitor astScopeVisitor = new ASTScopeVisitor(loc);
            astScopeVisitor.Visit(ast.M_Root);


            return (parser.NumberOfSyntaxErrors + filter.NumberOfSyntaxErrors);
        }

        /// <summary>  This class open all input filterd R files and call method Parse method for each one of them. </summary>
        /// <param name="directory"> The directory with all R files ( the "Filtered Testbench" Directory).</param>
        /// <returns> The number of errors in all files. </returns>
        static int ParseSubDirectories(string directory)
        {

            int errors = 0; // Errors per file
            int fileerror;  // Total Errors


            Console.WriteLine("Processing directory {0}", directory);

            foreach (string file in Directory.GetFiles(directory))
            {
                Console.WriteLine("Filter & Parsing {0}", Path.GetFileName(file));
                errors += fileerror = Parse(file);
                Console.WriteLine(":{0} errors\n", fileerror);
            }

            foreach (string dir in Directory.GetDirectories(directory))
            {
                errors += ParseSubDirectories(dir);
            }
            return errors;

        }

        static public void Start(string[] args){

            #region Filter and parse R files.
            int i = 0;
            int errors = 0;
            int numOfFiles = 0;

            foreach (string loc in args){

                if (File.Exists(loc)){
                    Console.WriteLine($"Filtering {args[i]}");
                    numOfFiles = 1;
                    int fileerror;
                    errors += fileerror = Parse(loc);
                    Console.Write($":{fileerror} errors");
                }else if (Directory.Exists(loc)){
                   numOfFiles = Directory.GetFiles(loc).Length;
                   errors += ParseSubDirectories(loc);
                } else{
                   Console.WriteLine("File or Directory with the given name <{0}> doesn't exist", loc);
                }
                i++;
            }
            Console.WriteLine($"Total {errors} errors in {numOfFiles} file/s.");         
            #endregion

        }

        static public void SetNodeGraphicalAppearanceColor(NodeType nodeType, Color color)
        {
            RConfigurationSettings.SetNodeCategoryColor(nodeType, color);
        }

    }

}
 