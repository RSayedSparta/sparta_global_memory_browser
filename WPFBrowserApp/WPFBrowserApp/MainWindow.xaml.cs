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

namespace WPFBrowserApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            List<string> allLinesText = File.ReadAllLines("URLList.txt").ToList();
            foreach (var item in allLinesText)
            {
                comboData.Add(item);
            }

            foreach (var item in comboData)
            {
                myComboBox.Items.Add(item);
            }
            
        }

        List<object> comboData = new List<object>();
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //comboData.Add(myComboBox.ToString());
            
            //MessageBox.Show(myComboBox.SelectedItem.ToString());
            //var comboBox = (ComboBox)sender;
            //if (comboBox.SelectedItem != null)
            //{
              
            //    foreach (var item in comboData)
            //    {
            //        if (item == myComboBox.SelectedItem.ToString())
            //        {
            //             Browser.Navigate(myComboBox.SelectedItem.ToString());
            //        }
                    
            //    }
                
            //}          
  
            
        }

        public void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string newURL = myComboBox.Text;
                comboData.Add(newURL);
                myComboBox.Items.Add(newURL);
                this.save(newURL);
                Browser.Navigate(newURL);
            }
        }

        public void populateCombo()
        {
            comboData.Add("https://github.com/RSayedSparta/");
            comboData.Add("http://www.google.com");
            comboData.Add("http://www.amazon.com");
            comboData.Add("http://www.ebay.co.uk");
            
        }

        public void save(string url)
        {
            TextWriter tw = new StreamWriter("URLList.txt");
            
            tw.WriteLine(url);

            tw.Close();

        }
    }

    public class URL
    {
        public URL()
        {

        }

        private string url;
        public string urlTxt
        {
            get
            {
                return url;
            }

            set
            {
                if (value == url)
                    return;
            }
        }
    }
}
