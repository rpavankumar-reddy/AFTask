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
    public class PrescriptionsReaderTest
    {
        private IPrescriptionsReader lineReader;
        private ResourceManager resMan = null;

        [SetUp]
        public void SetUp()
        {
            this.lineReader = new PrescriptionsReader();
            resMan = new ResourceManager("UnitTest.AFTaskResourceTest", Assembly.GetExecutingAssembly());
        }

        [Test]
        public void ReadPrescriptionCorrectData()
        {
            string filepath = resMan.GetString("PrescriptionFileName");         
            var prescription = new Prescriptions();
            using (var sr = new StreamReader(filepath))
            {
                string line = null;                          
                while ((line = sr.ReadLine()) != null)
                {
                    prescription = lineReader.ExtractPrescriptions(line);
                }
            }
            Assert.That(prescription.SHA, Is.EqualTo("Q30"));
            Assert.That(prescription.PCT, Is.EqualTo("5D7"));
            Assert.That(prescription.ReferencePracticeId, Is.EqualTo("A86021"));
            Assert.That(prescription.BNFName, Is.EqualTo("Peppermint Oil"));
            Assert.That(prescription.Items, Is.EqualTo(12));
        }

        [Test]
        public void ReadPrescriptionWrongData()
        {
            string filepath = resMan.GetString("Prescription_FileName");        
            var prescription = new Prescriptions();
            using (var sr = new StreamReader(filepath))
            {
                string line = null;                    
                while ((line = sr.ReadLine()) != null)
                {
                    prescription = lineReader.ExtractPrescriptions(line);
                }
            }
            Assert.That(prescription.SHA, Is.EqualTo("Q30"));
            Assert.That(prescription.PCT, Is.EqualTo("5D7"));
            Assert.That(prescription.ReferencePracticeId, Is.EqualTo("A86021"));
            Assert.That(prescription.BNFName, Is.EqualTo("Peppermint Oil"));
            Assert.That(prescription.Items, Is.EqualTo(0));
        }
    }
}
