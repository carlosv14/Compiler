namespace Compiler.Core.Expressions
{
    public class Id : TypedExpression
    {
        public Id(Token token, Type type) : base(token, type)
        {
        }

        public override Type GetExpressionType()
        {
            return type;
        }
    }
}
