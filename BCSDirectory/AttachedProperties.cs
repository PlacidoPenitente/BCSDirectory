﻿using System.Windows;
using System.Windows.Media;

namespace BCSDirectory
{
    public class AttachedProperties : DependencyObject
    {
        public static void SetMenuIcon(DependencyObject dependencyObject, ImageSource value)
        {
            dependencyObject.SetValue(MenuIconProperty, value);
        }

        public static ImageSource GetMenuIcon(DependencyObject dependencyObject)
        {
            return (ImageSource)dependencyObject.GetValue(MenuIconProperty);
        }

        // Using a DependencyProperty as the backing store for MenuIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MenuIconProperty =
            DependencyProperty.RegisterAttached("MenuIcon", typeof(ImageSource), typeof(AttachedProperties), new PropertyMetadata(new ImageBrush().ImageSource));


        public static void SetLabel(DependencyObject dependencyObject,
            string value)
        {
            dependencyObject.SetValue(LabelProperty, value);
        }

        public static string GetLabel(DependencyObject dependencyObject)
        {
            return (string)dependencyObject.GetValue(LabelProperty);
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached("Label", typeof(string), typeof(AttachedProperties),
                new PropertyMetadata(""));

    }
}
