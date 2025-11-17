using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
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

namespace _7_TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Patient_Edit : Page
    {
        private Patient _patient;
        public Patient_Edit()
        {
            InitializeComponent();
            _patient = Per.currentPatient;
            DataContext = _patient;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            string id = _patient.Id.ToString().PadLeft(7, '0');
            string json = JsonSerializer.Serialize(_patient);
            File.WriteAllText("P_" + id + ".json",json);
            MessageBox.Show("Данные сохранены");
            NavigationService.GoBack();
        } 
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
