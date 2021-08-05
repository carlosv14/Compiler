using Compiler.Lexer.Tokens;

namespace Compiler.Lexer
{
    public interface IScanner
    {
        Token GetNextToken();
    }
}