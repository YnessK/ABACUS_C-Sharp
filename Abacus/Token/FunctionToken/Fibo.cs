using System;

namespace Abacus.Token.FunctionToken
{
    public class Fibo : Function
    {
        public Fibo() : base("fibo") {}

        public override int Evaluate1(int op1)
        {
            if (op1 < 0)
            {
                Console.Error.WriteLine("Invalid operation");
                Environment.Exit(3);
            }
            return Fib(op1);
        }
        static int Fib(int op1)
        {
            int first = 0;
            int second = 1;
            int res = 0;
            if (op1 == 0) return 0; 
            if (op1 == 1) return 1; 
            for (int i = 2; i<= op1; i++)  
            {
                res = first + second;
                first = second;
                second = res;
            }
            return res;
        }
        
        public override int Evaluate2(int op1, int op2)
        {
            throw new System.NotImplementedException();
        }
    }
}