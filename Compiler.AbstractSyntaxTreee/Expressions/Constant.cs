using Compiler.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public class Constant : Expression
    {
        public Constant(Token token, Type type)
            : base(token, type)
        {
        }
    }
}
