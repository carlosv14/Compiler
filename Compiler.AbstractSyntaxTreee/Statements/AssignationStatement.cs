using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Statements
{
    public class AssignationStatement : Statement
    {
        public AssignationStatement(Id id, Expression expression)
        {
            Id = id;
            Expression = expression;
        }

        public Id Id { get; }
        public Expression Expression { get; }
    }
}
