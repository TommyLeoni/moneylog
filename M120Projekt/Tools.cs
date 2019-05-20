using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace M120Projekt
{
    class Tools
    {
        public Brush darkBrush = new SolidColorBrush(Color.FromArgb(255, 28, 40, 43));
        public IEnumerable<T> FindVisualChildren<T>(DependencyObject obj) where T : DependencyObject
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

        public void enableDarkMode(DependencyObject dependencyObject)
        {
            foreach (Label l in FindVisualChildren<Label>(dependencyObject).ToList())
            {
                l.Foreground = Brushes.White;
            }

            foreach (Button b in FindVisualChildren<Button>(dependencyObject).ToList())
            {
                b.Foreground = Brushes.White;
                b.Background = darkBrush;
            }

            foreach (Border bor in FindVisualChildren<Border>(dependencyObject).ToList())
            {
                bor.Background = darkBrush;
            }

            foreach (ComboBox com in FindVisualChildren<ComboBox>(dependencyObject).ToList())
            {
                com.Foreground = Brushes.White;
                com.Background = darkBrush;
            }

            foreach (Label l in FindVisualChildren<Label>(dependencyObject).ToList())
            {
                l.Foreground = Brushes.White;
            }
            foreach (TextBox tb in FindVisualChildren<TextBox>(dependencyObject).ToList())
            {
                tb.Background = darkBrush;
                tb.Foreground = Brushes.White;
            }
        }

        public void disableDarkMode(DependencyObject dependencyObject)
        {
            foreach (Label l in FindVisualChildren<Label>(dependencyObject).ToList())
            {
                l.Foreground = Brushes.Black;
            }

            foreach (Button b in FindVisualChildren<Button>(dependencyObject).ToList())
            {
                b.Foreground = darkBrush;
                b.Background = Brushes.LightGray;
            }

            foreach (Border bor in FindVisualChildren<Border>(dependencyObject).ToList())
            {
                bor.Background = Brushes.White;
            }

            foreach (ComboBox com in FindVisualChildren<ComboBox>(dependencyObject).ToList())
            {
                com.Foreground = Brushes.Black;
                com.Background = Brushes.White;
            }

            foreach (Label l in FindVisualChildren<Label>(dependencyObject).ToList())
            {
                l.Foreground = darkBrush;
            }

            foreach (TextBox tb in FindVisualChildren<TextBox>(dependencyObject).ToList())
            {
                tb.Background = Brushes.White;
            }
        }
    }
}
