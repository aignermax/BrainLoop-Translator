using System;
using System.Collections.Generic;
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

namespace BrainLoop_Translator.View.UserControls
{
    /// <summary>
    /// Interaktionslogik für TextBoxWithHelpText.xaml
    /// </summary>
    public partial class TextBoxWithHelpText : UserControl
    {
        public TextBoxWithHelpText()
        {
            InitializeComponent();
        }

        #region DependencyProperties


        // ob die Textbox gerade im Focus ist.
        public bool HasFocus
        {
            get { return (bool)GetValue(HasFocusProperty); }
            set { SetValue(HasFocusProperty, value); }
        }
        public static readonly DependencyProperty HasFocusProperty =
            DependencyProperty.Register("HasFocus", typeof(bool), typeof(TextBoxWithHelpText), new PropertyMetadata(false));
        
        // der Helptext 
        public string HelpText
        {
            get { return (string)GetValue(HelpTextProperty); }
            set { SetValue(HelpTextProperty, value); }
        }
        public static readonly DependencyProperty HelpTextProperty =
            DependencyProperty.Register("HelpText", typeof(string), typeof(TextBoxWithHelpText), new PropertyMetadata(""));

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(TextBoxWithHelpText), new PropertyMetadata("" ));

        public Visibility VisibilityErrorTxt
        {
            get { return (Visibility)GetValue(VisibilityErrorTxtProperty); }
            set { SetValue(VisibilityErrorTxtProperty, value); }
        }
        public static readonly DependencyProperty VisibilityErrorTxtProperty =
            DependencyProperty.Register("VisibilityErrorTxt", typeof(Visibility), typeof(TextBoxWithHelpText), new PropertyMetadata(Visibility.Collapsed));

        public string ErrorTxt
        {
            get { return (string)GetValue(ErrorTxtProperty); }
            set { SetValue(ErrorTxtProperty, value); }
        }
        public static readonly DependencyProperty ErrorTxtProperty =
            DependencyProperty.Register("ErrorTxt", typeof(string), typeof(TextBoxWithHelpText), new PropertyMetadata(""));
                   
        public ICommand CmdEnterPressed
        {
            get { return (ICommand)GetValue(CmdEnterPressedProperty); }
            set { SetValue(CmdEnterPressedProperty, value); }
        }                                                                                                                        
        public static readonly DependencyProperty CmdEnterPressedProperty =
            DependencyProperty.Register("CmdEnterPressed", typeof(ICommand), typeof(TextBoxWithHelpText), new PropertyMetadata(null));
                   
        public object CmdEnterParameter
        {
            get { return (object)GetValue(CmdEnterParameterProperty); }
            set { SetValue(CmdEnterParameterProperty, value); }
        }
        public static readonly DependencyProperty CmdEnterParameterProperty =
            DependencyProperty.Register("CmdEnterParameter", typeof(object), typeof(TextBoxWithHelpText), new PropertyMetadata(null));

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool), typeof(TextBoxWithHelpText), new PropertyMetadata(false));

        #endregion

        // prevent Mouse from MoveDragDrop
        private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void root_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                if (CmdEnterPressed != null)
                {
                    CmdEnterPressed.Execute(CmdEnterParameter);
                }
            }
        }
    }
}
