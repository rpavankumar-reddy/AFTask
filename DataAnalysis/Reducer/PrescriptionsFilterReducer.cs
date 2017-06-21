using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Reducer
{
    public class PrescriptionsFilterReducer : ReducerCombinerBase
    {
        public override void Reduce(string key, IEnumerable<string> values, ReducerCombinerContext context)
        {
            int numberOfItems = 0;
            double totalPrice = 0.0d;

            foreach (string price in values)
            {
                decimal value;
                if (Decimal.TryParse(price, out value))
                {
                    // The item is a decimal value
                    numberOfItems++;
                    totalPrice += (double)value;
                }
                else
                {
                    // Item is not decimal value.
                    numberOfItems++;
                    totalPrice += (double)0;
                }
            }

            string result = "Average Actual Cost is " + Math.Round(totalPrice / numberOfItems, 2) + " for " +
               numberOfItems + " Items";

            context.EmitKeyValue(key, result);
        }
    }
}
