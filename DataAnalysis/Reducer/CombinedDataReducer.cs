using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Reducer
{
    public class CombinedDataReducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            double totalPrice = 0.0d;

            string postcode = "";

            foreach (string item in values)
            {
                decimal value;

                if (Decimal.TryParse(item, out value))
                {
                    // It's a actual cost
                    totalPrice += (double)value;
                }
                else
                {
                    // It's a PostCode.
                    postcode = item;
                }
            }


            if (postcode != "")
            {
                string result = "Total Actual Cost in PostCode  " + postcode.Trim() + " is: " + totalPrice.ToString("0.00");
                context.EmitLine(result);
            }

        }
    }
}
