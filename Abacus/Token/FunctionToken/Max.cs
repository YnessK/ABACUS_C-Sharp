using System;

namespace Abacus.Token.FunctionToken
{
    public  class Max : Function
    {
        public Max() : base("max") {}
        
        public override int Evaluate1(int op1)
        {
            throw new NotImplementedException();
        }
        
        public override int Evaluate2(int op1, int op2)
        {
            return Math.Max(op1, op2);
        }
    }
}