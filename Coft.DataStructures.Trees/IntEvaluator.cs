using System;
using System.Collections.Generic;
using System.Text;

namespace Coft.DataStructures.Trees
{
    public class IntEvaluator : IElementEvaluator<int>
    {
        public decimal Evaluate(int element)
        {
            return (decimal)element;
        }
    }
}