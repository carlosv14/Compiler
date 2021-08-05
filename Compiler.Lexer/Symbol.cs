using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Lexer
{
    public class Symbol
    {
        public Symbol(string id, SymbolType symbolType )
        {
            Id = id;
            SymbolType = SymbolType;
        }

        public string Id { get; set; }

        public SymbolType SymbolType { get; set; }
    }
}
