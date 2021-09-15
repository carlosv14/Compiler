using Compiler.Core.Expressions;
using Compiler.Core.Interfaces;
using System;

namespace Compiler.Core.Statements
{
    public class ElseStatement : Statement
    {
        public ElseStatement(TypedExpression expression, Statement trueStatement, Statement falseStatement)
        {
            Expression = expression;
            TrueStatement = trueStatement;
            FalseStatement = falseStatement;
        }

        public TypedExpression Expression { get; }
        public Statement TrueStatement { get; }
        public Statement FalseStatement { get; }

        public override void Evaluate()
        {
            if (Expression.Evaluate())
            {
                TrueStatement.Evaluate();
            }
            else
            {
                FalseStatement.Evaluate();
            }
        }

        public override void ValidateSemantic()
        {
            if (Expression.GetExpressionType() != Type.Bool)
            {
                throw new ApplicationException("A boolean is required in ifs");
            }
        }
    }
}
