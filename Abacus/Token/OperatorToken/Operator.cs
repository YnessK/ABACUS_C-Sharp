namespace Abacus.Token.OperatorToken
{
    public abstract class Operator : Token
    {
    public string Symbole { get; set; }
     // Precedences : ^ : 4    * and / and %  : 3     + and - : 2
     // Associativity : left or right
    public int Arity; // 2

    public abstract int Evaluate(int op1, int op2);

    protected Operator(string symbole, int precedence, string associativity, int arity)
    {
        this.Arity = arity;
        this.Associativity = associativity;
        this.Precedence = precedence;
        this.Symbole = symbole;
    }
    }
}