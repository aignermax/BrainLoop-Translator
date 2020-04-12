using BrainLoop_Translator.ServiceReference1;
using BrainLoop_Translator.ViewModel.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Controls;

namespace BrainLoop_Translator.ViewModel
{
    public class TextFieldTranslatorViewModel : INotifyPropertyChanged
    {
       
        public TextFieldTranslatorViewModel()
        {
            // Load Available Languages from WCF Service.
            MyTranslatorProxy = new TranslatorServiceClient();
            MyCMDTranslateNow = new CMDTranslateNow();
            MyCMDDetectLanguage = new CMDDetectLanguage();
            MyCMDGetAutoComplete = new CMDGetAutoComplete();
            MyCMDGetSimilarWords = new CMDGetSimilarWords();
            MyCMDAcceptAutoCompletedWord = new CMDAcceptAutoCompletedWord();

            ThreadPool.QueueUserWorkItem(new WaitCallback( (object param) => {
                string[] myLanguages = MyTranslatorProxy.GetLanguageList();
                AvailableLanguages = myLanguages.ToList<string>();
                if (AvailableLanguages.Count > 0)
                {
                    SelectedLanguage = AvailableLanguages[0];
                }
            }));
            
            DetectedLanguage = "";
            AutoCompleteSuggestion = "Write a word here to get it translated";
        }

        #region Properties
        public TranslatorServiceClient MyTranslatorProxy { get; set; }
        public CMDTranslateNow MyCMDTranslateNow { get; set; }
        public CMDDetectLanguage MyCMDDetectLanguage { get; set; }
        public CMDGetAutoComplete MyCMDGetAutoComplete { get; set; }
        public CMDGetSimilarWords MyCMDGetSimilarWords { get; set; }
        public CMDAcceptAutoCompletedWord MyCMDAcceptAutoCompletedWord { get; set; }

        private string _textToTranslate;
		public string TextToTranslate // text that has to be translated
		{
			get { return _textToTranslate; }
			set { _textToTranslate = value; 
                NotifyPropertyChanged();
                MyCMDTranslateNow.Execute(this);
                MyCMDDetectLanguage.Execute(this);
                MyCMDGetAutoComplete.Execute(this);
                MyCMDGetSimilarWords.Execute(this);
            }
		}

        private string _translatedText ="";
        public string TranslatedText
        {
            get { return _translatedText; }
            set { _translatedText = value;
                NotifyPropertyChanged();
            }
        }

        private List<string> _availableLanguages;
        public List<string> AvailableLanguages
        {
            get { return _availableLanguages; }
            set { _availableLanguages = value;
                NotifyPropertyChanged();
            }
        }

        private string _selectedLanguage ="";
        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set { _selectedLanguage = value;
                NotifyPropertyChanged();
                MyCMDTranslateNow.Execute(this);
            }
        }

        private string _detectedLanguage ="";
        public string DetectedLanguage
        {
            get { return _detectedLanguage; }
            set { _detectedLanguage = value;
                NotifyPropertyChanged();
            }
        }

        private string _autoCompleteSuggestion ="";
        public string AutoCompleteSuggestion
        {
            get { return _autoCompleteSuggestion; }
            set { _autoCompleteSuggestion = value;
                NotifyPropertyChanged();
            }
        }

        private string[] _similarWords;
        public string[] SimilarWords
        {
            get { return _similarWords; }
            set { _similarWords = value;
                NotifyPropertyChanged();
            }
        }

        private bool _isSimilarWordsOpen;

        public bool IsSimilarWordsOpen
        {
            get { return _isSimilarWordsOpen; }
            set { _isSimilarWordsOpen = value;
                NotifyPropertyChanged();
            }
        }



        #endregion


        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string info = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #endregion
    }
}
