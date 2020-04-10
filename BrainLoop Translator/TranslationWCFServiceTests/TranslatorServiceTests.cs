using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslationWCFService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationWCFService.Tests
{
    [TestClass()]
    public class TranslatorServiceTests
    {
        [TestMethod()]
        public void DetectLanguageTest()
        {
            TranslatorService myservice = new TranslatorService();
            Assert.AreEqual("german", myservice.DetectLanguage("hallo"));
            Assert.AreEqual("english", myservice.DetectLanguage("hello"));
        }

        [TestMethod()]
        public void GetLanguageListTest()
        {
            TranslatorService myservice = new TranslatorService();
            string[] languages = myservice.GetLanguageList();
            Assert.IsTrue(languages.Length > 2);
            Assert.IsTrue(languages[0].Length > 4); // more than 4 digits.
            Assert.IsTrue(languages[1].Length > 4); // more than 4 digits.
        }

        [TestMethod()]
        public void GetTranslationTest()
        {
            TranslatorService myservice = new TranslatorService();
            Assert.AreEqual("bonjour", myservice.GetTranslation("french", "hallo"));
            Assert.AreEqual("hello", myservice.GetTranslation("english", "hallo"));
            Assert.AreEqual("hallo", myservice.GetTranslation("german", "hallo"));
        }

        [TestMethod()]
        public void FindSimilarWordsTest()
        {
            TranslatorService myservice = new TranslatorService();
            Assert.AreEqual("hallo", myservice.FindSimilarWords("hallo")[0] );
            Assert.AreEqual("habe", myservice.FindSimilarWords("hallo")[1]);
        }

        [TestMethod()]
        public void GetAutoCompleteTest()
        {
            TranslatorService myservice = new TranslatorService();
            Assert.AreEqual("hallo", myservice.GetAutoComplete("hall"));
            Assert.AreEqual("baum", myservice.GetAutoComplete("bau"));
        }
    }
}