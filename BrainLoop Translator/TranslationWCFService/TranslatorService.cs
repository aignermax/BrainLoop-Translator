using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace TranslationWCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TranslatorService : ITranslatorService
    {
		public string DetectLanguage(string TextToDetect)
		{
			return "Hello World";
		}

		public string[] GetLanguageList()
		{
			return new string[] { "testlanguage1 from WCF" };
		}

		public string GetTranslation(TranslationParameters translationParameters)
		{
			translationParameters.TextToTranslate += " Is Translated Now, Yes! :) ";
			return translationParameters.TextToTranslate;
		}
	}
}
