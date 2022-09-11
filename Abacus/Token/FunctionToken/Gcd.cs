using System;

namespace Abacus.Token.FunctionToken
{
    public  class Gcd : Function
    {
        public Gcd() : base("gcd") {}

        public static int gcd(int op1,int op2)
        {
            op1 = Math.Abs(op1);
            op2 = Math.Abs(op2);
            int res = op1 % op2;
            return res == 0 ? op2 : gcd(op2, res);
        }

        public override int Evaluate1(int op1)
        {
            throw new NotImplementedException();
        }

        public override int Evaluate2(int op1, int op2)
        {
            return gcd(op1, op2);
        }
    }
}