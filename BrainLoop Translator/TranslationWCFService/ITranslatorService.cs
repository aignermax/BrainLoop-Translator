using System.Runtime.Serialization;
using System.ServiceModel;

namespace TranslationWCFService
{
    [ServiceContract]
    public interface ITranslatorService
    {
        
        [OperationContract]
        string GetTranslation(string targetLanguage, string textTotranslate);

        [OperationContract]
        string DetectLanguage(string textToDetect);

        [OperationContract]
        string[] GetLanguageList();

        [OperationContract]
        string GetAutoComplete(string startsWith);

        [OperationContract]
        string [] FindSimilarWords(string referenceWord);
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
}
