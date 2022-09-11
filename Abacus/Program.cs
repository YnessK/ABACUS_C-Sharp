using System;
using System.Collections.Generic;
using Abacus.LexicalAnalysis;
using Abacus.Token.FunctionToken;
using Abacus.Token.OperandToken;
using Abacus.Token.OperatorToken;

namespace Abacus
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                var token = Lexer.Lex(Console.ReadLine());
                var rpn = RPN.RPNTranslate(token);
                Console.WriteLine(RPN.RPNEvaluate(rpn));
                return 0;
            }

            else if (args.Length == 1 && args[0] == "--rpn")
            {
                var rpn = Lexer.Lex(Console.ReadLine());
                Console.WriteLine(RPN.RPNEvaluate(rpn));
                return 0;
            }
            else
            {
                Console.Error.WriteLine("Unknown Argument ");
                return 1;
            }
            
        }
    }
}
