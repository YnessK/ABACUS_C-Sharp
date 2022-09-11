namespace Abacus.Token.OperandToken
{
    public  class Operand : Token
    {
        public int Value { get; }

        public Operand(int value)
        {
            this.Value = value;
        }
    }
}