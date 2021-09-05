using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Parser
{
    public enum SymbolType
    {
        Variable,
        Method
    }

    public class Symbol
    {
        public Symbol(SymbolType symbolType, Id id)
        {
            SymbolType = symbolType;
            Id = id;
        }

        public Symbol(SymbolType symbolType, Id id, Expression attributes)
        {
            Attributes = attributes;
            SymbolType = symbolType;
            Id = id;
        }

        public SymbolType SymbolType { get; }
        public Id Id { get; }
        public Expression Attributes { get; }
    }

    public class Environment
    {
        private readonly Dictionary<string, Symbol> _table;
        protected Environment Previous;

        public Environment(Environment previous)
        {
            Previous = previous;
            _table = new Dictionary<string, Symbol>();
        }

        public void AddVariable(string lexeme, Id id)
        {
            if(!_table.TryAdd(lexeme, new Symbol(SymbolType.Variable, id)))
            {
                throw new ApplicationException($"Variable {lexeme} already defined in current context");
            }
        }

        public void AddMethod(string lexeme, Id id, BinaryOperator arguments)
        {
            if (!_table.TryAdd(lexeme, new Symbol(SymbolType.Method, id, arguments)))
            {
                throw new ApplicationException($"Method {lexeme} already defined in current context");
            }
        }

        public Symbol Get(string lexeme)
        {
            for (var currentEnv = this; currentEnv != null; currentEnv = Previous)
            {
                if (_table.TryGetValue(lexeme, out var found))
                {
                    return found;
                }
            }
            throw new ApplicationException($"Symbol {lexeme} doesn't exist in current context");
        }
    }
}
