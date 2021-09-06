namespace Compiler.Core.Expressions
{
    public class RelationalExpression : TypedBinaryOperator
    {
        public RelationalExpression(Token token, TypedExpression leftExpression, TypedExpression rightExpression)
            : base(token, leftExpression, rightExpression, null)
        {
        }

        public override Type GetExpressionType()
        {
            return Type.Bool;
        }
    }
}
