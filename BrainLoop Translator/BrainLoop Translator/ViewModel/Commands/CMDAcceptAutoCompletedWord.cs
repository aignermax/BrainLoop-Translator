using BrainLoop_Translator.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace BrainLoop_Translator.ViewModel.Commands
{
    public class CMDAcceptAutoCompletedWord : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            object[] myparams = (object[])parameter;
            if (parameter is object[])
            {
                if (myparams.Length == 3 && myparams[0] is string && myparams[1] is string && myparams[2] is TextFieldTranslatorView)
                {
                    return true;
                }
            }
            return false;
        }

        public void Execute(object parameter)
        {

            ThreadPool.QueueUserWorkItem(new WaitCallback((object stateinfo) =>
            {
                object[] stateInfos = (object[])parameter;
                string AutoCompleteSuggestion = (string)stateInfos[0];
                string TextToTranslate = (string)stateInfos[1];
                TextFieldTranslatorView myview = (TextFieldTranslatorView)stateInfos[2];
                if (string.IsNullOrEmpty(AutoCompleteSuggestion) == false)
                {
                    // dispatch back into main 
                    myview.Dispatcher.Invoke(() => {
                        myview.Text = AutoCompleteSuggestion;
                    });
                }
            }));
        }
    }
}
