using Compiler.AbstractSyntaxTreee;
using Compiler.AbstractSyntaxTreee.Expressions;
using Compiler.AbstractSyntaxTreee.Statements;
using Compiler.Lexer;
using Compiler.Lexer.Tokens;
using System;

namespace Compiler.Parser
{
    public class Parser
    {
        private readonly IScanner scanner;
        private Token lookAhead;

        public Parser(IScanner scanner)
        {
            this.scanner = scanner;
            this.Move();
        }

        public Node Parse()
        {
            return Program();
        }

        private Statement Program()
        {
            return Block();
        }

        private Statement Block()
        {
            Match(TokenType.OpenBrace);
            Decls();
            var statements = Stmts();
            Match(TokenType.CloseBrace);
            return statements;
        }

        private Statement Stmts()
        {
            if (this.lookAhead.TokenType == TokenType.CloseBrace)
            {//{}
                return Statement.Null;
            }
            return new SequenceStatement(Stmt(), Stmts());
        }

        private Statement Stmt()
        {
            Expression expression;
            Statement statement1, statement2;
            switch (this.lookAhead.TokenType)
            {
                case TokenType.Identifier:
                    {
                        var id = new Id(lookAhead, AbstractSyntaxTreee.Type.Int);
                        Match(TokenType.Identifier);
                        if (this.lookAhead.TokenType == TokenType.Assignation)
                        {
                            return AssignStmt(id);
                        }
                        return CallStmt(id);
                    }
                case TokenType.IfKeyword:
                    {
                        Match(TokenType.IfKeyword);
                        Match(TokenType.LeftParens);
                        expression = Eq();
                        Match(TokenType.RightParens);
                        statement1 = Stmt();
                        if (this.lookAhead.TokenType != TokenType.ElseKeyword)
                        {
                            return new IfStatement(expression, statement1);
                        }
                        Match(TokenType.ElseKeyword);
                        statement2 = Stmt();
                        return new ElseStatement(expression, statement1, statement2);
                    }
                default:
                    return Block();
            }
        }

        private Expression Eq()
        {
            var expression = Rel();
            while (this.lookAhead.TokenType == TokenType.Equal || this.lookAhead.TokenType == TokenType.NotEqual)
            {
                var token = lookAhead;
                Move();
                expression = new RelationalExpression(token, expression, Rel());
            }

            return expression;
        }

        private Expression Rel()
        {
            var expression = Expr();
            if (this.lookAhead.TokenType == TokenType.LessThan
                || this.lookAhead.TokenType == TokenType.GreaterThan
                || this.lookAhead.TokenType == TokenType.LessOrEqualThan
                || this.lookAhead.TokenType == TokenType.GreaterOrEqualThan)
            {
                var token = lookAhead;
                Move();
                expression = new RelationalExpression(token, expression, Expr());
            }
            return expression;
        }

        private Expression Expr()
        {
            var expression = Term();
            while (this.lookAhead.TokenType == TokenType.Plus || this.lookAhead.TokenType == TokenType.Minus)
            {
                var token = lookAhead;
                Move();
                expression = new ArithmeticOperator(token, expression, Term());
            }
            return expression;
        }

        private Expression Term()
        {
            var expression = Factor();
            while (this.lookAhead.TokenType == TokenType.Asterisk || this.lookAhead.TokenType == TokenType.Division)
            {
                var token = lookAhead;
                Move();
                expression = new ArithmeticOperator(token, expression, Factor());
            }
            return expression;
        }

        private Expression Factor()
        {
            switch (this.lookAhead.TokenType)
            {
                case TokenType.LeftParens:
                    {
                        Match(TokenType.LeftParens);
                        var expression = Eq();
                        Match(TokenType.RightParens);
                        return expression;
                    }
                case TokenType.Constant:
                    var constant = new Constant(lookAhead, AbstractSyntaxTreee.Type.Int);
                    Match(TokenType.Constant);
                    return constant;
                default:
                    var id = new Id(lookAhead, AbstractSyntaxTreee.Type.Int);
                    Match(TokenType.Identifier);
                    return id;
            }
        }

        private Statement CallStmt(Id id)
        {
            Match(TokenType.LeftParens);
            OptParams();
            Match(TokenType.RightParens);
            Match(TokenType.SemiColon);
            throw new NotImplementedException();
            return Statement.Null;
        }

        private void OptParams()
        {
            if (this.lookAhead.TokenType != TokenType.RightParens)
            {
                Params();
            }
        }

        private void Params()
        {
            Eq();
            if (this.lookAhead.TokenType != TokenType.Comma)
            {
                return;
            }
            Match(TokenType.Comma);
            Params();
        }

        private Statement AssignStmt(Id id)
        {
            Match(TokenType.Assignation);
            var expression = Eq();
            Match(TokenType.SemiColon);
            return new AssignationStatement(id, expression);
        }

        private void Decls()
        {
            if (this.lookAhead.TokenType == TokenType.IntKeyword)
            {
                Decl();
                Decls();
            }
            //E
        }

        private void Decl()
        {
            Match(TokenType.IntKeyword);
            Match(TokenType.Identifier);
            Match(TokenType.SemiColon);
        }

        private void Move()
        {
            this.lookAhead = this.scanner.GetNextToken();
        }

        private void Match(TokenType tokenType)
        {
            if (this.lookAhead.TokenType != tokenType)
            {
                throw new ApplicationException($"Syntax error! expected token {tokenType} but found {this.lookAhead.TokenType}. Line: {this.lookAhead.Line}, Column: {this.lookAhead.Column}");
            }
            this.Move();
        }
    }
}
