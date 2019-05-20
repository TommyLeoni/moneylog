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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für openNewEntryForm.xaml
    /// </summary>
    public partial class openNewEntryForm : UserControl
    {
        Tools tools = new Tools();
        public openNewEntryForm()
        {
            InitializeComponent();
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        public void enableDarkMode()
        {
            lining.Background = tools.darkBrush;
            tools.enableDarkMode(this);
        }
        public void disableDarkMode()
        {
            lining.Background = Brushes.White;
            tools.disableDarkMode(this);
        }
    }
}

