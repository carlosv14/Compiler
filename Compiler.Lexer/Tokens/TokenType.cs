using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Lexer.Tokens
{
    public enum TokenType
    {
        Asterisk,
        Plus,
        Minus,
        LeftParens,
        RightParens,
        SemiColon,
        Equal,
        Division,
        LessThan,
        LessOrEqualThan,
        NotEqual,
        GreaterThan,
        GreaterOrEqualThan,
        IntKeyword,
        IfKeyword,
        ElseKeyword,
        Identifier,
        IntConstant,
        FloatConstant,
        Assignation,
        StringConstant,
        EOF,
        OpenBrace,
        CloseBrace,
        Comma,
        BasicType,
        FloatKeyword,
        StringKeyword
    }
}
