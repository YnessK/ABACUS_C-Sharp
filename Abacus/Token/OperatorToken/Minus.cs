using System;

namespace Abacus.Token.OperatorToken
{
    public  class Minus : Operator
    {
        public Minus() : base("-", 2, "left", 2) {}
        
        public override int Evaluate(int op1, int op2) { return op1 - op2; }
    }
}