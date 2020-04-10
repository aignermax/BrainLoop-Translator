using BrainLoop_Translator.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BrainLoop_Translator.ViewModel.Commands
{
    public class CMDTranslateNow : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private TranslatorServiceClient translatorServiceClient;
        public CMDTranslateNow(TranslatorServiceClient WCFservice) {
            translatorServiceClient = WCFservice;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null && parameter is TextFieldTranslatorViewModel)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            // translate
            TextFieldTranslatorViewModel myTextFieldTransViewModel = (TextFieldTranslatorViewModel)parameter;
            myTextFieldTransViewModel.TranslatedText = translatorServiceClient.GetTranslation(myTextFieldTransViewModel.SelectedLanguage, myTextFieldTransViewModel.TextToTranslate);
            Debug.WriteLine("Translate now: " + myTextFieldTransViewModel.TranslatedText);
        }
    }

    public class CMDDetectLanguage : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private TranslatorServiceClient translatorServiceClient;
        public CMDDetectLanguage(TranslatorServiceClient WCFservice)
        {
            translatorServiceClient = WCFservice;
        }

        public bool CanExecute(object parameter)
        {
            if (parameter != null && parameter is TextFieldTranslatorViewModel)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            // detect language
            TextFieldTranslatorViewModel myTextFieldTransViewModel = (TextFieldTranslatorViewModel)parameter;
            myTextFieldTransViewModel.DetectedLanguage = translatorServiceClient.DetectLanguage(myTextFieldTransViewModel.TextToTranslate);
            Debug.WriteLine("detected Language: " + myTextFieldTransViewModel.DetectedLanguage);
        }
    }
}
