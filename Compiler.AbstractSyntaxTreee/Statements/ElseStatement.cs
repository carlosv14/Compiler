using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Statements
{
    public class ElseStatement : Statement
    {
        public ElseStatement(Expression expression, Statement trueStatement, Statement falseStatement)
        {
            Expression = expression;
            TrueStatement = trueStatement;
            FalseStatement = falseStatement;
        }

        public Expression Expression { get; }
        public Statement TrueStatement { get; }
        public Statement FalseStatement { get; }
    }
}
