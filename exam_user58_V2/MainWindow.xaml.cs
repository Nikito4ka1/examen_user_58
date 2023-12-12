using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections;
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
using System.Data.SqlClient;
using static exam_user58_V2.Models.Json;
using System.Xml.Linq;
using exam_user58_V2.Models;

namespace exam_user58_V2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        JsonClass jsonClass = new JsonClass();
        string fileName;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Open(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            try
            {
                var json = File.ReadAllText(openFileDialog.FileName);
                var procat = JsonConvert.DeserializeObject<Json[]>(json);
                DataResult.ItemsSource = procat;
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click_Save(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.ShowDialog();
                string filename = saveFileDialog.FileName;
                File.WriteAllText($"{filename}.json", jsonClass.jsonString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            Window_Add Window = new Window_Add();
            Window.Show();
        }

        private void Button_Click_Pravka(object sender, RoutedEventArgs e)
        {
            Window_Pravka Window = new Window_Pravka();
            Window.Show();
        }

        private void Button_Click_Sort(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                File.WriteAllText(fileName, jsonClass.jsonString);
                MessageBox.Show("Файл сохранен");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
    
}
