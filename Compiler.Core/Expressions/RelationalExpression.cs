using System;
using System.Collections.Generic;

namespace Compiler.Core.Expressions
{
    public class RelationalExpression : TypedBinaryOperator
    {
        private readonly Dictionary<(Type, Type), Type> _typeRules;
        public RelationalExpression(Token token, TypedExpression leftExpression, TypedExpression rightExpression)
            : base(token, leftExpression, rightExpression, null)
        {
            _typeRules = new Dictionary<(Type, Type), Type>
            {
                { (Type.Float, Type.Float), Type.Bool },
                { (Type.Int, Type.Int), Type.Bool },
                { (Type.String, Type.String), Type.Bool },
                { (Type.Float, Type.Int), Type.Bool },
                { (Type.Int, Type.Float), Type.Bool }
            };
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

        public override string Generate()
        {
            if (Token.TokenType == TokenType.Equal)
            {
                return $"{LeftExpression.Generate()} == {RightExpression.Generate()}";
            }

            return $"{LeftExpression.Generate()} {Token.Lexeme} {RightExpression.Generate()}";
        }

        public override Type GetExpressionType()
        {
            if (_typeRules.TryGetValue((LeftExpression.GetExpressionType(), RightExpression.GetExpressionType()), out var resultType))
            {
                return resultType;
            }

            throw new ApplicationException($"Cannot perform relational operation on {LeftExpression.GetExpressionType()}, {RightExpression.GetExpressionType()}");
        }
    }
}
