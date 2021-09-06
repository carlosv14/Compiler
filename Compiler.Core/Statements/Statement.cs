using Compiler.Core.Interfaces;

namespace Compiler.Core.Statements
{
    public abstract class Statement : Node, ISemanticValidation
    {
        public abstract void ValidateSemantic();
    }
}
