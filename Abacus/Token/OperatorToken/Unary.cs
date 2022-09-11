namespace Abacus.Token.OperatorToken
{
    public class Unary : Operator
    {
        public Unary() : base("~", 2, "right", 1) {}

        public override int Evaluate(int op1, int op2)
        {
            throw new System.NotImplementedException();
        }
    }
}