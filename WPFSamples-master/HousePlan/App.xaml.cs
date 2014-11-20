using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Threading;
using System.Globalization;
using System.Windows.Markup;
using System.Windows.Input;
using System.Windows.Controls;

namespace HousePlan
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");
            FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement), new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            EventManager.RegisterClassHandler(typeof(TextBox), UIElement.PreviewMouseWheelEvent, new MouseWheelEventHandler(OnTextBoxMouseWheel));
        }

        private static void OnTextBoxMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var textbox = sender as TextBox;
            if (textbox == null || textbox.IsReadOnly)
                return;

            double value;
            if (double.TryParse(textbox.Text, out value))
            {
                double multiplier = value < 1 ? 1000 : (value < 10 ? 100 : 10);
                textbox.Text = (value + (e.Delta / multiplier)).ToString();
            }
        }
    }
}
