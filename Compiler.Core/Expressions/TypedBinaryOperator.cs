namespace Compiler.Core.Expressions
{
    public abstract class TypedBinaryOperator : TypedExpression
    {
        public TypedBinaryOperator(Token token, TypedExpression leftExpression, TypedExpression rightExpression, Type type)
            : base(token, type)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public TypedExpression LeftExpression { get; }
        public TypedExpression RightExpression { get; }
    }
}
