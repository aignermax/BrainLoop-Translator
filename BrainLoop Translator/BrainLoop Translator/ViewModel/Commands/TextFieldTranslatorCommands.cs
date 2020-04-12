using BrainLoop_Translator.ServiceReference1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            ThreadPool.QueueUserWorkItem(new WaitCallback((object stateInfo) =>
            { // make async
                // translate
                TextFieldTranslatorViewModel myTextFieldTransViewModel = (TextFieldTranslatorViewModel)parameter;
                myTextFieldTransViewModel.TranslatedText = myTextFieldTransViewModel.MyTranslatorProxy.GetTranslation(myTextFieldTransViewModel.SelectedLanguage, myTextFieldTransViewModel.TextToTranslate);
            }));
        }
    }

    public class CMDDetectLanguage : ICommand
    {
        public event EventHandler CanExecuteChanged;
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
            ThreadPool.QueueUserWorkItem(new WaitCallback((object stateInfo) =>
            {
                // detect language
                TextFieldTranslatorViewModel myTextFieldTransViewModel = (TextFieldTranslatorViewModel)parameter;
                myTextFieldTransViewModel.DetectedLanguage = myTextFieldTransViewModel.MyTranslatorProxy.DetectLanguage(myTextFieldTransViewModel.TextToTranslate);
            }));
        }
    }

    public class CMDGetAutoComplete: ICommand
    {
        public event EventHandler CanExecuteChanged;

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
            ThreadPool.QueueUserWorkItem(new WaitCallback((object stateInfo) =>
            {
                TextFieldTranslatorViewModel myTextFieldTransViewModel = (TextFieldTranslatorViewModel)parameter;
                myTextFieldTransViewModel.AutoCompleteSuggestion = myTextFieldTransViewModel.MyTranslatorProxy.GetAutoComplete(myTextFieldTransViewModel.TextToTranslate);
            }));
        }
    }
    public class CMDAcceptAutoCompletedWord : ICommand
    {
        public event EventHandler CanExecuteChanged;
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
            ThreadPool.QueueUserWorkItem(new WaitCallback((object stateInfo) =>
            {
                TextFieldTranslatorViewModel myTextFieldTransViewModel = (TextFieldTranslatorViewModel)parameter;
                if (string.IsNullOrEmpty(myTextFieldTransViewModel.AutoCompleteSuggestion) == false)
                {
                    myTextFieldTransViewModel.TextToTranslate = myTextFieldTransViewModel.AutoCompleteSuggestion;
                }
            }));
        }
    }
    public class CMDGetSimilarWords : ICommand
    {
        public event EventHandler CanExecuteChanged;

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
            ThreadPool.QueueUserWorkItem(new WaitCallback((object stateInfo) =>
            {
                TextFieldTranslatorViewModel myTextFieldTransViewModel = (TextFieldTranslatorViewModel)parameter;
                myTextFieldTransViewModel.SimilarWords = myTextFieldTransViewModel.MyTranslatorProxy.FindSimilarWords(myTextFieldTransViewModel.TextToTranslate);
            }));
        }
    }
}
