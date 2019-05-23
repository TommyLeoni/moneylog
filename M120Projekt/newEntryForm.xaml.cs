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
        private void validatePrice()
        {
            Regex priceReg = new Regex(@"^([0-9]*|[0-9]*[.]{1}[0-9]{1,2})$");
            Match match = priceReg.Match(tbAmount.Text);
            if (match.Success)
            {
                tbAmount.Foreground = Brushes.Green;
                if (tbAmount.Text[tbAmount.Text.Length - 2] == '.')
                {
                    tbAmount.Text += '0';
                }
            }
            else
            {
                tbAmount.Foreground = Brushes.Red;
                priceWarningField.Content = "Invalid format!\nOnly use a divider\nif necessary";
            }

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

        private void Tb_date_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonsIfInput();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            validatePrice();
        }
    }
}

