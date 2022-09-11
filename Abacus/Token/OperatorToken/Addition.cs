namespace Abacus.Token.OperatorToken
{
    public  class Addition : Operator
    {
        public Addition() : base("+", 2, "left", 2){}
        public override int Evaluate(int op1, int op2) { return op1 + op2; }
    }
}