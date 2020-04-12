using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslationWCFService.Helper;

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
        /// <param name="maxResultElements">the maximum length of the result array</param>
        /// <param name="minSimilarity">the minimum required similarity of the result words. 1.0d = must be same word, 0.0d = all words accepted</param>
        /// <returns>array of similar words or empty array if nothing was found</returns>
        public string[] FindSimilarWords(string word , int maxResultElements = 5, double minSimilarity = 0.2d)
        {
            if (string.IsNullOrWhiteSpace(word) || Words == null || Words.Length == 0 || maxResultElements < 1  )
                return new string[0];

            // 1. calculate the amount of steps to transform one string into the other
            Dictionary<Word, double> wordTransformCosts = new Dictionary<Word, double>();
            // go through the Words and look if one is similar and sort them by relevance. 
            int WordCounter = 0;
            foreach(Word w in Words)
            {
                double similarity = SimilarityCalculator.CalculateSimilarity(word, w.Notation);
                if(similarity >= minSimilarity) // it should  be at least 20% similar
                {
                    wordTransformCosts.Add(w, similarity);
                    WordCounter++;
                }
                if (WordCounter >= maxResultElements) // take 5 words at max.
                {
                    break;
                }
            }
            string[] SimilarWords = new string[WordCounter];
            // sort that dictionary, convert the words into the string array.
            int j = 0;
            foreach (KeyValuePair<Word, double> SortedWord in wordTransformCosts.OrderByDescending(key => key.Value))
            {
                SimilarWords[j] = SortedWord.Key.Notation;
                j++;
            }
            return SimilarWords;
        }

        /// <summary>
        /// returns a Word in this language, that has the specified englishMeaning or Null if not found
        /// </summary>
        /// <param name="englishMeaning"></param>
        /// <returns></returns>
        public Word FindTranslation(string englishMeaning)
        {
            if (string.IsNullOrWhiteSpace(englishMeaning) || Words == null || Words.Length < 1) return null;
            englishMeaning = englishMeaning.Trim().ToLower();
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
