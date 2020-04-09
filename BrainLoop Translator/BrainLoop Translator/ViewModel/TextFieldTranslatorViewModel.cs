using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BrainLoop_Translator.ViewModel
{
    public class TextFieldTranslatorViewModel
    {
        public TextFieldTranslatorViewModel()
        {
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


        #region NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string info = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }

        #endregion
    }
}
