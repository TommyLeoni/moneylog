using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für editEntry.xaml
    /// </summary>
    public partial class editEntry : Window
    {
        Tools tools = new Tools();
        public editEntry()
        {
            InitializeComponent();
        }
        private void initialState()
        {
            fillInData();
            disableButtons();
        }
        private void disableButtons()
        {
            foreach (Button b in tools.FindVisualChildren<Button>(this).ToList())
            {
                b.IsEnabled = false;
            }
        }
        private void enableButtons()
        {
            foreach (Button b in tools.FindVisualChildren<Button>(this).ToList())
            {
                b.IsEnabled = true;
            }
        }
        private void fillInData()
        {
            // Placeholder for future connection w/ database
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
        private void throwWarning(String warning)
        {
            warningField.Content = warning;
        }
        private void Lining_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            initialState();
        }
        private void TbTitle_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonsIfInput();
        }
        private void TbAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonsIfInput();
        }
        private void TbDateTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            enableButtonsIfInput();
        }
    }
}
