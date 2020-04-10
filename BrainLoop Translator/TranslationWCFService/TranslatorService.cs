﻿using System;
using System.Collections.Generic;
using System.IO;
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
			string XMLFileName = "TranslationDataBaseResources.xml";
			if (File.Exists(XMLFileName))
			{
				MyTranslationDictionary = TranslationDictionary.LoadNewDictionary(XMLFileName);
			} else
			{
				DummyTranslationXMLGenerator mygen = new DummyTranslationXMLGenerator();
				mygen.GenerateDummyData(XMLFileName);
				MyTranslationDictionary = TranslationDictionary.LoadNewDictionary(XMLFileName);
			}
			
		}
		/// <param name="TextToDetect">the word or the first word of a sentence to detect the language from</param>
		/// <returns>The name of the detected language or EMPTY string if not found</returns>
		public string DetectLanguage(string TextToDetect)
		{
			if (String.IsNullOrEmpty(TextToDetect))
				return ""; // If you prefer brackets here, please let me know

			FindLanguageResults detectResults = MyTranslationDictionary.DetectLanguage(TextToDetect.Split(' ')[0]);
			if(detectResults != null && detectResults.DetectedLanguage != null)
			{
				return detectResults.DetectedLanguage.Name;
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

		public string GetTranslation(string targetLanguage, string textTotranslate)
		{
			return MyTranslationDictionary.Translate(textTotranslate, targetLanguage);
		}
	}
}
