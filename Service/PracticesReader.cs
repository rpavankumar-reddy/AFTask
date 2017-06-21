using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Service
{
    public class PracticesReader : IPracticesReader
    {
        private string csvText;

        /// <summary>
        /// Extracts the Practices CSV data
        /// </summary>
        /// <param name="lineAsCsv"></param>
        /// <returns>Practices</returns>
        public Practices ExtractPractices(string csvInput)
        {
            csvText = csvInput;

            Practices practice = new Practices();

            practice.Period = parseDataAsString().Trim();

            practice.PracticeId = parseDataAsString().Trim();

            practice.PracticeName = parseDataAsString().Trim();

            practice.HealthCentre = parseDataAsString().Trim();

            practice.Address = parseDataAsString().Trim();

            practice.City = parseDataAsString().Trim();

            practice.County = parseDataAsString().Trim();

            practice.PostCode = parseDataAsString().Trim();

            return practice;
        }

        /// <summary>
        /// Parse the data in string format
        /// </summary>
        /// <returns>string</returns>
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
    }
}
