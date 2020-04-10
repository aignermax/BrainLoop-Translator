using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslationWCFService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TranslationWCFService.Model.Tests
{
    [TestClass()]
    public class LanguageTests
    {
        [TestMethod()]
        public void FindSimilarWordsTest()
        {
            Word[] myWords = new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be"),
                    new Word("ist", "be"),
                    new Word("zu", "to"),
                    new Word("von", "of"),
                    new Word("und", "and"),
                    new Word("ich", "i"),
                    new Word("ein", "a"),
                    new Word("in", "in"),
                    new Word("dass", "that"),
                    new Word("habe", "have"),
                    new Word("es", "it"),
                    new Word("für", "for"),
                    new Word("nicht", "not"),
                    new Word("an", "on"),
                    new Word("baum", "tree"),
                    new Word("auto", "car"),
                    new Word("haus", "house")
            };
            Language myLanguage = new Language("german", myWords);
            myLanguage.FindSimilarWords("");
            myLanguage.FindSimilarWords("fdfadfdasf", -5, 100);
            myLanguage.FindSimilarWords(null);
            string[] similarWords = myLanguage.FindSimilarWords("hallo");
            Assert.IsTrue(similarWords.Length > 0);
            Assert.AreEqual("hallo", similarWords[0]); // hallo should be very similar to hallo. the rest should also be similar.. 
            Debug.WriteLine("More similar words that he found: ");
            foreach (string s in similarWords)
            {
                Debug.WriteLine(s);
            }


        }

        [TestMethod()]
        public void FindTranslationTest()
        {

            Word[] myWords = new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be"),
                    new Word("ist", "be"),
                    new Word("zu", "to")
            };
            Language myLanguage = new Language("german", myWords);
            Word translatedWord = myLanguage.FindTranslation("the");
            Assert.AreEqual(translatedWord.EnglishMeaning, "the");

            Assert.IsNull(myLanguage.FindTranslation(""));
            Assert.IsNull(myLanguage.FindTranslation(null));
            Assert.IsNull(myLanguage.FindTranslation(" fasdfds fa"));
            Assert.AreEqual("be", myLanguage.FindTranslation("    be").EnglishMeaning);
        }

        [TestMethod()]
        public void TryFindWordTest()
        {
            Word[] myWords = new Word[] {
                    new Word("hallo", "hello"),
                    new Word("der", "the"),
                    new Word("sein", "to be"),
                    new Word("ist", "be"),
                    new Word("zu", "to")
            };
            Language myLanguage = new Language("german", myWords);
            Assert.AreEqual("hallo" , myLanguage.TryFindWord("hallo").Notation);
            Assert.IsNull(myLanguage.TryFindWord(""));
        }
    }
}