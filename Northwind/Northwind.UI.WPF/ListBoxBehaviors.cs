using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Northwind.UI.WPF
{
    static class ListBoxBehaviors
    {

        public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.RegisterAttached(
            "DoubleClickCommand", typeof (ICommand), typeof (ListBoxBehaviors),
            new PropertyMetadata(null, DoubleClickCommand_PropertyChanged));

        private static void DoubleClickCommand_PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = (UIElement) d;
            if (e.OldValue != null)
            {
                target.RemoveHandler(ListBox.MouseDoubleClickEvent,new RoutedEventHandler(Listbox_DoubleClick));
            }
            if (e.NewValue != null)
            {
                target.AddHandler(ListBox.MouseDoubleClickEvent,new RoutedEventHandler(Listbox_DoubleClick));
            }
        }

        private static void Listbox_DoubleClick(object sender, RoutedEventArgs e)
        {
            var doubleClickCommand = GetDoubleClickCommand((ListBox)sender);
            if (doubleClickCommand.CanExecute(e))
            {
                doubleClickCommand.Execute(e);
            }
        }

        public static void SetDoubleClickCommand(UIElement element, ICommand value)
        {
            element.SetValue(DoubleClickCommandProperty, value);
        }

        public static ICommand GetDoubleClickCommand(DependencyObject element)
        {
            return (ICommand) element.GetValue(DoubleClickCommandProperty);
        }
    }
}
