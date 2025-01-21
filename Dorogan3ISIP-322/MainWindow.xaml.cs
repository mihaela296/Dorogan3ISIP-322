using System;
using System.Windows;
using System.Windows.Controls;

namespace Dorogan3ISIP_322
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fxTextBox.Text) || string.IsNullOrWhiteSpace(yTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            if (!double.TryParse(fxTextBox.Text, out double fx) || !double.TryParse(yTextBox.Text, out double y))
            {
                MessageBox.Show("Введите корректные числовые значения.");
                return;
            }

            double result = 0;

            if (fx * y > 0)
            {
                result = fx + Math.Pow(y, 2) - (fx * y);
            }
            else if (fx * y < 0)
            {
                result = fx + Math.Pow(y, 2) + (fx * y);
            }
            else // fx * y == 0
            {
                result = fx + Math.Pow(y, 2) + 1;
            }

            if (shRadioButton.IsChecked == true)
            {
                result = Math.Sinh(fx);
            }
            else if (x2RadioButton.IsChecked == true)
            {
                result = Math.Pow(fx, 2);
            }
            else if (exRadioButton.IsChecked == true)
            {
                result = Math.Exp(fx);
            }

            resultTextBox.Text = result.ToString();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            fxTextBox.Clear();
            yTextBox.Clear();
            resultTextBox.Clear();
            shRadioButton.IsChecked = false;
            x2RadioButton.IsChecked = false;
            exRadioButton.IsChecked = false;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите выйти?", "Подтверждение", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
