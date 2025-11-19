using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.IO;
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
    /// Логика взаимодействия для Visit.xaml
    /// </summary>
    public partial class Visit : Page
    {
        Appointment NewAppointment { get; set; } = new Appointment();
        //Сохранить (Прием пациента)
        private void SaveNewData(object sender, RoutedEventArgs e)
        {
            NewAppointment.date = DateTime.Now;
            NewAppointment.Diagnosis = Per.currentPatient.Diagnosis;
            NewAppointment.Recomendations = Per.currentPatient.Recomendation;
            NewAppointment.doctor_id = Per.currentDoctor.Id;
            Per.currentPatient.AppointmentStories.Add(NewAppointment);
            string json = JsonSerializer.Serialize(Per.currentPatient);
            File.WriteAllText("P_" + $"{Per.currentPatient.Id.ToString().PadLeft(7, '0')}" + ".json", json);
        }
        //Завершить прием (Пациент)
        private void ResetPatient(object sender, RoutedEventArgs e)
        {
            Per.currentPatient = new Patient();
            NavigationService.GoBack();
        }
        private void DeletePatientVisit(object sender, RoutedEventArgs e)
        {
            if (Per.currentPatient.appointment != null)
            {
                Per.currentPatient.AppointmentStories.Remove(Per.currentPatient.appointment);
                string json = JsonSerializer.Serialize(Per.currentPatient);
                File.WriteAllText("P_" + $"{Per.currentPatient.Id.ToString().PadLeft(7, '0')}" + ".json", json);
                DataContext = Per.currentPatient;
            }
            else
            {
                MessageBox.Show("Выберите прием");
            }
        }
        public Visit()
        {
            InitializeComponent();
            DataContext = Per.currentPatient;
        }
        private void EditPatientInfo_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Patient_Edit());
        }
    }
}
