using BrainLoop_Translator.ServiceReference1;
using BrainLoop_Translator.ViewModel.Commands;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Threading;

namespace BrainLoop_Translator.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public TextFieldTranslatorViewModel MyTextFieldTranslatorViewModel { get; set; }
        public MainWindowViewModel()
        {
            Debug.WriteLine("Start");
            MyTextFieldTranslatorViewModel = new TextFieldTranslatorViewModel();
        }


        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string info = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #endregion
    }
}
