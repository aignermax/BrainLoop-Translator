using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslationWCFService.Model
{
    public class Word
    {
        public Word() : this("","")
        {
        }
        public Word(string notation, string englishMeaning)
        {
            this.Notation = notation;
            this.EnglishMeaning = englishMeaning;
        }
        /// <summary>
        /// for optimization: the words will be trimmed and lowercase in our "databse" in order to match them faster.
        /// </summary>
        private string _notation;
        public string Notation
        {
            get { return _notation; }
            set { _notation = value.Trim().ToLower(); }
        }

        public string EnglishMeaning { get; set; } // for translation purposes
    }
}
