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
    public class PracticesCountMapper : MapperBase
    {
        private IPracticesReader reader;

        public override void Initialize(MapperContext context)
        {
            reader = new PracticesReader();
            base.Initialize(context);
        }
        public override void Map(string inputLine, MapperContext context)
        {
            Type practices = typeof(Practices);

            PropertyInfo[] practicesInfo = practices.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            char[] delimiterChars = { ',' };

            string[] individualItems = inputLine.Trim().Split(delimiterChars);

            if (individualItems.Count() == practicesInfo.Length)
            {
                Practices practice = reader.ExtractPractices(inputLine);

                if (String.IsNullOrWhiteSpace(practice.PracticeId)) { return; }

                if (String.IsNullOrWhiteSpace(practice.PracticeName)) { return; }

                if (String.IsNullOrWhiteSpace(practice.County)) { return; }

                context.EmitKeyValue("LONDON", Convert.ToString(practice.County == "LONDON"));
            }
        }
    }
}
