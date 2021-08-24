using Compiler.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public class RelationalExpression : BinaryOperator
    {
        public RelationalExpression(Token token, Expression leftExpression, Expression rightExpression)
            : base(token, leftExpression, rightExpression)
        {
        }
    }
}
