using M120Projekt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für newEntryForm.xaml
    /// </summary>
    public partial class newEntryForm : UserControl
    {
        private Tools tools = new Tools();
        private Brush darkBrush = new SolidColorBrush(Color.FromArgb(255, 28, 40, 43));
        public newEntryForm()
        {
            InitializeComponent();
        }

        public void enableDarkMode()
        {
            lining.Background = darkBrush;
            tools.enableDarkMode(this);
        }

        public void disableDarkMode()
        {
            lining.Background = Brushes.White;
            tools.disableDarkMode(this);
        }

        public void enableButtons()
        {
            foreach (Button b in tools.FindVisualChildren<Button>(this).ToList())
            {
                b.IsEnabled = true;
            }
        }
        public void disableButtons()
        {
            foreach (Button b in tools.FindVisualChildren<Button>(this).ToList())
            {
                b.IsEnabled = false;
            }
        }

        public void enableButtonsIfInput()
        {
            Boolean correctInput = true;
            foreach (TextBox tb in tools.FindVisualChildren<TextBox>(this).ToList())
            {
                if (tb.Text == "" || tb.Text == null)
                {
                    correctInput = false;
                }
            }
            if (correctInput)
            {
                enableButtons();
            }
            else
            {
                disableButtons();
            }
        }
        private bool validatePrice()
        {
            Regex priceReg = new Regex(@"^([0-9]*|[0-9]*[.]{1}[0-9]{1,2})$");
            Match match = priceReg.Match(tbAmount.Text);
            try
            {
                if (match.Success)
                {
                    tbAmount.Foreground = Brushes.Green;
                    if (tbAmount.Text[tbAmount.Text.Length - 2] == '.')
                    {
                        tbAmount.Text += '0';
                        return true;
                    }
                    return true;
                }
                else
                {
                    tbAmount.Foreground = Brushes.Red;
                    priceWarningField.Content = "Invalid format!\nOnly use a divider\nif necessary";
                    return false;
                }
            } catch (Exception eo) {}
            return false;

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            disableButtons();
        }

        private void Tb_title_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonsIfInput();
        }

        private void Tb_amount_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonsIfInput();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            if (validatePrice())
            {
                try
                {
                    String title = tbTitle.Text;
                    Double amount = Convert.ToDouble(tbAmount.Text);
                    String currency = cbCurrency.Text;
                    String pm = cbPaymentMethod.Text;
                    DateTime dateTime = String.IsNullOrEmpty(dpDateTime.ToString()) ? DateTime.Now : dpDateTime.SelectedDate.Value;
                    info("Saving...");
                    API.Create(title, amount, currency, pm, dateTime);
                    success("Saved!");
                    Data.Global.mainWindow.refreshFinances();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    fail("Failed to save.");
                }
            }
        }

        private void info(String message)
        {
            messageField.Foreground = Brushes.Gray;
            messageField.Content = message;
        }

        private void success(String message)
        {
            messageField.Foreground = Brushes.Green;
            messageField.Content = message;
        }

        private void fail(String message)
        {
            messageField.Foreground = Brushes.Red;
            messageField.Content = message;
        }
        private void DpDateTime_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dpDateTime.IsDropDownOpen = true;
        }

        private void NewEntryLabel_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void DpDateTime_CalendarClosed(object sender, RoutedEventArgs e)
        {
            enableButtonsIfInput();
        }
    }
}

