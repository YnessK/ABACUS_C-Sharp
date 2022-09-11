using System;

namespace Abacus.Token.OperatorToken
{
    public class Power : Operator
    {
        public Power() : base("^", 4, "right", 1)
        {
        }

        public override int Evaluate(int op1, int op2)
        {
            return (int) Math.Pow(op1, op2);
        }
    }
}