using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Statements
{
    public class AssignationStatement : Statement, ISemanticValidation
    {
        public AssignationStatement(Id id, Expression expression)
        {
            Id = id;
            Expression = expression;
            Validate();
        }

        public Id Id { get; }
        public Expression Expression { get; }

        public void Validate()
        {
            if (Id.GetExpressionType() != Expression.GetExpressionType())
            {
                throw new ApplicationException($"Type {Id.GetExpressionType()} is not assignable to {Expression.GetExpressionType()}");
            }
        }
    }
}
