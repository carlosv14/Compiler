using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Statements
{
    public class CallStatement : Statement
    {
        public CallStatement(Id id, Expression arguments)
        {
            Id = id;
            Arguments = arguments;
        }

        public Id Id { get; }
        public Expression Arguments { get; }
    }
}
