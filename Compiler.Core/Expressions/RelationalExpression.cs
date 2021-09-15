using System;

namespace Compiler.Core.Expressions
{
    public class RelationalExpression : TypedBinaryOperator
    {
        public RelationalExpression(Token token, TypedExpression leftExpression, TypedExpression rightExpression)
            : base(token, leftExpression, rightExpression, null)
        {
        }

        public override dynamic Evaluate()
        {
            return Token.TokenType switch
            {
                TokenType.GreaterThan => LeftExpression.Evaluate() > RightExpression.Evaluate(),
                TokenType.LessThan => LeftExpression.Evaluate() < RightExpression.Evaluate(),
                TokenType.GreaterOrEqualThan => LeftExpression.Evaluate() >= RightExpression.Evaluate(),
                TokenType.LessOrEqualThan => LeftExpression.Evaluate() <= RightExpression.Evaluate(),
                TokenType.Equal => LeftExpression.Evaluate() == RightExpression.Evaluate(),
                TokenType.NotEqual => LeftExpression.Evaluate() != RightExpression.Evaluate(),
                _ => throw new NotImplementedException()
            };
        }

        public override Type GetExpressionType()
        {
            return Type.Bool;
        }
    }
}
