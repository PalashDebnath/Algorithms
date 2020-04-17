using System;
using System.Collections.Generic;

namespace Algorithms.Problems
{
    public class Stack
    {
        private List<int> _stack;
        private List<Dictionary<string, int>> _maxminStack; 
        public int MinValue { get; private set; }
        public int MaxValue { get; private set; }

        public Stack()
        {
            _stack = new List<int>();
            _maxminStack = new List<Dictionary<string, int>>();
        }

        public int Peek()
        {
            if(_stack.Count == 0)
                return -1;
            return _stack[_stack.Count - 1];
        }

        public int Pop()
        {
            if(_stack.Count == 0)
                return -1;
            int value = _stack[_stack.Count - 1];
            _stack.RemoveAt(_stack.Count - 1);
            _maxminStack.RemoveAt(_maxminStack.Count - 1);
            if(_maxminStack.Count > 0)
            {
                MinValue = _maxminStack[_maxminStack.Count - 1]["min"];
                MaxValue = _maxminStack[_maxminStack.Count - 1]["max"];
            }
            else
            {
                MinValue = Int32.MinValue;
                MaxValue = Int32.MaxValue;
            }
            return value;
        }

        public void Push(int number)
        {
            Dictionary<string, int> newMinMax = new Dictionary<string, int>();
            newMinMax.Add("min", number);
            newMinMax.Add("max", number);
            if(_maxminStack.Count > 0)
            {
                newMinMax["min"] = Math.Min(_maxminStack[_maxminStack.Count - 1]["min"], number);
                newMinMax["max"] = Math.Max(_maxminStack[_maxminStack.Count - 1]["max"], number);
            }
            _maxminStack.Add(newMinMax);
            MinValue = _maxminStack[_maxminStack.Count - 1]["min"];
            MaxValue = _maxminStack[_maxminStack.Count - 1]["max"];
            _stack.Add(number);
        }
    }
}