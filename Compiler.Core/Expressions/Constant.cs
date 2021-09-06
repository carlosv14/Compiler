namespace Compiler.Core.Expressions
{
    public class Constant : TypedExpression
    {
        public Constant(Token token, Type type)
            : base(token, type)
        {
        }

        public override Type GetExpressionType()
        {
            return type;
        }
    }
}
