﻿using System;
using System.Windows;
using System.Diagnostics;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Boolean isDark = false;
        private Tools tools = new Tools();
        private EditView editView = new EditView();
        private Brush darkBrush = new SolidColorBrush(Color.FromArgb(255, 28, 40, 43));

        public MainWindow()
        {
            InitializeComponent();
            Data.Global.context = new Data.Context();
            Data.Global.mainWindow = this;
            Data.Global.openNewEntryForm = this.openNewEntryForm;
            Data.Global.newEntryForm = this.newEntryForm;
            Data.Global.editView = this.editView;
            refreshFinances();
        }
        public void refreshFinances()
        {
            financesContainer.Items.Clear();
            foreach (Data.Finances entry in API.ReadAll())
            {
                financesContainer.Items.Add(entry);
            }
        }
        private void toggleDarkMode()
        {
            if (!isDark)
            {
                isDark = true;
                darkmodeIcon.Source = new BitmapImage(new Uri(@"images/switch_on_icon.ico", UriKind.Relative));
                tools.enableDarkMode();
            }
            else
            {
                isDark = false;
                darkmodeIcon.Source = new BitmapImage(new Uri(@"images/switch_off_icon.ico", UriKind.Relative));
                tools.disableDarkMode();
            }
        }

        private void DragBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DarkmodeToggle_Click(object sender, RoutedEventArgs e)
        {
            toggleDarkMode();
        }
        private void OpenNewEntryForm_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            newEntryForm.Visibility = Visibility.Visible;
            Data.Global.openNewEntryForm.Visibility = Visibility.Collapsed;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (financesContainer.SelectedIndex != -1)
                {
                    editView = new EditView(financesContainer.SelectedItem as Data.Finances);
                    Data.Global.editView = editView;
                    editView.Show();
                }
                else
                {
                    Console.WriteLine("No entry selected");
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }

        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (financesContainer.SelectedIndex != -1)
                {
                    Data.Finances financeEntry = financesContainer.SelectedItem as Data.Finances;
                    Console.WriteLine(financeEntry.EntryID);
                    financeEntry.Delete();
                    refreshFinances();
                }
                else
                {
                    Console.WriteLine("No entry selected");
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.ToString());
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            refreshFinances();
        }

        private void FinancesContainer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            Console.WriteLine("Saving settings ...");
        }

        private void LoadMoreBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
