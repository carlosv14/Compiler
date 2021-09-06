using Compiler.Core.Expressions;
using Compiler.Core.Interfaces;
using System;

namespace Compiler.Core.Statements
{
    public class AssignationStatement : Statement
    {
        public AssignationStatement(Id id, TypedExpression expression)
        {
            Id = id;
            Expression = expression;
        }

        public Id Id { get; }
        public TypedExpression Expression { get; }

        public override void ValidateSemantic()
        {
            if (Id.GetExpressionType() != Expression.GetExpressionType())
            {
                throw new ApplicationException($"Type {Id.GetExpressionType()} is not assignable to {Expression.GetExpressionType()}");
            }
        }
    }
}
