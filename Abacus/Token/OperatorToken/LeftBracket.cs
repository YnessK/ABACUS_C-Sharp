namespace Abacus.Token.OperatorToken
{
    public class LeftBracket : Operator
    {
        public LeftBracket() : base("(", 5, " ", 0) {}

        public override int Evaluate(int op1, int op2)
        {
            throw new System.NotImplementedException();
        }
    }
}