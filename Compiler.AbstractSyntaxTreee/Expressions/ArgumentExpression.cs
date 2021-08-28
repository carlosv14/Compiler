using Compiler.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public class ArgumentExpression : BinaryOperator
    {
        public ArgumentExpression(Token token, Expression leftExpression, Expression rightExpression)
            : base(token, leftExpression, rightExpression, null)
        {

        }

        public override Type GetExpressionType()
        {
            throw new NotImplementedException();
        }
    }
}
