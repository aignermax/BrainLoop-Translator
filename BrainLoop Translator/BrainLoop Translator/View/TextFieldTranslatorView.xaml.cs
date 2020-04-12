using BrainLoop_Translator.ViewModel.Commands;
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
            MyCMDAcceptAutoCompletedWord = new CMDAcceptAutoCompletedWord();
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



        public string[] SimilarWords
        {
            get { return (string[])GetValue(SimilarWordsProperty); }
            set { SetValue(SimilarWordsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SimilarWords.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SimilarWordsProperty =
            DependencyProperty.Register("SimilarWords", typeof(string[]), typeof(TextFieldTranslatorView), 
                new PropertyMetadata(new string[0], (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            {
                TextFieldTranslatorView myview = (TextFieldTranslatorView)d;
                if(e.NewValue != null && ((object[]) e.NewValue).Length > 0)
                {
                    myview.IsSimilarWordsOpen = true;
                } else
                {
                    myview.IsSimilarWordsOpen = false;
                }
            }));


        public string SimilarWordsSelectedItem
        {
            get { return (string)GetValue(SimilarWordsSelectedItemProperty); }
            set { SetValue(SimilarWordsSelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SimilarWordsSelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SimilarWordsSelectedItemProperty =
            DependencyProperty.Register("SimilarWordsSelectedItem", typeof(string), typeof(TextFieldTranslatorView), 
                new PropertyMetadata("", (DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            {
                TextFieldTranslatorView myview = (TextFieldTranslatorView)d;
                myview.Text = (string)e.NewValue;
            }));

        public bool IsSimilarWordsOpen
        {
            get { return (bool)GetValue(IsSimilarWordsOpenProperty); }
            set { SetValue(IsSimilarWordsOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsSimilarWordsOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSimilarWordsOpenProperty =
            DependencyProperty.Register("IsSimilarWordsOpen", typeof(bool), typeof(TextFieldTranslatorView), 
                new PropertyMetadata(false,(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
                {
                    TextFieldTranslatorView myview = (TextFieldTranslatorView)d;
                    if((bool)e.NewValue== false)
                    {
                        myview.MainTextBox.Focus(); // go back to TextView when combobox is closed (clicked away)
                    }
                }));



        public string AutoCompleteSuggestion
        {
            get { return (string)GetValue(AutoCompleteSuggestionProperty); }
            set { SetValue(AutoCompleteSuggestionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AutoCompleteSuggestion.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoCompleteSuggestionProperty =
            DependencyProperty.Register("AutoCompleteSuggestion", typeof(string), typeof(TextFieldTranslatorView), new PropertyMetadata(""));


        public string Text 
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextFieldTranslatorView), new PropertyMetadata(""));

        public CMDAcceptAutoCompletedWord MyCMDAcceptAutoCompletedWord
        {
            get { return (CMDAcceptAutoCompletedWord)GetValue(MyCMDAcceptAutoCompletedWordProperty); }
            set { SetValue(MyCMDAcceptAutoCompletedWordProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyCMDAcceptAutoCompletedWord.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyCMDAcceptAutoCompletedWordProperty =
            DependencyProperty.Register("MyCMDAcceptAutoCompletedWord", typeof(CMDAcceptAutoCompletedWord), typeof(TextFieldTranslatorView), new PropertyMetadata(null));



        public string DetectedLanguage
        {
            get { return (string)GetValue(DetectedLanguageProperty); }
            set { SetValue(DetectedLanguageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DetectedLanguage.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DetectedLanguageProperty =
            DependencyProperty.Register("DetectedLanguage", typeof(string), typeof(TextFieldTranslatorView), new PropertyMetadata(""));


    }
}
