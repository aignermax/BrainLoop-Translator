using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

[ServiceContract]
public interface ITranslatorService
{
	
	[OperationContract]
	string GetTranslation(TranslationParameters translationParameters);

	[OperationContract]
	string DetectLanguage(string TextToDetect);

	[OperationContract]
	string [] GetLanguageList();


}

[DataContract]
public class TranslationParameters
{
	public TranslationParameters(string targetLanguage, string textToTranslate)
	{
		this.TargetLanguage = targetLanguage;
		this.TextToTranslate = textToTranslate;
	}
	public string TargetLanguage { get; set; }
	public string TextToTranslate { get; set; }
}
