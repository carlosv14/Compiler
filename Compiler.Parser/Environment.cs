using Compiler.Core.Expressions;
using System;
using System.Collections.Generic;

namespace Compiler.Parser
{
    public enum SymbolType
    {
        Variable,
        Method
    }

    public class Symbol
    {
        public Symbol(SymbolType symbolType, Id id, dynamic value)
        {
            SymbolType = symbolType;
            Id = id;
            Value = value;
        }

        public Symbol(SymbolType symbolType, Id id, Expression attributes)
        {
            Attributes = attributes;
            SymbolType = symbolType;
            Id = id;
        }

        public SymbolType SymbolType { get; }
        public Id Id { get; }
        public dynamic Value { get; set; }
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
            if (!_table.TryAdd(lexeme, new Symbol(SymbolType.Variable, id, null)))
            {
                throw new ApplicationException($"Variable {lexeme} already defined in current context");
            }
        }

        public void UpdateVariable(string lexeme, dynamic value)
        {
            var variable = Get(lexeme);
            variable.Value = value;
            _table[lexeme] = variable;
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
            for (var currentEnv = this; currentEnv != null; currentEnv = currentEnv.Previous)
            {
                if (currentEnv._table.TryGetValue(lexeme, out var found))
                {
                    return found;
                }
            }
            throw new ApplicationException($"Symbol {lexeme} doesn't exist in current context");
        }
    }
}
