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
            set { _name = value == null? null : value.Trim().ToLower(); }
        }

        public Language()
        { 
        }

        public string[] FindSimilarWords(string word)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// tries to find the word in this languages set.
        /// </summary>
        /// <param name="word">the word to search for</param>
        /// <returns>the found word or NULL if the word does not exist</returns>
        public Word TryFindWord(string word)
        {
            foreach(Word w in Words)
            {
                if(w.Notation == word.Trim().ToLower())
                {
                    return w;
                }
            }
            return null;
        }
    }
}
