using System;
using System.Collections.Generic;

namespace Mct_53
{
    public static class LexicalAnalyzer
    {
        public static int Calculate(string expression)
        {
            var rpn = new Rpn(expression);

            while (!rpn.HasSingleValue)
            {
                rpn.ProccessFirstFunc();
            }

            return rpn.GetSignleNumber();
        }
    }
}
