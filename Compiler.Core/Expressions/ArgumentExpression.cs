namespace Compiler.Core.Expressions
{
    public class ArgumentExpression : BinaryOperator
    {
        public ArgumentExpression(Token token, TypedExpression leftExpression, TypedExpression rightExpression)
            : base(token, leftExpression, rightExpression, null)
        {

        }

        public ArgumentExpression(Token token, TypedExpression leftExpression)
            : base(token, leftExpression, null, null)
        {

        }

        public override string Generate()
        {
            if (RightExpression != null)
            {
                return $"{LeftExpression.Generate()} {Token.Lexeme} {RightExpression.Generate()}";
            }

            return LeftExpression.Generate();
        }
    }
}
