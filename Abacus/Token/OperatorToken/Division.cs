using System; 

namespace Abacus.Token.OperatorToken
{
    public  class Division : Operator
    {
        public Division() : base("/", 3, "left", 2) {}

        public override int Evaluate(int op1, int op2)
        {
            if (op2 == 0)
            {
                Console.Error.WriteLine("Runtime Exception : Division by zero");// or 
                Environment.Exit(3);
            }
            return op1 / op2;
        }
    }
}