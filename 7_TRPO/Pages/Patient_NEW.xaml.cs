using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace _7_TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для Patient_NEW.xaml
    /// </summary>
    public partial class Patient_NEW : Page
    {
        private Patient newPatient = new Patient();

        public Patient_NEW()
        {
            InitializeComponent();
            DataContext = newPatient;
        }

        private void NewPatient(object sender, RoutedEventArgs e)
        {
            if (Per.currentDoctor == null)
            {
                MessageBox.Show("Сначала войдите как доктор");
                return;
            }

            if (newPatient.Name == "" || newPatient.LastName == "" ||newPatient.PhoneNumber==""|| newPatient.MiddleName == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            string currentID = "";
            int count = 0;

            if (!File.Exists("P_id.txt"))
            {
                currentID = "0000001";
                File.WriteAllText("P_id.txt", currentID);
            }
            else
            {
                count = File.ReadAllLines("P_id.txt").Length;
                count++;
                currentID = count.ToString().PadLeft(7, '0');
                File.AppendAllText("P_id.txt", "\n" + currentID);
            }
            newPatient.Id = count;
            newPatient.AppointmentStories.Add(new Appointment { date = DateTime.Now, doctor_id = Per.currentDoctor.Id, Diagnosis = "Регистрация" });
            string jsonString = JsonSerializer.Serialize(newPatient);
            File.WriteAllText("P_" + currentID + ".json", jsonString);

            MessageBox.Show($"Пациент успешно зарегистрирован! \nЕго идентификатор - {currentID}");
            MainPage.ReadAllPatients();
            NavigationService.GoBack();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}

