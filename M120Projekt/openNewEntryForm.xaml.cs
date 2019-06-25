
using System.Windows.Controls;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für OpenNewEntryForm.xaml
    /// </summary>
    public partial class OpenNewEntryForm : UserControl
    {
        public OpenNewEntryForm()
        {
            InitializeComponent();
        }

        private void Image_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Data.Global.newEntryForm.Visibility = System.Windows.Visibility.Visible;
            Data.Global.openNewEntryForm.Visibility = System.Windows.Visibility.Collapsed;
        }
    }
}

