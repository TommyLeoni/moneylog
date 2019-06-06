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
    /// Interaktionslogik für OpenNewEntryForm.xaml
    /// </summary>
    public partial class OpenNewEntryForm : UserControl
    {
        Tools tools = new Tools();
        public OpenNewEntryForm()
        {
            InitializeComponent();
            Data.Global.openNewEntryForm = this;
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

