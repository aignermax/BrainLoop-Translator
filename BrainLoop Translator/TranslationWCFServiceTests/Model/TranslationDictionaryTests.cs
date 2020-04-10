using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslationWCFService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationWCFService.Model.Tests
{
    [TestClass()]
    public class TranslationDictionaryTests
    {
        [TestMethod()]
        public void DetectLanguageTest()
        {
            TranslationDictionary myTransDict = new TranslationDictionary();
            myTransDict.Languages = new Language[] {
                new Language("german", new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be"),
                    new Word("ist", "be"),
                    new Word("zu", "to"),
                    new Word("von", "of")
                }),
                new Language("english", new Word[] {
                    new Word("hello", "hello"),
                    new Word("the", "the"),
                    new Word("to be", "to be"),
                    new Word("be", "be"),
                    new Word("to", "to"),
                    new Word("of", "of")
                }),
                new Language("french", new Word[] {
                    new Word("bonjour", "hello"),
                    new Word("le", "the"),
                    new Word("son", "to be"),
                    new Word("est", "be"),
                    new Word("à", "to"),
                    new Word("à partir de", "off")
                })
            };
            Assert.AreEqual("german", myTransDict.DetectLanguage("sein").DetectedLanguage.Name);
            Assert.AreEqual("english", myTransDict.DetectLanguage("hello").DetectedLanguage.Name);
            Assert.AreEqual("french", myTransDict.DetectLanguage("bonjour").DetectedLanguage.Name);
            Assert.AreEqual("french", myTransDict.DetectLanguage("Bonjour").DetectedLanguage.Name);
            Assert.AreEqual("french", myTransDict.DetectLanguage("est").DetectedLanguage.Name);
            Assert.IsNull(myTransDict.DetectLanguage(null));
            Assert.IsNull(myTransDict.DetectLanguage(""));
            Assert.AreEqual("french", myTransDict.DetectLanguage("  est  ").DetectedLanguage.Name);
        }

        [TestMethod()]
        public void AutoCompleteTest()
        {
            TranslationDictionary myTransDict = new TranslationDictionary();
            myTransDict.Languages = new Language[] {
                new Language("german", new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be"),
                    new Word("ist", "be"),
                    new Word("zu", "to"),
                    new Word("von", "of")
                }) 
            };

            string result = myTransDict.AutoComplete("hal");
        }

        [TestMethod()]
        public void SaveTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAvailableLanguagesTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void TranslateTest()
        {
            Assert.Fail();
        }
    }
}