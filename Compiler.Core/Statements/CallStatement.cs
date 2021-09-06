using Compiler.Core.Expressions;
using Compiler.Core.Interfaces;
using System;

namespace Compiler.Core.Statements
{
    public class CallStatement : Statement
    {
        public CallStatement(Id id, Expression arguments, Expression attributes)
        {
            Id = id;
            Arguments = arguments;
            Attributes = attributes;
        }

        public Id Id { get; }
        public Expression Arguments { get; }
        public Expression Attributes { get; }

        public override void ValidateSemantic()
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
            else if (attributes is TypedExpression typedAttr && arguments is TypedExpression typedArg && typedAttr.GetExpressionType() != typedArg.GetExpressionType())
            {
                throw new ApplicationException($"Expected {typedAttr.GetExpressionType()} but received {typedArg.GetExpressionType()}");
            }

        }
    }
}
