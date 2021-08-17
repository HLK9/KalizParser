using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System.IO;
using System.Diagnostics;

namespace ConAntle
{
    class Program
    {
        static void Main(string[] args)
        {
            string asd = Console.ReadLine();
            if (File.Exists(asd)&&Path.GetExtension(asd)==".pas")
            {
                string pascal = File.ReadAllText(asd);
                ICharStream target = new AntlrInputStream(pascal);
                ITokenSource lexer = new pascalLexer(target);
                ITokenStream tokens = new CommonTokenStream(lexer);
                pascalParser parser = new pascalParser(tokens);
                parser.BuildParseTree = true;
                // IParseTree re = parser.forStatement();
                var sd = parser.program();
                Console.WriteLine(sd.ToString());

            }
            else if (File.Exists(asd) && Path.GetExtension(asd) == ".cpp")
            {
                string cplus = File.ReadAllText(asd);
                ICharStream target = new AntlrInputStream(cplus);
                ITokenSource lexer = new CPP14Lexer(target);
                ITokenStream tokens = new CommonTokenStream(lexer);
                CPP14Parser parser = new CPP14Parser(tokens);
                parser.BuildParseTree = true;
                // IParseTree re = parser.forStatement();
                var sd = parser.translationUnit();
                Console.WriteLine(sd.ToString());
            }
            else if (File.Exists(asd) && Path.GetExtension(asd) == ".c")
            {
                string C = File.ReadAllText(asd);
                ICharStream target = new AntlrInputStream(C);
                ITokenSource lexer = new CLexer(target);
                ITokenStream tokens = new CommonTokenStream(lexer);
                CParser parser = new CParser(tokens);
                parser.BuildParseTree = true;
                // IParseTree re = parser.forStatement();
                var sd = parser.translationUnit();
                Console.WriteLine(sd.ToString());
               // Console.WriteLine(parser.argumentExpressionList());
            }




        }
    }
}
