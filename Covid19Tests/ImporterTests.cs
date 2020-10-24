using Microsoft.VisualStudio.TestTools.UnitTesting;
using Covid19;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Newtonsoft.Json;

namespace Covid19.Tests
{
    [TestClass()]
    public class ImporterTests
    {
        private Importer _importer;
        private Exporter _exporter;

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            // Executes once before the test run. (Optional)
        }

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            // Executes once for the test class. (Optional)
        }

        [TestInitialize]
        public void Setup()
        {
            // Runs before each test. (Optional)
            _importer = new Importer();
            _exporter = new Exporter();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Executes once after the test run. (Optional)
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
        }

        [TestCleanup]
        public void TearDown()
        {
            // Runs after each test. (Optional)
        }
        [TestMethod()]
        public void getMortalityTest()
        {
            var expected = _importer.getMortality();
            _exporter.WriteXmlFile(expected, @"mortality.xml");
            _exporter.WriteJsonFile(expected, @"mortality.json");
            var xmlActual = _importer.ReadMortalityFromXmlFile(@"mortality.xml");
            var jsonActual = _importer.ReadMortalityFromJsonFile(@"mortality.json");
            //expected == xmlActual and expexted == jsonActual

            /*
             Ik heb eerst CollectionAssert.AreEqual geprobeerd maar dit werkte niet aangezien de 2 lists niet dezelfde reference hebben.
             Na wat opzoek werk waren er verschillende opties, NuGet packet toevoegen "Fluent Assertions" kwam als beste methode naar voor
             Maar tijdens de vorige teamsmeeting werd gezegd dit niet te gebruiken. Dus vond ik er niets beter op dan de objecten naar een string
             te serializen en dan beide strings te vergelijken.
             */
            var expectedJsonConverted = JsonConvert.SerializeObject(expected);
            var jsonActualJsonConverted = JsonConvert.SerializeObject(jsonActual);
            var xmlActualJsonConverted = JsonConvert.SerializeObject(xmlActual);

            //assert
            ///CollectionAssert.AreEquivalent(expected, xmlActual);
            Assert.AreEqual(expectedJsonConverted, jsonActualJsonConverted);
            Assert.AreEqual(expectedJsonConverted, xmlActualJsonConverted);
        }

        [TestMethod()]
        public void GetCasesTest()
        {
            var expected = _importer.GetCases();
            _exporter.WriteXmlFile(expected, @"cases.xml");
            _exporter.WriteJsonFile(expected, @"cases.json");
            var xmlActual = _importer.ReadCasesFromXmlFile(@"cases.xml");
            var jsonActual = _importer.ReadCasesFromJsonFile(@"cases.json");

            var expectedJsonConverted = JsonConvert.SerializeObject(expected);
            var jsonActualJsonConverted = JsonConvert.SerializeObject(jsonActual);
            var xmlActualJsonConverted = JsonConvert.SerializeObject(xmlActual);

            //assert
            ///CollectionAssert.AreEquivalent(expected, xmlActual);
            Assert.AreEqual(expectedJsonConverted, jsonActualJsonConverted);
            Assert.AreEqual(expectedJsonConverted, xmlActualJsonConverted);

        }
    }
}