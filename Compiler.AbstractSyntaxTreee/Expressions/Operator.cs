using Compiler.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Expressions
{
    public class Operator : Expression
    {
        public Operator(Token token, Type type) : base(token, type)
        {
        }
    }
}
