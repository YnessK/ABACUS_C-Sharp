using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using Abacus.Token.FunctionToken;
using Abacus.Token.OperandToken;
using Abacus.Token.OperatorToken;

namespace Abacus.LexicalAnalysis
{
    public class RPN
    {
        //takes an expression of Tokens in parameter and returns the result in int.
        //<param name="expression"> a list of token in rpn
        public static int RPNEvaluate(List<Token.Token> expression)
        {
            Stack<Token.Token> stack = new Stack<Token.Token>();
            
            foreach (Token.Token token in expression)
            {

                if (token is Operand)
                {
                    //TODO modify here the case of comma to determine who is op1 and op2
                    stack.Push(token);
                }

                if (token is Operator)
                {
                    if (stack.Count >= 2)
                    {
                        //TODO modify here the case of comma to determine who is op1 and op2
                        var token1 = (Operator) token;
                        Operand op2 = (Operand) stack.Pop();
                        Operand op1 = (Operand) stack.Pop();
                        Operand res = new Operand(token1.Evaluate(op1.Value, op2.Value));
                        stack.Push(res);
                    }
                    else
                    {
                        Console.Error.WriteLine("Syntax Error");
                        Environment.Exit(2);
                    }
                }

                if (token is Function)
                {
                    switch (token)
                    {
                        case Max :
                            if (stack.Count >= 2)
                            {
                                var token1 = (Function) token;
                                Operand op2 = (Operand) stack.Pop();
                                //TODO modify here the case of comma to determine who is op1 and op2
                                Operand op1 = (Operand) stack.Pop();
                                Operand res = new Operand(token1.Evaluate2(op1.Value, op2.Value));
                                stack.Push(res);
                            }
                            break;
                        case Min :
                            if (stack.Count >= 2)
                            {
                                var token1 = (Function) token;
                                Operand op2 = (Operand) stack.Pop();
                                Operand op1 = (Operand) stack.Pop();
                                Operand res = new Operand(token1.Evaluate2(op1.Value, op2.Value));
                                stack.Push(res);
                            }
                            break;
                        case Gcd :
                            if (stack.Count >= 2)
                            {
                                var token1 = (Function) token;
                                Operand op2 = (Operand) stack.Pop();
                                Operand op1 = (Operand) stack.Pop();
                                Operand res = new Operand(token1.Evaluate2(op1.Value, op2.Value));
                                stack.Push(res);
                            }
                            break;
                        case Sqrt :
                            if (stack.Count >= 1)
                            {
                                var token1 = (Function) token;
                                Operand op1 = (Operand) stack.Pop();
                                Operand res = new Operand(token1.Evaluate1(op1.Value));
                                stack.Push(res);
                            }
                            break;
                        case Facto :
                            if (stack.Count >= 1)
                            {
                                var token1 = (Function) token;
                                Operand op1 = (Operand) stack.Pop();
                                Operand res = new Operand(token1.Evaluate1(op1.Value));
                                stack.Push(res);
                            }
                            break;
                        case Fibo :
                            if (stack.Count >= 1)
                            {
                                var token1 = (Function) token;
                                Operand op1 = (Operand) stack.Pop();
                                Operand res = new Operand(token1.Evaluate1(op1.Value));
                                stack.Push(res);
                            }
                            break;
                        case IsPrime :
                            if (stack.Count >= 1)
                            {
                                var token1 = (Function) token;
                                Operand op1 = (Operand) stack.Pop();
                                Operand res = new Operand(token1.Evaluate1(op1.Value));
                                stack.Push(res);
                            }
                            break;
                        default :
                            Console.Error.WriteLine("Syntax Error");
                            Environment.Exit(2);
                            break;
                    }
                }
            }

            if (stack.Count != 1)
            {
                Console.Error.WriteLine("Syntax Error");
                Environment.Exit(2);
            }
            Operand res1 = (Operand) stack.Pop();
            return res1.Value;
        }
    

        
        
        //RPNTranslate will take in parameter an expression and translate it in RPN. 
        //<param name="expression"> list of tokens translated in rpn
        //The expression will be traveled : operands will be added in a queue and operators in a stack.
        //if precedence of the current operator is <= to the precedent -> operators in stack will move in the queue.
        // we cannot have '(' without ')'  
        //at the end the queue will be reversed to have the expression in the correct order thanks to ToList.

        public static List<Token.Token> RPNTranslate(List<Token.Token> expression)
        {
            Stack<Token.Token> stack = new Stack<Token.Token>();
            Queue<Token.Token> queue = new Queue<Token.Token>();
            
            for (int i = 0; i < expression.Count; i++)
            {
                Token.Token token = expression[i];
                
                if (token is LeftBracket) { stack.Push(token); }
                
                else if (token is Function)
                {
                    if (expression[i+1] is not LeftBracket)
                    {
                        Console.Error.WriteLine("Syntax Error");
                        Environment.Exit(2);
                    }
                    
                    if (token is Max or Min or Gcd)
                    {
                        //TODO if any comma -> error
                        //TO REVIEW
                        if (expression[i] is RightBracket)
                        {
                            Console.Error.WriteLine("Syntax Error"); 
                            Environment.Exit(2);
                        }
                    }
                    
                    stack.Push(token);
                }
                else if (token is RightBracket)
                {
                    while (stack.Count > 0  && stack.Peek() is not LeftBracket)
                    {
                        queue.Enqueue(stack.Pop());
                    }
                    
                    if (stack.Count == 0 || stack.Peek() is not LeftBracket)
                    {
                        Console.Error.WriteLine("Syntax Error");
                        Environment.Exit(2);
                    }
                    else
                    {
                        stack.Pop();
                        if (stack.TryPeek(out var function) && function is Function)
                        {
                            queue.Enqueue(stack.Pop());
                        }
                    }
                } 
                
                else if (token is Operand)
                {
                    queue.Enqueue(token);
                } 
                
                else if (token is Operator)
                {
                    if (stack.Count != 0)
                    {
                        Token.Token ope = stack.Peek();

                        while (ope is Operator and not LeftBracket && 
                               (ope.Precedence > token.Precedence ||
                                (ope.Precedence == token.Precedence && token.Associativity == "left")))
                        {
                            queue.Enqueue(stack.Pop());
                            stack.TryPeek(out ope);
                        }
                    }
                    stack.Push( token);
                }
            }
            
            while (stack.Count>0)
            {
                if (stack.Peek() is LeftBracket or RightBracket)
                {
                    Console.Error.WriteLine("Syntax Error");
                    Environment.Exit(2);
                }
                else
                {
                    queue.Enqueue(stack.Pop());
                }
            }
            return queue.ToList();
        }
    }
}
