using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using TranslationWCFService.Model;

namespace TranslationWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TranslatorService : ITranslatorService
    {
		public TranslationDictionary MyTranslationDictionary;
		public TranslatorService()
		{ 
			MyTranslationDictionary = TranslationDictionary.LoadNewDictionary("TranslationDatabaseResources.xml"); 
		}
		/// <param name="TextToDetect">the word or the first word of a sentence to detect the language from</param>
		/// <returns>The name of the detected language or EMPTY string if not found</returns>
		public string DetectLanguage(string TextToDetect)
		{
			if (String.IsNullOrEmpty(TextToDetect))
				return ""; // If you prefer brackets here, please let me know

			Language DetectedLanguage = MyTranslationDictionary.DetectLanguage(TextToDetect.Split(' ')[0]);
			if(DetectedLanguage != null)
			{
				return DetectedLanguage.Name;
			}
			return null;
		}

		/// <summary>
		/// returns the list of all available languages here.
		/// </summary>
		/// <returns></returns>
		public string[] GetLanguageList()
		{
			return MyTranslationDictionary.GetAvailableLanguages();
		}

		public string GetTranslation(TranslationParameters translationParameters)
		{
			return MyTranslationDictionary.Translate(translationParameters.TextToTranslate, translationParameters.TargetLanguage);
		}
	}
}
