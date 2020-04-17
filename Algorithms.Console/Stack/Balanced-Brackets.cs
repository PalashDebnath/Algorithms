using System.Collections.Generic;

namespace Algorithms.Problems
{
    public static class BalancedBracket
    {
        public static bool Check(string str)
        {
            List<char> _stack = new List<char>();
            foreach (var c in str)
            {
                if(_stack.Count == 0)
                {
                    _stack.Add(c);
                }
                else
                {
                    if(_stack[_stack.Count - 1] == '}' && c == '{')
                        _stack.RemoveAt(_stack.Count - 1);
                    else if(_stack[_stack.Count - 1] == ']' && c == '[')
                        _stack.RemoveAt(_stack.Count - 1);
                    else if(_stack[_stack.Count - 1] == ')' && c == '(')
                        _stack.RemoveAt(_stack.Count - 1);
                    else
                        _stack.Add(c);
                }                   
            }
            return _stack.Count == 0 ? true : false;
        }
    }
}