using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Statements
{
    public class ElseStatement : Statement, ISemanticValidation
    {
        public ElseStatement(Expression expression, Statement trueStatement, Statement falseStatement)
        {
            Expression = expression;
            TrueStatement = trueStatement;
            FalseStatement = falseStatement;
            Validate();
        }

        public Expression Expression { get; }
        public Statement TrueStatement { get; }
        public Statement FalseStatement { get; }

        public void Validate()
        {
            if (Expression.GetExpressionType() != Type.Bool)
            {
                throw new ApplicationException("A boolean is required in ifs");
            }
        }
    }
}
