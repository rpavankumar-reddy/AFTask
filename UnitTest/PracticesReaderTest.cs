using System;
using Service;
using Model;
using NUnit.Framework;
using System.IO;
using System.Resources;
using System.Reflection;

namespace UnitTest
{
    [TestFixture]
    public class PracticesReaderTest
    {
        private IPracticesReader lineReader;
        private ResourceManager resMan = null;       

        [SetUp]
        public void SetUp()
        {
            this.lineReader = new PracticesReader();
            resMan = new ResourceManager("UnitTest.AFTaskResourceTest", Assembly.GetExecutingAssembly());
        }
      
        [Test]
        public void ReadPracticeCorrectData()
        {
            string filepath = resMan.GetString("PracticeFileName");           
            var practice = new Practices();
            using (var sr = new StreamReader(filepath))
            {
                string line = null;
                //Read and display lines from the file until the end of the file is reached.                
                while ((line = sr.ReadLine()) != null)
                {
                    practice = lineReader.ExtractPractices(line);
                }
            }
            Assert.That(practice.Period, Is.EqualTo("201202"));
            Assert.That(practice.PracticeId, Is.EqualTo("A81001"));
            Assert.That(practice.PracticeName, Is.EqualTo("THE DENSHAM SURGERY"));
            Assert.That(practice.PostCode, Is.EqualTo("TS18 1HU"));

        }

        [Test]
        public void ReadPracticeWrongData()
        {
            string filepath = resMan.GetString("Practice_FileName");           
            var practice = new Practices();
            using (var sr = new StreamReader(filepath))
            {
                string line = null;
                //Read and display lines from the file until the end of the file is reached.                
                while ((line = sr.ReadLine()) != null)
                {
                    practice = lineReader.ExtractPractices(line);
                }
            }
            Assert.That(practice.Period, Is.EqualTo("201202"));
            Assert.That(practice.PracticeId, Is.EqualTo("A81001"));
            Assert.That(practice.PracticeName, Is.EqualTo("THE DENSHAM SURGERY"));
            Assert.That(practice.PostCode, Is.EqualTo("TS18 1HU"));

        }
    }
}
