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
using System.IO;

namespace övning
{
    public partial class MainWindow : Window
    {
        List<string> meddelanden = new List<string>();
        static List<string> kursLista = new List<string>();
        static string[] savedKursArr;
        static string colour;       
        
        
        StyledWebsiteGenerator website = new StyledWebsiteGenerator("Klass A", colour, new string[] {"Hej"}, kursLista );
        public MainWindow()
        {
            InitializeComponent();
        }
        //Genererar html kod i textrutan
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            
            savedKursArr = kursLista.ToArray();
            var input = website.PrintPage();
            
            myText.Text = input;
        }
        //Sparar den genererade html-koden till .html-fil
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            string newFileName = newFilename.Text;
            File.WriteAllText($"{newFileName}.html", myText.Text);
        }    
        //Sparar varje enskild rad i textrutan som ett nytt element i listan "kursLista"
        private void addKurs_Click(object sender, RoutedEventArgs e)
        {
            var lines = kurserInput.Text.Split("\r\n");
            foreach (var line in lines)
            {
                kursLista.Add(line);
            }            
            kurserInput.Clear();
            MessageBox.Show("Kurserna sparades!");
        }
        //Rensar textrutan med html kod
        private void myClearButton_Click(object sender, RoutedEventArgs e)
        {
            myText.Clear();
        }
        //Vad som ska hända när man väljer en radio button
        private void rb1_Checked(object sender, RoutedEventArgs e)
        {
            colour = rb1.Content.ToString();
        }

        private void rb2_Checked(object sender, RoutedEventArgs e)
        {
            colour = rb2.Content.ToString();
        }

        private void rb3_Checked(object sender, RoutedEventArgs e)
        {
            colour = rb3.Content.ToString();
        }
    }
}
