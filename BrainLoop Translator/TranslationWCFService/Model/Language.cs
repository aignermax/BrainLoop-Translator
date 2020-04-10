using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationWCFService.Model
{
    public class Language
    {
        public Word[] Words { get; set; }
        private string _name;
        public string Name // the spelling of the language. e.g. "english".
        {
            get { return _name; }
            set { _name = value == null? "" : value.Trim().ToLower(); }
        }

        public Language() : this("" , null)
        {
        }
        public Language(string name , Word[] wordarray)
        {
            this.Name = name;
            if(wordarray == null)
            {
                Words = new Word[0];
            } else
            {
                Words = wordarray;
            }
        }

        /// <summary>
        /// finds similar words of the same language
        /// </summary>
        /// <param name="word"></param>
        /// <returns>array of similar words</returns>
        public string[] FindSimilarWords(string word)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// returns a Word in this language, that has the specified englishMeaning or Null if not found
        /// </summary>
        /// <param name="englishMeaning"></param>
        /// <returns></returns>
        public Word FindTranslation(string englishMeaning)
        {
            if (string.IsNullOrWhiteSpace(englishMeaning) || Words == null || Words.Length < 1) return null;
            return Array.Find(Words, n => n.EnglishMeaning.Equals(englishMeaning));
        }
        /// <summary>
        /// tries to find the word in this languages set.
        /// </summary>
        /// <param name="word">the word to search for</param>
        /// <returns>the found word or NULL if the word does not exist</returns>
        public Word TryFindWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word)) return null;
            word = word.Trim().ToLower();
            return Array.Find<Word>(Words, n => n.Notation.Equals(word));
        }
    }
}
