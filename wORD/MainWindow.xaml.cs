using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using Path = System.IO.Path;

namespace wORD
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextRange Selection;
        public MainWindow()
        {
            
            InitializeComponent();
            CmbFontFamily.ItemsSource = Fonts.SystemFontFamilies;
            Rcb.FontSize = 12;
            Size.Text = "12";
        }
        private void CmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, CmbFontFamily.SelectedItem);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int newFontSize = Convert.ToInt32(Size.Text.ToString().Split()[0]);
            newFontSize += 1;
            if (newFontSize > 1)
                Btn2.IsEnabled = true;
            if (newFontSize==19)
                Btn1.IsEnabled = false;
            Rcb.FontSize = newFontSize;
            Size.Text = Convert.ToString(newFontSize);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int newFontSize = Convert.ToInt32(Size.Text.ToString().Split()[0]);
            newFontSize -= 1;
            if (newFontSize<19)
                Btn1.IsEnabled = true;
            if (newFontSize == 1)
                Btn2.IsEnabled = false;
            Rcb.FontSize = newFontSize;
            Size.Text = Convert.ToString(newFontSize);
            Rcb.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToDouble(newFontSize));
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem item = (ComboBoxItem)comboBox.SelectedItem;
            int newFontSize = Convert.ToInt32(item.Content.ToString().Split()[0]);
            Rcb.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, Convert.ToDouble(newFontSize));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.ExtraBold);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Segoe Print"));
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.BackgroundProperty, "#a4e0cf");
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Button1.Visibility = Visibility.Visible;
            Button2.Visibility = Visibility.Visible;
            Button3.Visibility = Visibility.Visible;
            Button4.Visibility = Visibility.Visible;
            Button5.Visibility = Visibility.Visible;
            Button6.Visibility = Visibility.Visible;
            Button7.Visibility = Visibility.Visible;
            Button8.Visibility = Visibility.Visible;
            //Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "Red");
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Rcb.Document.Blocks.Clear();
        }

        private void CommandBinding_Executed_1(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*|Word Documents (*.doc)|*.doc";
            if (sfd.ShowDialog() == true)
            {
                TextRange doc = new TextRange(Rcb.Document.ContentStart, Rcb.Document.ContentEnd);
                using (FileStream fs = File.Create(sfd.FileName))
                {
                    if (Path.GetExtension(sfd.FileName).ToLower() == ".rtf")
                        doc.Save(fs, DataFormats.Rtf);
                    else if (Path.GetExtension(sfd.FileName).ToLower() == ".txt")
                        doc.Save(fs, DataFormats.Text);
                    else
                        doc.Save(fs, DataFormats.Xaml);
                }
            }
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Selection = new TextRange(Rcb.Selection.Start, Rcb.Selection.End);
            Clipboard.SetText(Rcb.Selection.Text);
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            //Rcb.CaretPosition.Paragraph.Inlines.Add(Selection.Text);
            Rcb.Paste();
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            Rcb.Cut();
        }

        private void CommandBinding_Executed_2(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog opd = new OpenFileDialog();
            opd.Filter = "Text Files (*.txt)|*.txt|RichText Files (*.rtf)|*.rtf|XAML Files (*.xaml)|*.xaml|All files (*.*)|*.*|Word Documents (*.doc)|*.doc";
            if (opd.ShowDialog() == true)
            {
                string filePath = opd.FileName;
                StreamReader sr = new StreamReader(filePath);
                Rcb.CaretPosition.Paragraph.Inlines.Add(sr.ReadLine());
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "Red");
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            Button7.Visibility = Visibility.Hidden;
            Button8.Visibility = Visibility.Hidden;
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "Orange");
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            Button7.Visibility = Visibility.Hidden;
            Button8.Visibility = Visibility.Hidden;
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "Yellow");
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            Button7.Visibility = Visibility.Hidden;
            Button8.Visibility = Visibility.Hidden;
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "LightYellow");
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            Button7.Visibility = Visibility.Hidden;
            Button8.Visibility = Visibility.Hidden;
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "Purple");
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            Button7.Visibility = Visibility.Hidden;
            Button8.Visibility = Visibility.Hidden;
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "RoyalBlue");
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            Button7.Visibility = Visibility.Hidden;
            Button8.Visibility = Visibility.Hidden;
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "SeaGreen");
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            Button7.Visibility = Visibility.Hidden;
            Button8.Visibility = Visibility.Hidden;
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            Rcb.Selection.ApplyPropertyValue(TextElement.ForegroundProperty, "GreenYellow");
            Button1.Visibility = Visibility.Hidden;
            Button2.Visibility = Visibility.Hidden;
            Button3.Visibility = Visibility.Hidden;
            Button4.Visibility = Visibility.Hidden;
            Button5.Visibility = Visibility.Hidden;
            Button6.Visibility = Visibility.Hidden;
            Button7.Visibility = Visibility.Hidden;
            Button8.Visibility = Visibility.Hidden;
        }
    }
}
