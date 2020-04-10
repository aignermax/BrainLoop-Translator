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
        public CMDTranslateNow MyCMDTranslateNow { get; set; }
        public CMDDetectLanguage MyCMDDetectLanguage { get; set; }
        public TranslatorServiceClient MyTranslatorProxy;
        public MainWindowViewModel()
        {
            Debug.WriteLine("Start");
            MyTextFieldTranslatorViewModel = new TextFieldTranslatorViewModel();
            MyTextFieldTranslatorViewModel.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
            {
                if (e.PropertyName == nameof(MyTextFieldTranslatorViewModel.TextToTranslate))
                {
                    MyCMDTranslateNow.Execute(MyTextFieldTranslatorViewModel);
                    MyCMDDetectLanguage.Execute(MyTextFieldTranslatorViewModel);
                }
                if (e.PropertyName == nameof(MyTextFieldTranslatorViewModel.SelectedLanguage))
                {
                    Debug.WriteLine("language Changed");
                }
            };

            // Load Available Languages from WCF Service.
            MyTranslatorProxy = new TranslatorServiceClient();
            string[] myLanguages = MyTranslatorProxy.GetLanguageList();
            MyTextFieldTranslatorViewModel.AvailableLanguages = myLanguages.ToList<string>();
            if (MyTextFieldTranslatorViewModel.AvailableLanguages.Count > 0)
            {
                MyTextFieldTranslatorViewModel.SelectedLanguage = MyTextFieldTranslatorViewModel.AvailableLanguages[0];
            }


            MyCMDTranslateNow = new CMDTranslateNow(MyTranslatorProxy);
            MyCMDDetectLanguage = new CMDDetectLanguage(MyTranslatorProxy);
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
