using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrainLoop_Translator.ViewModel
{
    public class MainWindowViewModel
    {
        public TextFieldTranslatorViewModel MyTextFieldTranslatorViewModel { get; set; }
        public MainWindowViewModel()
        {
            Debug.WriteLine("Start");
            MyTextFieldTranslatorViewModel = new TextFieldTranslatorViewModel();
            MyTextFieldTranslatorViewModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == nameof(MyTextFieldTranslatorViewModel.TextToTranslate))
                {
                    // Start Translation with WCF Client 
                    // do so every 3 Seconds (dis-bounce)
                }
            };
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
