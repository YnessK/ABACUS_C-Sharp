using System;

namespace Abacus.Token.FunctionToken
{
    public class Min : Function
    {
        public Min() : base("min") {}
        
        public override int Evaluate1(int op1)
        {
            throw new NotImplementedException();
        }
        
        public override int Evaluate2(int op1, int op2)
        {
            return Math.Min(op1, op2);
        }
    }
}