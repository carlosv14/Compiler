using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Statements
{
    public class IfStatement : Statement, ISemanticValidation
    {
        public IfStatement(Expression expression, Statement statement)
        {
            Expression = expression;
            Statement = statement;
            Validate();
        }

        public Expression Expression { get; }
        public Statement Statement { get; }

        public void Validate()
        {
            if (Expression.GetExpressionType() != Type.Bool)
            {
                throw new ApplicationException("A boolean is required in ifs");
            }
        }
    }
}
