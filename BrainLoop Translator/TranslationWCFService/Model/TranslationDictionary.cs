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
        public FindLanguageResults DetectLanguage(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return null; // sanity check
            word = word.Trim().ToLower(); // cleanup
            foreach (Language language in Languages)
            {
                Word detectedWord = language.TryFindWord(word);
                if (detectedWord != null)
                {
                    return new FindLanguageResults(language, detectedWord);
                }
            }
            return null; // language not found
        }
        /// <summary>
        /// returns the matching autocomplete word.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>the matching word, or empty string, of nothing was found</returns>
        public string AutoComplete(string text)
        {
            foreach (Language l in Languages)
            {
                foreach(Word w in l.Words)
                {
                    if( w.Notation.StartsWith(text))
                    {
                        return w.Notation;
                    }
                }
            }
            return "";
        }
        /// <summary>
        /// Saves the current Object to XML for us to load it later on.
        /// If the file already exists, exception will be thrown.
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

        /// <returns>the languages available in the Dictionary or Empty String Array, if no langauge available</returns>
        public string[] GetAvailableLanguages()
        {
            if (Languages == null || Languages.Length < 1) return new string[0];
            return Languages.Select(l => l.Name).ToArray();
        }

        /// <summary>
        /// translates a word into the targetlanguage and returns a string of the new translated word.
        /// </summary>
        /// <param name="wordToTranslate">source word to translate</param>
        /// <param name="targetLanguageName">the name of the target language</param>
        /// <returns>translated word as string or empty string if not found</returns>
        public string Translate(string wordToTranslate, string targetLanguageName)
        {
            if (string.IsNullOrWhiteSpace(wordToTranslate) || string.IsNullOrWhiteSpace(targetLanguageName)) return "";

            targetLanguageName = targetLanguageName.Trim().ToLower();
            wordToTranslate = wordToTranslate.Trim().ToLower();
            FindLanguageResults SourceDetectionResults = DetectLanguage(wordToTranslate);
            if(SourceDetectionResults != null && SourceDetectionResults.DetectedWord != null)
            {
                Language TargetLanguage = Array.Find(Languages, n => n.Name.Equals(targetLanguageName));
                if (TargetLanguage != null)
                {
                    Word translation = TargetLanguage.FindTranslation(SourceDetectionResults.DetectedWord.EnglishMeaning);
                    if(translation != null)
                    {
                        return translation.Notation;
                    } else
                    {
                        return "";
                    }
                }
            }
            return "";
        }
    }
    public class FindLanguageResults
    {
        public FindLanguageResults(Language detectedLanguage, Word detectedWord)
        {
            this.DetectedLanguage = detectedLanguage;
            this.DetectedWord = detectedWord;
        }
        public Language DetectedLanguage { get; set; }
        public Word DetectedWord { get; set; }
    }
}
