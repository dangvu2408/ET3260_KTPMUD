using System.Windows.Controls;
using System.Windows;

namespace ET3260_Project
{
    public static class PlaceholderBehavior
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached(
                "Placeholder",
                typeof(string),
                typeof(PlaceholderBehavior),
                new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public static string GetPlaceholder(DependencyObject obj) => (string)obj.GetValue(PlaceholderProperty);

        public static void SetPlaceholder(DependencyObject obj, string value) => obj.SetValue(PlaceholderProperty, value);

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.GotFocus += (s, ev) =>
                {
                    if (textBox.Text == (string)e.NewValue)
                        textBox.Clear();
                };

                textBox.LostFocus += (s, ev) =>
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                        textBox.Text = (string)e.NewValue;
                };

                if (string.IsNullOrEmpty(textBox.Text))
                    textBox.Text = (string)e.NewValue;
            }
            else if (d is PasswordBox passwordBox)
            {
                passwordBox.GotFocus += (s, ev) =>
                {
                    if (passwordBox.Password == (string)e.NewValue)
                        passwordBox.Clear();
                };

                passwordBox.LostFocus += (s, ev) =>
                {
                    if (string.IsNullOrEmpty(passwordBox.Password))
                        passwordBox.Password = (string)e.NewValue;
                };

                if (string.IsNullOrEmpty(passwordBox.Password))
                    passwordBox.Password = (string)e.NewValue;
            }
        }
    }
}
