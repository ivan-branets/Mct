using System;
using System.Collections.Generic;
using System.Text;

namespace Mct_53
{
    public class Rpn
    {
        private readonly IList<object> _rpn = new List<object>(); 

        public Rpn(string expression)
        {
            _rpn = CreateRpn(Split(expression));
        }

        public bool HasSingleValue
        {
            get { return _rpn.Count == 1; }
        }

        public int GetSignleNumber()
        {
            return (int)_rpn[0];
        }

        public void ProccessFirstFunc()
        {
            var fpi = GetFirstOperatorIndex();
            var @operator = Operator.Operators[(char)_rpn[fpi]];

            var operants = GetOperants(fpi);
            var operantCount = operants.Count;

            var result = @operator.Func(operants);
            ReplaceWithResult(fpi, result, operantCount);
        }

        private void ReplaceWithResult(int fpi, int result, int operantToBeRemovedCount)
        {
            _rpn[fpi] = result;

            for (var i = 1; i <= operantToBeRemovedCount; i++)
            {
                _rpn.RemoveAt(fpi - i);
            }
        }

        private int GetFirstOperatorIndex()
        {
            var firstOperatorIndex = 0;

            while (!(_rpn[firstOperatorIndex] is char))
            {
                firstOperatorIndex++;
            }

            return firstOperatorIndex;
        }

        private Stack<int> GetOperants(int operatorIndex)
        {
            var stack = new Stack<int>();
            var operantCount = Operator.Operators[(char)_rpn[operatorIndex]].OperantCount;

            for (var i = operatorIndex - 1; i >= operatorIndex - operantCount; i--)
            {
                stack.Push((int)_rpn[i]);
            }

            return stack;
        }

        private static IList<object> CreateRpn(IEnumerable<object> input)
        {
            var rpn = new List<object>();
            var operators = new Stack<char>();

            foreach (var el in input)
            {
                if (el is char)
                {
                    var op = (char)el;
                    if (operators.Count == 0 || op == '(')
                    {
                        operators.Push(op);
                    }
                    else if (op == ')')
                    {
                        while (operators.Peek() != '(')
                        {
                            rpn.Add(operators.Pop());
                        }
                        operators.Pop();
                    }
                    else
                    {
                        while (operators.Count > 0 
                            && operators.Peek() != '(' 
                            && !IsHigherPriority(op, operators))
                        {
                            rpn.Add(operators.Pop());
                        }

                        operators.Push(op);
                    }
                }
                else
                {
                    rpn.Add(el);
                }
            }

            while (operators.Count > 0)
            {
                rpn.Add(operators.Pop());
            }

            return rpn;
        }

        private static bool IsHigherPriority(char op, Stack<char> operators)
        {
            return Operator.Operators[op].Priority > Operator.Operators[operators.Peek()].Priority;
        }

        private static IEnumerable<object> Split(string expression)
        {
            var builder = new StringBuilder();
            var result = new List<object>();

            foreach (var ch in expression.Replace(" ", ""))
            {
                if (ch == '(')
                {
                    result.Add(ch);
                }
                else
                {
                    if (ch == ')' || Operator.Operators.ContainsKey(ch))
                    {
                        if (builder.Length > 0)
                        {
                            var number = GetNumber(builder);
                            result.Add(number);

                            builder.Clear();                            
                        }

                        result.Add(ch);
                    }
                    else
                    {
                        builder.Append(ch);
                    }                    
                }
            }

            if (builder.Length > 0)
            {
                result.Add(GetNumber(builder));                
            }

            return result;
        }

        private static int GetNumber(StringBuilder builder)
        {
            int number;

            if (!int.TryParse(builder.ToString(), out number))
            {
                throw new ArgumentException("Can't parse number");
            }

            return number;
        }
    }
}
