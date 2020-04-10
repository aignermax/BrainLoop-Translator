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
                }) ,
                new Language("chinese", new Word[] {
                    new Word("nihau", "hello"),
                    new Word("li", "the"),
                    new Word("lihe", "to be"),
                    new Word("me", "be"),
                    new Word("maho", "to"),
                    new Word("wuvong", "of")
                })
            };

            string result = myTransDict.AutoComplete("wu");
            Assert.AreEqual("wuvong", result);
            result = myTransDict.AutoComplete("hall");
            Assert.AreEqual("hallo", result);
        }

        [TestMethod()]
        public void SaveTest()
        {
            TranslationDictionary myTransDict = new TranslationDictionary();
            myTransDict.Languages = new Language[] {
                new Language("german", new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be")
                }) ,
                new Language("chinese", new Word[] {
                    new Word("nihau", "hello"),
                    new Word("li", "the"),
                    new Word("lihe", "to be")
                })
            };
            string path = Path.GetTempFileName();
            File.Delete(path);
            myTransDict.Save(path);

            // test if file is  loadable.
            TranslationDictionary myLoadedTransDict = TranslationDictionary.LoadNewDictionary(path);
            Assert.AreEqual(2, myLoadedTransDict.Languages.Length);
            Assert.AreEqual("german", myLoadedTransDict.DetectLanguage("hallo").DetectedLanguage.Name);
            Assert.AreEqual("chinese", myLoadedTransDict.DetectLanguage("nihau").DetectedLanguage.Name);
            Assert.AreEqual(3, myLoadedTransDict.DetectLanguage("nihau").DetectedLanguage.Words.Length);

            // test some exceptions if you do something wrong (enter null etc. should throw exception)
            bool didThrowArgumentNulException = false;
            try
            {
                myTransDict.Save(null);
            }
            catch (ArgumentNullException ane)
            {
                didThrowArgumentNulException = true;
            }
            Assert.IsTrue(didThrowArgumentNulException);

            bool didThrowIOException = false;
            try
            {
                myTransDict.Save(Path.GetTempFileName()); // here the file already exists.
            }
            catch (IOException ex)
            {
                didThrowIOException = true;
            }
            Assert.IsTrue(didThrowIOException, "Save command should throw an exception when the file already exists (no override)");

        }

        [TestMethod()]
        public void GetAvailableLanguagesTest()
        {
            TranslationDictionary myTransDict = new TranslationDictionary();
            myTransDict.Languages = new Language[] {
                new Language("german", new Word[] {}) ,
                new Language("chinese", new Word[] {})
            };

            string[] availablelangs = myTransDict.GetAvailableLanguages();
            Assert.AreEqual(Array.Find(availablelangs, n => n == "german"), "german");
            Assert.AreEqual(Array.Find(availablelangs, n => n == "chinese"), "chinese");
        }

        [TestMethod()]
        public void TranslateTest()
        {
            TranslationDictionary myTransDict = new TranslationDictionary();
            myTransDict.Languages = new Language[] {
                new Language("german", new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be")
                }) ,
                new Language("chinese", new Word[] {
                    new Word("nihau", "hello"),
                    new Word("li", "the"),
                    new Word("lihe", "to be")
                })
            };
            Assert.AreEqual("hallo", myTransDict.Translate("nihau", "german"));
            Assert.AreEqual("li", myTransDict.Translate("der", "chinese"));
        }

        [TestMethod()]
        public void GuessLanguageTest()
        {
            TranslationDictionary myTransDict = new TranslationDictionary();
            myTransDict.Languages = new Language[] {
                new Language("german", new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be")
                }) ,
                new Language("chinese", new Word[] {
                    new Word("nihau", "hello"),
                    new Word("li", "the"),
                    new Word("lihe", "to be")
                })
            };

            Assert.AreEqual("chinese", myTransDict.GuessLanguage("niha").Name);
            Assert.AreEqual("chinese", myTransDict.GuessLanguage("lih").Name);
            Assert.AreEqual("chinese", myTransDict.GuessLanguage("lile").Name);
            Assert.AreEqual("german", myTransDict.GuessLanguage("seid").Name);
            Assert.AreEqual("german", myTransDict.GuessLanguage("seil").Name);
            Assert.AreEqual("german", myTransDict.GuessLanguage("hallö").Name);
            Assert.AreEqual("german", myTransDict.GuessLanguage("dea").Name);
        }
    }
}