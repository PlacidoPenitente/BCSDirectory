using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace BCSDirectory.Controls
{
    /// <summary>
    /// Interaction logic for MultiInput.xaml
    /// </summary>
    public partial class MultiInput : UserControl
    {
        public MultiInput()
        {
            InitializeComponent();
        }

        public static void SetItems(DependencyObject dependencyObject, ObservableCollection<string> value)
        {
            dependencyObject.SetValue(ItemsProperty, value);
        }

        public static ObservableCollection<string> GetItems(DependencyObject dependencyObject)
        {
            return (ObservableCollection<string>)dependencyObject.GetValue(ItemsProperty);
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.RegisterAttached("Items", typeof(ObservableCollection<string>), typeof(MultiInput),
                new PropertyMetadata(null));

        public static void SetLabelText(DependencyObject dependencyObject, string value)
        {
            dependencyObject.SetValue(LabelTextProperty, value);
        }

        public static string GetLabelText(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(LabelTextProperty);
        }

        // Using a DependencyProperty as the backing store for LabelText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.RegisterAttached("LabelText", typeof(string), typeof(MultiInput),
                new PropertyMetadata(null));

        private void EnterValue(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                var items = GetItems(this);
                if (!items.Any(x => x.ToLower().Trim().Equals(((TextBox)sender).Text.ToLower()))) if (!String.IsNullOrEmpty(((TextBox)sender).Text)) items.Add(((TextBox)sender).Text);
                SetItems(this, items);
                ((TextBox)sender).Text = "";
            }
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            var items = GetItems(this);
            items.Remove(((Button)sender).Content.ToString());
            SetItems(this, items);
        }
    }
}
