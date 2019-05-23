﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tools tools = new Tools();
        private Boolean isDark = false;

        public MainWindow()
        {

        }


        private IEnumerable<T> FindVisualChildren<T>(DependencyObject obj) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is T)
                {
                    yield return (T)child;
                }
                else
                {
                    var childOfChild = FindVisualChildren<T>(child);
                    if (childOfChild != null)
                    {
                        foreach (var subchild in childOfChild)
                        {
                            yield return subchild;
                        }
                    }
                }
            }
        }
        private void toggleDarkMode()
        {
            Brush darkBrush = new SolidColorBrush(Color.FromArgb(255, 28, 40, 43));

            if (!isDark)
            {
                isDark = true;
                darkmodeIcon.Source = new BitmapImage(new Uri(@"images/switch_on_icon.ico", UriKind.Relative));
                tools.enableDarkMode(newEntryForm);
                tools.enableDarkMode(openNewEntryForm);
                tools.enableDarkMode(MainCanvas);
                mainLining.Background = darkBrush;

                /* foreach (Label l in FindVisualChildren<Label>(mainCanvas).ToList())
                {
                    l.Foreground = Brushes.White;
                }

                foreach (Button b in FindVisualChildren<Button>(mainCanvas).ToList())
                {
                    b.Foreground = Brushes.White;
                }

                foreach (Border bor in FindVisualChildren<Border>(mainCanvas).ToList().Concat(FindVisualChildren<Border>(entryContainer)))
                {
                    bor.Background = darkBrush;
                }

                foreach (ComboBox com in FindVisualChildren<ComboBox>(entryContainer).ToList())
                {
                    com.Foreground = Brushes.White;
                    com.Background = darkBrush;
                } */
            }
            else
            {
                isDark = false;
                darkmodeIcon.Source = new BitmapImage(new Uri(@"images/switch_off_icon.ico", UriKind.Relative));
                newEntryForm.disableDarkMode();
                openNewEntryForm.disableDarkMode();

                /* foreach (Label l in FindVisualChildren<Label>(mainCanvas).ToList())
                {
                    l.Foreground = Brushes.Black;
                }

                foreach (Button b in FindVisualChildren<Button>(mainCanvas).ToList())
                {
                    b.Foreground = darkBrush;
                }

                foreach (Border bor in FindVisualChildren<Border>(mainCanvas).ToList().Concat(FindVisualChildren<Border>(entryContainer)))
                {
                    bor.Background = Brushes.White;
                } */
            }
        }

        private void DragBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DarkmodeToggle_Click(object sender, RoutedEventArgs e)
        {
            toggleDarkMode();
        }

        private void Currency_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Currency_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void Currency_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void PaymentMethod_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void PaymentMethod_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void OpenNewEntryForm_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            openNewEntryForm.Visibility = Visibility.Collapsed;
            newEntryForm.Visibility = Visibility.Visible;
        }

        private void NewEntryForm_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            openNewEntryForm.Visibility = Visibility.Visible;
            newEntryForm.Visibility = Visibility.Collapsed;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            editEntry editWindow = new editEntry();
            editWindow.Show();
        }
    }
}