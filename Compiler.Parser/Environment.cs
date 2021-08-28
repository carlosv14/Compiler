using Compiler.AbstractSyntaxTreee.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compiler.Parser
{
    public class Environment
    {
        private readonly Dictionary<string, Id> _table;
        protected Environment Previous;

        public Environment(Environment previous)
        {
            Previous = previous;
            _table = new Dictionary<string, Id>();
        }

        public void Add(string lexeme, Id id)
        {
            if(!_table.TryAdd(lexeme, id))
            {
                throw new ApplicationException($"Variable {lexeme} already defined in current context");
            }
        }

        public Id Get(string lexeme)
        {
            for (var currentEnv = this; currentEnv != null; currentEnv = Previous)
            {
                if (_table.TryGetValue(lexeme, out var found))
                {
                    return found;
                }
            }
            throw new ApplicationException($"Variable {lexeme} doesn't exist in current context");
        }
    }
}
