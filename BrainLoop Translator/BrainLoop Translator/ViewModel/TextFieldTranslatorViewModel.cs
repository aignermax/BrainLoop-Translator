using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace BrainLoop_Translator.ViewModel
{
    public class TextFieldTranslatorViewModel : INotifyPropertyChanged
    {
        public TextFieldTranslatorViewModel()
        {
            Debug.WriteLine("TextFieldTranslator ViewModel created");
        }
		private string _textToTranslate;
		public string TextToTranslate // text that has to be translated
		{
			get { return _textToTranslate; }
			set { _textToTranslate = value; 
                NotifyPropertyChanged(); 
            }
		}

        private string _translatedText;
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

        private string _selectedLanguage;
        public string SelectedLanguage
        {
            get { return _selectedLanguage; }
            set { _selectedLanguage = value;
                NotifyPropertyChanged();
            }
        }

        private string _detectedLanguage;
        public string DetectedLanguage
        {
            get { return _detectedLanguage; }
            set { _detectedLanguage = value;
                NotifyPropertyChanged();
            }
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
