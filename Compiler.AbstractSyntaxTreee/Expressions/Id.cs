using Compiler.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public class Id : Expression
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
