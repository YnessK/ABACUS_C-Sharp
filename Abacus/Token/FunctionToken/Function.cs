namespace Abacus.Token.FunctionToken
{
    public abstract class Function : Token
    {
        public string Name;

        public Function(string name)
        {
            this.Name = name;
        }
        public abstract int Evaluate1(int op1);
        
        public abstract int Evaluate2(int op1, int op2);

    }
}