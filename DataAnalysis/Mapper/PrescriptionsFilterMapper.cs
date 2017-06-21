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
    public class PrescriptionsFilterMapper : MapperBase
    {
        private IPrescriptionsReader reader;

        public override void Initialize(MapperContext context)
        {
            reader = new PrescriptionsReader();

            base.Initialize(context);
        }
        public override void Map(string inputLine, MapperContext context)
        {
            Type prescriptions = typeof(Prescriptions);

            PropertyInfo[] prescriptionsInfo = prescriptions.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            char[] delimiterChars = { ',' };

            string[] individualItems = inputLine.Trim().Split(delimiterChars);

            if (individualItems.Count() == prescriptionsInfo.Length)
            {
                Prescriptions prescription = reader.ExtractPrescriptions(inputLine);

                if (String.IsNullOrWhiteSpace(prescription.ReferencePracticeId)) { return; }

                if (prescription.BNFName.ToLower() != "peppermint oil") { return; }

                context.EmitKeyValue(prescription.BNFName, prescription.ActualCost.ToString("0.00"));
            }
        }
    }
}
