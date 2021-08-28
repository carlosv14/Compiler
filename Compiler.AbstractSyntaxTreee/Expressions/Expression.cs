using Compiler.Lexer.Tokens;
namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public abstract class Expression : Node
    {
        protected readonly Type type;

        public Token Token { get; private set; }

        public Expression(Token token, Type type)
        {
            Token = token;
            this.type = type;
        }

        public abstract Type GetExpressionType();
    }
}
