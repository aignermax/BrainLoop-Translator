using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace BrainLoop_Translator.ViewModel.Converters
{

    /// <summary>
    /// converter to clip around rounded things z.b. 
    /// http://stackoverflow.com/questions/5649875/how-to-make-the-border-trim-the-child-elements
    /// usage:
    /// <Border CornerRadius="10">
    ///    <Border.Clip>
    ///        <MultiBinding Converter = "{StaticResource BorderClipConverter}" >
    ///            < Binding Path="ActualWidth"
    ///                        RelativeSource="{RelativeSource Self}"/>
    ///            <Binding Path = "ActualHeight"
    ///                        RelativeSource="{RelativeSource Self}"/>
    ///            <Binding Path = "CornerRadius"
    ///                        RelativeSource="{RelativeSource Self}"/>
    ///        </MultiBinding>
    ///    </Border.Clip>
    ///</Border>
    /// </summary>
    public class BorderClipConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length == 3 && values[0] is double && values[1] is double && values[2] is CornerRadius)
            {
                var width = (double)values[0];
                var height = (double)values[1];

                if (width < Double.Epsilon || height < Double.Epsilon)
                {
                    return Geometry.Empty;
                }

                var radius = (CornerRadius)values[2];
                var clip = new RectangleGeometry(new Rect(0, 0, width, height), radius.TopLeft, radius.TopLeft);
                clip.Freeze();

                return clip;
            }

            return DependencyProperty.UnsetValue;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
