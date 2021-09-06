using Compiler.Core.Interfaces;

namespace Compiler.Core.Statements
{
    public class Statement : Node, ISemanticValidation
    {
        public Statement()
        {

        }

        public static Statement Null => new Statement();

        public virtual void ValidateSemantic()
        {

        }
    }
}
