using exam_user58_V2.Models;
using Newtonsoft.Json;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace exam_user58_V2
{
    /// <summary>
    /// Логика взаимодействия для Window_Add.xaml
    /// </summary>
    public partial class Window_Add : Window
    {
        JsonClass jsonClass;
        string json;
        public Window_Add()
        {
            InitializeComponent();
            
        }
        public Window_Add(JsonClass jsonString)
        {
            InitializeComponent();
            this.jsonClass = jsonString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            try
            {
                var rent = new Json
                {
                    
                    surname = tbsurmame.Text,
                    name = tbname.Text,
                    patronymic = tbpatronymic.Text,
                    brandcar = tbbrandcar.Text,
                    colourcar = tbcolourcar.Text,
                    insurance = tbinsurance.Text,
                    oneday = tboneday.Text,
                    beginning = tbbeginning.ToString(),
                    end = tbend.ToString(),
                    Id = Convert.ToInt32(tbid.Text)

                };
                json = JsonConvert.SerializeObject(rent);
                Cleard();
                var tourList = JsonConvert.DeserializeObject<Json[]>(jsonClass.jsonString);
                mainWindow.DataResult.ItemsSource = tourList;
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        void Cleard()
        {
            try
            {
                if (jsonClass.jsonString != null)
                {
                    json = $"{json}]";
                    jsonClass.jsonString = jsonClass.jsonString.Replace("]", ",");
                    jsonClass.jsonString += json;
                }
                else
                    jsonClass.jsonString = $"[{json}]";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }


    }
    
}
