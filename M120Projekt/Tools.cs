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
        public IEnumerable<T> FindAllVisualChildren<T>() where T : DependencyObject
        {
            foreach (DependencyObject obj in getAllDependencyObjects())
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
        }

        public void enableDarkMode()
        {
            foreach (Label l in FindAllVisualChildren<Label>())
            {
                l.Foreground = Brushes.White;
                l.Background = Brushes.Transparent;
            }
            foreach (Button b in FindAllVisualChildren<Button>())
            {
                b.Foreground = Brushes.White;
                b.Background = darkBrush;
            }
            foreach (Border bor in FindAllVisualChildren<Border>())
            {
                bor.Background = darkBrush;
            }
            foreach (TextBox tb in FindAllVisualChildren<TextBox>())
            {
                tb.Foreground = Brushes.White;
                tb.Background = darkBrush;
            }
            foreach (ComboBox com in FindAllVisualChildren<ComboBox>())
            {
                com.Foreground = Brushes.White;
                com.Background = darkBrush;
            }
            foreach (TextBlock tb in FindAllVisualChildren<TextBlock>())
            {
                tb.Foreground = Brushes.White;
            }
            Data.Global.mainWindow.MainLining.Background = darkBrush;
            Data.Global.mainWindow.financesContainer.Foreground = Brushes.White;
            Data.Global.mainWindow.CloseButtonIcon.Effect = new InvertEffect();
            Data.Global.mainWindow.SettingsButtonIcon.Effect = new InvertEffect();
            Data.Global.mainWindow.RefreshButtonIcon.Effect = new InvertEffect();
            Data.Global.openNewEntryForm.AddIcon.Effect = new InvertEffect();
        }

        public void disableDarkMode()
        {
            foreach (Label l in FindAllVisualChildren<Label>())
            {
                l.Foreground = darkBrush;
                l.Background = Brushes.Transparent;
            }
            foreach (Button b in FindAllVisualChildren<Button>())
            {
                b.Foreground = darkBrush;
                b.Background = Brushes.White;
                b.BorderBrush = Brushes.Transparent;
            }
            foreach (Border bor in FindAllVisualChildren<Border>())
            {
                bor.Background = Brushes.White;
            }
            foreach (TextBox tb in FindAllVisualChildren<TextBox>())
            {
                tb.Background = Brushes.White;
                tb.Foreground = darkBrush;
            }
            foreach (ComboBox com in FindAllVisualChildren<ComboBox>())
            {
                com.Foreground = darkBrush;
                com.Background = Brushes.White;
            }
            foreach (TextBlock tb in FindAllVisualChildren<TextBlock>())
            {
                tb.Foreground = darkBrush;
            }
            Data.Global.mainWindow.MainLining.Background = Brushes.White;
            Data.Global.mainWindow.financesContainer.Foreground = darkBrush;
            Data.Global.mainWindow.CloseButtonIcon.Effect = null;
            Data.Global.mainWindow.SettingsButtonIcon.Effect = null;
            Data.Global.mainWindow.RefreshButtonIcon.Effect = null;
            Data.Global.openNewEntryForm.AddIcon.Effect = null;
        }
        public List<DependencyObject> getAllDependencyObjects()
        {
            return new List<DependencyObject>() {
                Data.Global.newEntryForm,
                Data.Global.editView.MainGrid,
                Data.Global.mainWindow.MainCanvas,
                Data.Global.newEntryForm.MainGrid,
                Data.Global.openNewEntryForm.Container
            };
        }
    }
}
