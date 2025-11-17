using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.IO;
namespace _7_TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для D_registration.xaml
    /// </summary>
    public partial class D_registration : Page
    {
        private Doctor newDoctor = new Doctor();
        public D_registration()
        {
            InitializeComponent();
        }
        private void NewDoctor(object sender, RoutedEventArgs e)
        {
            string currentID = "";
            int count = 0;
            if (newDoctor.Name == "" || newDoctor.LastName == "" || newDoctor.MiddleName == "" || newDoctor.Specialisation == "" || newDoctor.Password == "" || newDoctor.RepeatPassword == "")
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }
            if (Pass1.Text != Pass2.Text)
            {
                MessageBox.Show("Пароли не совпадают!");
                return;
            }
            if (!File.Exists("id.txt"))
            {
                currentID = "00001";
                File.WriteAllText("id.txt", currentID);
            }
            else
            {
                count = File.ReadAllLines("id.txt").Length;
                count++;
                newDoctor.Id = count;
                currentID = count.ToString().PadLeft(5, '0');
                File.AppendAllText("id.txt", "\n" + currentID);
            }
            string jsonString = JsonSerializer.Serialize(newDoctor);
            File.WriteAllText("D_" + currentID + ".json", jsonString);
            MessageBox.Show($"Успешно зарегистрирован, \n\nВАЖНО: Ваш ID для входа - {count}");
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
