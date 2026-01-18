using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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
using static System.Collections.Specialized.BitVector32;
using _7_TRPO.Converters;
namespace _7_TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public static ObservableCollection<Patient> P_List { get; set; } = new ObservableCollection<Patient>();
        public Patient SelectedPatient { get; set; }

        public MainPage()
        {
            InitializeComponent();
            DataContext = this;
            D_current.DataContext = Per.currentDoctor;
            ReadAllPatients();
        }
        private void DeletePatient(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
            {
               
                File.Delete("P_"+SelectedPatient.Id.ToString().PadLeft(7,'0')+".json");
                ReadAllPatients();
            }
            else
            {
                MessageBox.Show("Выберите пациента");
            }
        }
        public static void ReadAllPatients()
        {
            P_List.Clear();
            if (!File.Exists("P_id.txt")) return;

            string[] ids = File.ReadAllLines("P_id.txt");
            foreach (string id in ids)
            {
                if (File.Exists("P_" + id + ".json"))
                {
                    string json = File.ReadAllText("P_" + id + ".json");
                    Patient patient = JsonSerializer.Deserialize<Patient>(json);
                    P_List.Add(patient);
                }
            }
        }

        private void CreatePatient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Patient_NEW());
        }

        private void StartVisit_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
            {
                Per.currentPatient = SelectedPatient;
                NavigationService.Navigate(new Visit());
            }
            else
            {
                MessageBox.Show("Выберите пациента");
            }
        }

        private void EditInfo_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedPatient != null)
            {
                Per.currentPatient = SelectedPatient;
                NavigationService.Navigate(new Patient_Edit());
            }
            else
            {
                MessageBox.Show("Выберите пациента");
            }
        }

    }
}
