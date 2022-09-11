using System;

namespace Abacus.Token.FunctionToken
{
    public class Sqrt : Function
    {
        public Sqrt() : base("sqrt") {}
        
        public override int Evaluate1(int op1)
        {
            if (op1 < 0)
            {
                Console.Error.WriteLine("Invalid operation");
                Environment.Exit(3);
            }
            return (int) Math.Sqrt(op1);
        }
        
        public override int Evaluate2(int op1, int op2)
        {
            throw new NotImplementedException();
        }
    }
}