using Compiler.Lexer;
using Compiler.Lexer.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

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

        public void Parse()
        {
            Program();
        }

        private void Program()
        {
            Block();
        }

        private void Block()
        {
            Match(TokenType.OpenBrace);
            Decls();
            Stmts();
            Match(TokenType.CloseBrace);
        }

        private void Stmts()
        {
            if (this.lookAhead.TokenType == TokenType.CloseBrace)
            {
                return;
            }
            Stmt();
            Stmts();
        }

        private void Stmt()
        {
            switch (this.lookAhead.TokenType)
            {
                case TokenType.Identifier:
                    {
                        Match(TokenType.Identifier);
                        if (this.lookAhead.TokenType == TokenType.Assignation)
                        {
                            AssignStmt();
                            return;
                        }
                        CallStmt();
                    }
                    break;
                case TokenType.IfKeyword:
                    {
                        Match(TokenType.IfKeyword);
                        Match(TokenType.LeftParens);
                        Eq();
                        Match(TokenType.RightParens);
                        Stmt();
                        if (this.lookAhead.TokenType != TokenType.ElseKeyword)
                        {
                            return;
                        }
                        Match(TokenType.ElseKeyword);
                        Stmt();
                    }
                    break;
                default:
                    Block();
                    break;
            }
        }

        private void Eq()
        {
            Rel();
            while (this.lookAhead.TokenType == TokenType.Equal || this.lookAhead.TokenType == TokenType.NotEqual)
            {
                Move();
                Rel();
            }
        }

        private void Rel()
        {
            Expr();
            if (this.lookAhead.TokenType == TokenType.LessThan
                || this.lookAhead.TokenType == TokenType.GreaterThan
                || this.lookAhead.TokenType == TokenType.LessOrEqualThan
                || this.lookAhead.TokenType == TokenType.GreaterOrEqualThan)
            {
                Move();
                Expr();
            }
        }

        private void Expr()
        {
            Term();
            while (this.lookAhead.TokenType == TokenType.Plus || this.lookAhead.TokenType == TokenType.Minus)
            {
                Move();
                Term();
            }
        }

        private void Term()
        {
            Factor();
            while (this.lookAhead.TokenType == TokenType.Asterisk || this.lookAhead.TokenType == TokenType.Division)
            {
                Move();
                Factor();
            }
        }

        private void Factor()
        {
            switch (this.lookAhead.TokenType)
            {
                case TokenType.LeftParens:
                    {
                        Match(TokenType.LeftParens);
                        Eq();
                        Match(TokenType.RightParens);
                    }
                    break;
                case TokenType.Constant:
                    Match(TokenType.Constant);
                    break;
                default:
                    Match(TokenType.Identifier);
                    break;
            }
        }

        private void CallStmt()
        {
            Match(TokenType.LeftParens);
            OptParams();
            Match(TokenType.RightParens);
            Match(TokenType.SemiColon);
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

        private void AssignStmt()
        {
            Match(TokenType.Assignation);
            Eq();
            Match(TokenType.SemiColon);
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
