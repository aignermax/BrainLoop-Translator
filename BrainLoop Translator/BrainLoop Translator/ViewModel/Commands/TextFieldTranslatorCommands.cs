using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BrainLoop_Translator.ViewModel.Commands
{
    public class CMDTranslateNowParams
    {
        public CMDTranslateNowParams (string textToTranslate, string selectedLanguage)
        {
            this.TextToTranslate = textToTranslate;
            this.SelectedLanguage = selectedLanguage;
        }
        string TextToTranslate;
        string SelectedLanguage;
    }
    public class CMDTranslateNow : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if (parameter is CMDTranslateNowParams)
            {
                return true;
            }
            return false;
        }

        public void Execute(object parameter)
        {
            CMDTranslateNowParams myparams = (CMDTranslateNowParams)parameter;
            throw new NotImplementedException();
        }
    }
}
