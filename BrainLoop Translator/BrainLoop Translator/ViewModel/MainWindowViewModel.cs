using BrainLoop_Translator.ServiceReference1;
using BrainLoop_Translator.ViewModel.Commands;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BrainLoop_Translator.ViewModel
{
    public class MainWindowViewModel
    {
        public TextFieldTranslatorViewModel MyTextFieldTranslatorViewModel { get; set; }
        public CMDTranslateNow MyCMDTranslateNow { get; set; }
        public TranslatorServiceClient MyTranslatorProxy;
        public MainWindowViewModel()
        {
            Debug.WriteLine("Start");
            MyCMDTranslateNow = new CMDTranslateNow();
            MyTextFieldTranslatorViewModel = new TextFieldTranslatorViewModel();
            MyTextFieldTranslatorViewModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == nameof(MyTextFieldTranslatorViewModel.TextToTranslate))
                {
                    MyCMDTranslateNow.Execute( new CMDTranslateNowParams(MyTextFieldTranslatorViewModel.TextToTranslate, 
                        MyTextFieldTranslatorViewModel.SelectedLanguage));
                }
                if(e.PropertyName == nameof(MyTextFieldTranslatorViewModel.SelectedLanguage))
                {
                    Debug.WriteLine("language Changed"); // run Command here .
                }
            };

            // Load Available Languages from WCF Service.
            MyTranslatorProxy = new TranslatorServiceClient();
            string[] myLanguages = MyTranslatorProxy.GetLanguageList();
            MyTextFieldTranslatorViewModel.AvailableLanguages = myLanguages.ToList<string>();
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
