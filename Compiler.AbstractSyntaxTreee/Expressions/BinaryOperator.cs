using Compiler.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public class BinaryOperator : Operator
    {

        public BinaryOperator(Token token, Expression leftExpression, Expression rightExpression)
            : base(token, null)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public Expression LeftExpression { get; }
        public Expression RightExpression { get; }
    }
}
