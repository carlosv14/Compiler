using Compiler.Core.Interfaces;

namespace Compiler.Core.Expressions
{
    public abstract class TypedExpression : Expression, IExpressionEvaluate
    {
        public TypedExpression(Token token, Type type)
            : base(token, type)
        {
        }

        public abstract dynamic Evaluate();

        public abstract Type GetExpressionType();
    }
}
