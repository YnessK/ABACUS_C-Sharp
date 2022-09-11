using System; 

namespace Abacus.Token.OperatorToken
{
    public  class Comma : Operator
    {
        public Comma() : base(",", 1, "left", 2) {}

        public override int Evaluate(int op1, int op2)
        {
            throw new NotImplementedException();
        }
    }
}