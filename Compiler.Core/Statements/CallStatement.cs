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

        public override void Interpret()
        {
            var method = EnvironmentManager.GetSymbolForEvaluation(Id.Token.Lexeme);
            if (method.Id.Token.Lexeme == "print")
            {
                InnerEvaluate(Arguments);
            }
        }

        private void InnerEvaluate(Expression arguments)
        {
            if (arguments is BinaryOperator binary)
            {
                InnerEvaluate(binary.LeftExpression);
                InnerEvaluate(binary.RightExpression);
            }
            else
            {
                var typedExpression = arguments as TypedExpression;
                Console.WriteLine(typedExpression.Evaluate());
            }
        }

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

            if (attributes is BinaryOperator binary && binary.RightExpression == null && (arguments is BinaryOperator))
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

        public override string Generate(int tabs)
        {
            var code = GetCodeInit(tabs);
            var innerCode = InnerCodeGenerateCode(Arguments);
            code += $"{Id.Generate()}({innerCode}){Environment.NewLine}";
            return code;
        }

        private string InnerCodeGenerateCode(Expression arguments)
        {
            var code = string.Empty;
            if (arguments is BinaryOperator binary)
            {
                code += InnerCodeGenerateCode(binary.LeftExpression);
                code += InnerCodeGenerateCode(binary.RightExpression);
            }
            else
            {
                code += arguments.Generate();
            }
            return code;
        }
    }
}
