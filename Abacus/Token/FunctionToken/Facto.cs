using System;

namespace Abacus.Token.FunctionToken
{
    public  class Facto : Function
    {
        public Facto() : base("facto") {}

        public int Fact(int op1)
        {
            int facto = 1;
            for (int i = 1; i <= op1; i++)
            {
                facto = facto * i;
            }
            return facto;
        }
        
        public override int Evaluate1(int op1)
        {
            if (op1 < 0)
            {
                Console.Error.WriteLine("Invalid operation");
                Environment.Exit(3);
            }
            return Fact(op1);
        }
        
        public override int Evaluate2(int op1, int op2)
        {
            throw new System.NotImplementedException();
        }
    }
}