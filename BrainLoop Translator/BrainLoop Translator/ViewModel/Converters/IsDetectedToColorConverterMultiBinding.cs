using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BrainLoop_Translator.ViewModel.Converters
{
    //IsDetectedToColorConverterMultiBinding
    /// <summary>
    /// value0 = DetectedLanguage
    /// value1 = BrushSuccess
    /// value2 = BrushFail
    /// value3 = TextToTranslate
    /// </summary>
    public class IsDetectedToColorConverterMultiBinding : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            Brush result = new SolidColorBrush(new Color());
            if (values.Length > 3)
            {
                if(values[0] == null)
                {
                    values[0] = "";
                }
                if(values[3] == null)
                {
                    values[3] = "";
                }
                if (values[0] is string && values[1] is Brush && values[2] is Brush && values[3] is string)
                {
                    string DetectedLanguage = (string)values[0];
                    Brush BrushDetectionSuccess = (Brush)values[1];
                    Brush BrushDetectionFail = (Brush)values[2];
                    string TextToTranslate = (string)values[3];
                    if (string.IsNullOrWhiteSpace(DetectedLanguage) == false)
                    {
                        result = BrushDetectionSuccess;
                    }
                    else if(string.IsNullOrWhiteSpace(TextToTranslate) == false)
                    {
                        result = BrushDetectionFail;
                    }
                    else
                    {
                        result = BrushDetectionSuccess;
                    }

                }
            }
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
