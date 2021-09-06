using Compiler.Core.Statements;

namespace Compiler.Core.Interfaces
{
    public interface IParser
    {
        Statement Parse();
    }
}