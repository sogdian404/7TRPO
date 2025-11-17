using System;
using System.Collections.Generic;
using System.Linq;
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
using System.IO;

namespace _7_TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class LoginPage : Page
    {

        public LoginPage()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            D_SignId.Text = D_SignId.Text.PadLeft(5, '0');
            if (!File.Exists("D_" + $"{D_SignId.Text}" + ".json"))
            {
                MessageBox.Show("Такой идентификатор пользователя не найден");
                return;
            }
            else
            {
                string json = File.ReadAllText("D_" + $"{D_SignId.Text}" + ".json");
                Doctor? findedDoctor = JsonSerializer.Deserialize<Doctor>(json);
                if (findedDoctor?.Password == D_SignPass.Password)
                {
                    Per.currentDoctor = findedDoctor;
                    NavigationService.Navigate(new MainPage());
                    /*
                    currentdoctor = findeddoctor;
                    messagebox.show("вход успешен!");
                    doctorsigned = true;
                    d_current.datacontext = currentdoctor;*/
                }
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new D_registration());
        }
    }
}
