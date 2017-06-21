using Microsoft.Hadoop.MapReduce;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis.Mapper
{
    public class CombinedDataMapper : MapperBase
    {
        private IPracticesReader practiceReader;
        private IPrescriptionsReader prescriptionReader;
        public override void Initialize(MapperContext context)
        {
            practiceReader = new PracticesReader();
            prescriptionReader = new PrescriptionsReader();
            base.Initialize(context);
        }

        public override void Map(string inputLine, MapperContext context)
        {
            char[] delimiterChars = { ',' };

            string[] individualItems = inputLine.Trim().Split(delimiterChars);

            Type practices = typeof(Practices);

            Type prescriptions = typeof(Prescriptions);

            // Get the public properties of Practices.
            PropertyInfo[] practicesInfo = practices.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Get the public properties of Prescriptions.
            PropertyInfo[] prescriptionsInfo = prescriptions.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            if (individualItems.Count() == practicesInfo.Length)
            {
                Practices practice = practiceReader.ExtractPractices(inputLine);

                if (String.IsNullOrWhiteSpace(practice.PracticeId)) { return; }
                if (String.IsNullOrWhiteSpace(practice.PracticeName)) { return; }
                if (String.IsNullOrWhiteSpace(practice.PostCode)) { return; }

                context.EmitKeyValue(practice.PracticeId, Convert.ToString(practice.PostCode));
            }

            if (individualItems.Count() == prescriptionsInfo.Length)
            {
                Prescriptions prescription = prescriptionReader.ExtractPrescriptions(inputLine);

                if (String.IsNullOrWhiteSpace(prescription.ReferencePracticeId)) { return; }

                context.EmitKeyValue(prescription.ReferencePracticeId, prescription.ActualCost.ToString("0.00"));
            }
        }
    }
}
