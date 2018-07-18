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
            Root.DataContext = this;
        }

        public ObservableCollection<string> Items
        {
            get => (ObservableCollection<string>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ObservableCollection<string>), typeof(MultiInput), new PropertyMetadata(null));



        public string Label
        {
            get => (string)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(MultiInput), new PropertyMetadata(null));



        private void EnterValue(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (!Items.Any(x => x.ToLower().Trim().Equals(((TextBox)sender).Text.ToLower()))) if (!String.IsNullOrEmpty(((TextBox)sender).Text)) Items.Add(((TextBox)sender).Text);
                ((TextBox)sender).Text = "";
            }
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            Items.Remove(((Button)sender).Content.ToString());
        }
    }
}
