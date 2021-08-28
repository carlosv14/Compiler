using Compiler.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public abstract class BinaryOperator : Operator
    {

        public BinaryOperator(Token token, Expression leftExpression, Expression rightExpression, Type type)
            : base(token, type)
        {
            LeftExpression = leftExpression;
            RightExpression = rightExpression;
        }

        public Expression LeftExpression { get; }
        public Expression RightExpression { get; }
    }
}
