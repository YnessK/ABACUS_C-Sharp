using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Abacus.Token.FunctionToken;
using Abacus.Token.OperandToken;
using Abacus.Token.OperatorToken;

namespace Abacus.LexicalAnalysis
{
    public  class Lexer
    {
        
        // Lexer converts the input in string to a list of tokens while the token is an operand, operator or a function.
        //<param name="str"> input in string
        public static List<Token.Token> Lex(string str)
        {
            List<Token.Token> tokens = new List<Token.Token>();
            for (int i = 0; i < str.Length; i++)
            {
                char elt = str[i];
                switch (elt)
                {
                    case ' ':
                        continue;
                    case ',' :
                        continue;
                        //TODO
                        //Operator comma = new Comma();
                        //tokens.Add(comma);
                        //break;
                    case '(' :
                        ImplicitMult(tokens);
                        Operator leftbracket = new LeftBracket();
                        tokens.Add(leftbracket);
                        break;
                    case ')' :
                        Operator rightbracket = new RightBracket();
                        tokens.Add(rightbracket);
                        break;
                    case '+':
                        if (str[i+1] == '-' || str[i+1] == '+') { Unary(tokens, str,i); }
                        else
                        {
                            Operator addition = new Addition();
                            tokens.Add(addition);
                        }
                        break;
                    case '-':
                        if (str[i+1] == '-' || str[i+1] == '+') { Unary(tokens, str, i); }
                        else
                        {
                            Operator minus = new Minus();
                            tokens.Add(minus);
                        }
                        break;
                    case '*':
                        Operator multi = new Multiplication();
                        tokens.Add(multi);
                        break;
                    case '/':
                        Operator div = new Division();
                        tokens.Add(div);
                        break;
                    case '%':
                        Operator mod = new Modulo();
                        tokens.Add(mod);
                        break;
                    case '^':
                        Operator pow = new Power();
                        tokens.Add(pow);
                        break;
                    default:
                        if (Char.IsLetter(elt))
                        {
                            string func = "";
                            func += elt;
                            while (i < str.Length -1 && char.IsLetter(str[i+1]))
                            {
                                func += str[i+1];
                                i += 1;
                            }
                            switch (func)
                            {
                                case  "fibo" :
                                    tokens.Add(new Fibo());
                                    break;
                                case  "facto" :
                                    tokens.Add(new Facto());
                                    break;
                                case  "isprime" :
                                    tokens.Add(new IsPrime());
                                    break;
                                case  "min" :
                                    tokens.Add(new Min());
                                    break;
                                case  "max" :
                                    tokens.Add(new Max());
                                    break;
                                case  "gcd" :
                                    tokens.Add(new Gcd());
                                    break;
                                case "sqrt" :
                                    tokens.Add(new Sqrt());
                                    break;
                                default :
                                    Console.Error.WriteLine("Invalid operation");
                                    Environment.Exit(3);
                                    break;
                            }
                        }
                        else
                        {
                            string operand = "";
                            operand += elt;
                            while (i < str.Length -1 && char.IsDigit(str[i+1]))
                            {
                                operand += str[i+1];
                                i += 1;
                            }
                            tokens.Add(new Operand( Int32.Parse(operand)));
                        }
                        break;
                }
            }
            return tokens;
        }
        
        
        // This function manage the cases : op1(...) and (...)(...)
        //Called in Lex when a left bracket is met and replaced by the operator '*'
        //<param name="tokens"> a list of tokens with a case of implicit multiplication
        public static void ImplicitMult(List<Token.Token> tokens)
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                Token.Token pre = tokens[tokens.Count - 1];
                if (pre is Operand  || pre is RightBracket)
                {
                    tokens.Add(new Multiplication());
                }
            }
        }
        

        public static void Unary(List<Token.Token> tokens, string str, int i)
        {
            int count = 0;
            while (!Char.IsDigit(str[i]))
            {
                if (str[i] == '-') { count += 1; }
                i++;
            }
            if (Char.IsDigit(str[i]) && count % 2 != 0) { tokens.Add(new Minus()); }
            else { tokens.Add(new Addition()); }
            string operand = "";
            operand += str[i];
            while (i < str.Length -1 && char.IsDigit(str[i+1]))
            {
                operand += str[i+1];
                i += 1;
            }
            tokens.Add(new Operand( Int32.Parse(operand)));
        }
    }
}
