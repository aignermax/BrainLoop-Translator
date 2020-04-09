using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TranslationWCFService.Model
{
    public class TranslationDictionary
    {
        public TranslationDictionary() { } // constructor for serialization
        public Language [] Languages { get; set; }

        /// <summary>
        /// detects the language of a word
        /// </summary>
        /// <param name="word">the word to detect the langauge from</param>
        /// <returns>the detected Language or null if language was not found</returns>
        public Language DetectLanguage(string word)
        {
            if (word == null) return null; // sanity check
            word = word.Trim().ToLower();
            foreach (Language language in Languages)
            {
                if (language.TryFindWord(word) != null)
                {
                    return language;
                }
            }
            return null;
        }
        /// <summary>
        /// returns the matching autocomplete word.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string AutoComplete(string text)
        {
            // probably with this https://www.codeproject.com/Articles/44920/A-Reusable-WPF-Autocomplete-TextBox
            // find similar strings in list
            // https://stackoverflow.com/questions/51130295/c-sharp-find-like-strings-in-array
            throw new NotImplementedException();
        }
        /// <summary>
        /// Saves the current Object to XML for us to load it later on.
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.CreateNew))
            {
                XmlSerializer XML = new XmlSerializer(typeof(TranslationDictionary));
                XML.Serialize(stream, this);
            }
        }

        public static TranslationDictionary LoadNewDictionary (string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Open))
            {
                XmlSerializer XML = new XmlSerializer(typeof(TranslationDictionary));
                return (TranslationDictionary) XML.Deserialize(stream);
            }
        }

        /// <returns>the languages available in the Dictionary</returns>
        public string[] GetAvailableLanguages()
        {
            string[] languageList = new string[Languages.Length];
            for (int i = 0; i < Languages.Length; i++)
            {
                languageList[i] = Languages[i].Name;
            }
            return languageList;
        }

        public string Translate(string wordToTranslate, string targetLanguage)
        {
            targetLanguage = targetLanguage.Trim().ToLower();
            wordToTranslate = wordToTranslate.Trim().ToLower();
            Language detectedLanguage = DetectLanguage(wordToTranslate);
            detectedLanguage.TryFindWord(wordToTranslate);
            // find the source Langauge
            // find the source word in the language
            // find the targetlanguage
            // find the word with the same meaning in the target language
        }
    }
}
