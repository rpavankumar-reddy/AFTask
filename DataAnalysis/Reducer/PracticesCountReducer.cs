using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Reducer
{
    public class PracticesCountReducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            string result = "Total Number of Practices in " + key + " is " + values.Count();
            context.EmitLine(result);
        }
    }
}
