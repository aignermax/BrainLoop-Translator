using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BrainLoop_Translator.View
{
    /// <summary>
    /// Interaktionslogik für TranslatorTextView.xaml
    /// </summary>
    public partial class TextFieldTranslatorView : UserControl
    {
        public TextFieldTranslatorView()
        {
            InitializeComponent();
        }


        public string TextInside
        {
            get { return (string)GetValue(TextToTranslateProperty); }
            set { SetValue(TextToTranslateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextToTranslate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextToTranslateProperty =
            DependencyProperty.Register("TextInside", typeof(string), typeof(TextFieldTranslatorView), new PropertyMetadata(""));
    }
}
