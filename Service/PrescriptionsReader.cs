using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class PrescriptionsReader : IPrescriptionsReader
    {
        private string csvText;

        /// <summary>
        /// Extracts the Prescriptions CSV data
        /// </summary>
        /// <param name="lineAsCsv"></param>
        /// <returns></returns>
        public Prescriptions ExtractPrescriptions(string csvInput)
        {
            csvText = csvInput;
            Prescriptions prescription = new Prescriptions();

            prescription.SHA = parseDataAsString().Trim();

            prescription.PCT = parseDataAsString().Trim();

            prescription.ReferencePracticeId = parseDataAsString().Trim();

            prescription.BNFCode = parseDataAsString().Trim();

            prescription.BNFName = parseDataAsString().Trim();

            prescription.Items = parseDataAsInt();

            prescription.NIC = parseDataAsDecimal();

            prescription.ActualCost = parseDataAsDecimal();

            prescription.Period = parseDataAsString();

            return prescription;
        }
        private string parseDataAsString()
        {
            string nextValue = null;

            if (csvText.StartsWith("\""))
            {
                int endOfValue = csvText.IndexOf("\"", 1);

                nextValue = csvText.Substring(1, endOfValue - 1);

                csvText = csvText.Substring(endOfValue + 2);
            }
            else
            {
                int endOfValue = csvText.IndexOf(",", 0);

                if (endOfValue != -1)
                {
                    nextValue = csvText.Substring(0, endOfValue);

                    csvText = csvText.Substring(endOfValue + 1);
                }
                else nextValue = csvText;
            }
            return nextValue;
        }

        private int parseDataAsInt()
        {
            int value;

            String intAsString = parseDataAsString();

            intAsString = intAsString.Replace("$", "");

            intAsString = intAsString.Replace(",", "");

            intAsString = intAsString.Replace(" ", "");

            if (int.TryParse(intAsString, out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }

        private decimal parseDataAsDecimal()
        {
            decimal value;

            String deciamlAsString = parseDataAsString();

            deciamlAsString = deciamlAsString.Replace("$", "");

            deciamlAsString = deciamlAsString.Replace(",", "");

            deciamlAsString = deciamlAsString.Replace(" ", "");

            if (Decimal.TryParse(deciamlAsString, out value))
            {
                return value;
            }
            else
            {
                return 0;
            }
        }
    }
}
