using System;

namespace Abacus.Token.FunctionToken
{
    public class IsPrime : Function
    {
        public IsPrime() : base("isprime") {}

        public static bool _IsPrime(int op1)
        {
            bool prime = false;
            for (int i=2; i<=(int)Math.Sqrt((double)op1); i++)
            {
                if (op1 % i == 0)
                {
                    prime = true;
                    break;
                }
            }
            return !prime;
        }

        // if op1 is prime return 1 else 0
        public int Prime(int op1)
        {
            bool Prime = _IsPrime(op1);
            return Prime ? 1 : 0;
        }
        
        public override int Evaluate1(int op1)
        {
            if (op1 < 0)
            {
                Console.Error.WriteLine("Invalid operation");
                Environment.Exit(3);
            }
            return Prime(op1);
        }
        
        public override int Evaluate2(int op1, int op2)
        {
            throw new NotImplementedException();
        }
    }
}