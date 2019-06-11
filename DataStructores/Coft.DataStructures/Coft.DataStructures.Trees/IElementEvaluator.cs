using System;
using System.Collections.Generic;
using System.Text;

namespace Coft.DataStructures.Trees
{
    public interface IElementEvaluator<T>
    {
        decimal Evaluate(T element);
    }
}