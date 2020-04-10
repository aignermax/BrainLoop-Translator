using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslationWCFService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TranslationWCFService.Model.Tests
{
    [TestClass()]
    public class DummyTranslationXMLGeneratorTests
    {
        [TestMethod()]
        public void GenerateDummyDataTest()
        {
            DummyTranslationXMLGenerator myXMLGen = new DummyTranslationXMLGenerator();
            // it should create an XML File that can be read by the TranslationDictionary without crashing. 
            string FileName = Path.GetTempFileName();
            File.Delete(FileName);
            myXMLGen.GenerateDummyData(FileName);
            myXMLGen.GenerateDummyData(null);
            myXMLGen.GenerateDummyData("");
            TranslationDictionary myDict = TranslationDictionary.LoadNewDictionary(FileName);
            Assert.IsTrue(myDict.Languages.Length > 0, " Languages did not load properly");

            foreach (Language l in myDict.Languages)
            {
                if(string.IsNullOrWhiteSpace(l.Name))
                {
                    Assert.Fail("Name of Language not set properly");
                }
                if(l.Words.Length <= 0)
                {
                    Assert.Fail(" Language does not contain words");
                }
                foreach (Word w in myDict.Languages.First().Words)
                {
                    if (string.IsNullOrWhiteSpace(w.Notation) || string.IsNullOrWhiteSpace(w.EnglishMeaning))
                    {
                        Assert.Fail("Word's notation or Englishmeaning did not get set properly");
                    }
                }
            }
            File.Delete(FileName);
            Console.WriteLine("Success: " + FileName);
        }
    }
}