namespace Abacus.Token.OperatorToken
{
    public  class Multiplication : Operator
    {
        public Multiplication() : base("*", 3, "left", 2) {}
        
        public override int Evaluate(int op1, int op2) { return op1 * op2; }
    }
}