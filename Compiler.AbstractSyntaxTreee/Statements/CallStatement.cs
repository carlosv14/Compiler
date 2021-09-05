using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.AbstractSyntaxTreee.Statements
{
    public class CallStatement : Statement, ISemanticValidation
    {
        public CallStatement(Id id, Expression arguments, Expression attributes)
        {
            Id = id;
            Arguments = arguments;
            Attributes = attributes;
            Validate();
        }

        public Id Id { get; }
        public Expression Arguments { get; }
        public Expression Attributes { get; }

        public void Validate()
        {
            ValidateArguments(Attributes, Arguments);
        }

        private void ValidateArguments(Expression attributes, Expression arguments)
        {
            if (attributes == null && arguments == null)
            {
                return;
            }

            if (attributes is BinaryOperator && !(arguments is BinaryOperator) ||
                arguments is BinaryOperator && !(attributes is BinaryOperator))
            {
                throw new ApplicationException("Incorrect amount of arguments supplied");
            }

            if (attributes is BinaryOperator attr && arguments is BinaryOperator arg)
            {
                ValidateArguments(attr.LeftExpression, arg.LeftExpression);
                ValidateArguments(attr.RightExpression, arg.RightExpression);
            }
            else if (attributes.GetExpressionType() != arguments.GetExpressionType())
            {
                throw new ApplicationException($"Expected {attributes.GetExpressionType()} but received {arguments.GetExpressionType()}");
            }

        }
    }
}
