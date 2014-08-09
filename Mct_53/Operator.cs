using System;
using System.Collections.Generic;

namespace Mct_53
{
    internal class Operator
    {
        public static readonly Dictionary<char, Operator> Operators = new Dictionary<char, Operator>
        {
            { '+', new Operator(0, 2, stack => stack.Pop() + stack.Pop()) },
            { '-', new Operator(0, 2, stack => stack.Pop() - stack.Pop()) },
            { '*', new Operator(1, 2, stack => stack.Pop() * stack.Pop()) },
            { '/', new Operator(1, 2, stack => stack.Pop() / stack.Pop()) }
        };

        public Operator(int priority, int operantCount, Func<Stack<int>, int> func)
        {
            Priority = priority;
            OperantCount = operantCount;
            Func = func;
        }

        public int Priority { get; private set; }
        public int OperantCount { get; private set; }
        public Func<Stack<int>, int> Func { get; private set; }
    }
}
