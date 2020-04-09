using System;
using System.ServiceModel.Web;

public class TranslatorService : ITranslatorService
{
	public string DetectLanguage(string TextToDetect)
	{
		return "Hello Worrld";
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

