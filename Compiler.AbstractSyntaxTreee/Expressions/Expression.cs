using Compiler.Lexer.Tokens;
namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public class Expression : Node
    {
        public Token Token { get; private set; }

        public Type Type { get; set; }

        public Expression(Token token, Type type)
        {
            Token = token;
            Type = type;
        }
    }
}
