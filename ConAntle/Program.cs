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
            
            string path_File = Console.ReadLine();
            string data = "";
            using (var fs = new FileStream(path_File, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var sr = new StreamReader(fs, Encoding.Default))
            {
                data = sr.ReadToEnd();
            }

            if (File.Exists(path_File)&&Path.GetExtension(path_File)==".pas")
            {
                
                ICharStream target = new AntlrInputStream(data);
                ITokenSource lexer = new pascalLexer(target);
                ITokenStream tokens = new CommonTokenStream(lexer);
                pascalParser parser = new pascalParser(tokens);
                parser.BuildParseTree = true;
                // IParseTree re = parser.forStatement();
                var sd = parser.program();
                Console.WriteLine(sd.ToString());

            }
            else if (File.Exists(path_File) && Path.GetExtension(path_File) == ".cpp")
            {
               
                ICharStream target = new AntlrInputStream(data);
                ITokenSource lexer = new CPP14Lexer(target);
                ITokenStream tokens = new CommonTokenStream(lexer);
                CPP14Parser parser = new CPP14Parser(tokens);
                parser.BuildParseTree = true;
                // IParseTree re = parser.forStatement();
                var sd = parser.translationUnit();
                Console.WriteLine(sd.ToString());
            }
            else if (File.Exists(path_File) && Path.GetExtension(path_File) == ".c")
            {
                
                ICharStream target = new AntlrInputStream(data);
                ITokenSource lexer = new CLexer(target);
                ITokenStream tokens = new CommonTokenStream(lexer);
                CParser parser = new CParser(tokens);
                parser.BuildParseTree = true;
                // IParseTree re = parser.forStatement();
                var sd = parser.compilationUnit();
                Console.WriteLine(sd.ToString());
               // Console.WriteLine(parser.argumentExpressionList());
            }
            else// if (File.Exists(asd) && Path.GetExtension(asd) == ".java")
            {

                return;
                //ICharStream target = new AntlrInputStream(data);
                //ITokenSource lexer = new JavaLexer(target);
                //ITokenStream tokens = new CommonTokenStream(lexer);
                //JavaParser parser = new JavaParser(tokens);
                //parser.BuildParseTree = true;
                //// IParseTree re = parser.forStatement();
                //var sd = parser.compilationUnit();
                //Console.WriteLine(sd.ToString());              

            }




        }
    }
}
