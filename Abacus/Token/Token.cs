namespace Abacus.Token
{
    public abstract class Token
    {
        public int Precedence { get; set; }
        public string Associativity { get; set; } // left or right
    }
    
}