using DataAnalysis.Mapper;
using DataAnalysis.Reducer;
using Microsoft.Hadoop.MapReduce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalysis
{
    class GenerateReport
    {      
        static void Main(string[] args)
        {
            ResourceManager resManager = new ResourceManager("DataAnalysis.AFTaskResource", Assembly.GetExecutingAssembly());
            // Load Data in to HDInsight 
            HadoopJobConfiguration practicesJobConfig = new HadoopJobConfiguration()
            {

                InputPath = resManager.GetString("InputPath"),
                OutputFolder = resManager.GetString("PracticesOutputPath"),
            };

            HadoopJobConfiguration prescriptionsJobConfig = new HadoopJobConfiguration()
            {
                InputPath = resManager.GetString("InputPath"),
                OutputFolder = resManager.GetString("PrescriptionsOutputPath"),
            };

            HadoopJobConfiguration combinedJobConfig = new HadoopJobConfiguration()
            {
                InputPath = resManager.GetString("InputPath"),
                OutputFolder = resManager.GetString("CombinedOutputPath"),
            };

            Hadoop.Connect().MapReduceJob.Execute<PracticesCountMapper, PracticesCountReducer>(practicesJobConfig);

            Hadoop.Connect().MapReduceJob.Execute<PrescriptionsFilterMapper, PrescriptionsFilterReducer>(prescriptionsJobConfig);

            Hadoop.Connect().MapReduceJob.Execute<CombinedDataMapper, CombinedDataReducer>(combinedJobConfig);

            Console.Read();
        }
    }
}
