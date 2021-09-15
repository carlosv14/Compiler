using Compiler.Core.Interfaces;

namespace Compiler.Core.Statements
{
    public abstract class Statement : Node, ISemanticValidation, IStatementEvaluate
    {
        public abstract void Evaluate();

        public abstract void ValidateSemantic();
    }
}
