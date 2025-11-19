using System.Windows;
using System.IO;
using System.Text.Json;
using _7_TRPO.Pages;

namespace _7_TRPO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ////Глобальные переменные
        //private Doctor CurrentDoctor = new Doctor();
        //private Doctor newDoctor = new Doctor();
        //private Patient CurrentPatient = new Patient();
        //private Patient newPatient = new Patient();
        //private Patient changePatient = new Patient();
        //private Patient findedPatient = new Patient();
        //private bool DoctorSigned = false;
        //private C info = new C();
        ////Завершить прием (Пациент)
        //private void ResetPatient(object sender, RoutedEventArgs e)
        //{
        //    CurrentPatient = new Patient();
        //    changePatient = new Patient(); 
        //    P_current.DataContext = CurrentPatient;
        //    P_Change.DataContext = changePatient;
        //}
        //private void ResetChanges(object sender, RoutedEventArgs e)
        //{
        //    string find = findedPatient.Id.ToString().PadLeft(7, '0');
            
        //      string json = File.ReadAllText("P_" + $"{find}" + ".json");
        //        changePatient = JsonSerializer.Deserialize<Patient>(json);
        //        P_Change.DataContext = changePatient;
            
        //}
        ////Зарегестрировать (Доктор)
        //private void NewDoctor(object sender, RoutedEventArgs e)
        //{
        //    string currentID = "";
        //    int count = 0;
        //    if (newDoctor.Name == "" || newDoctor.LastName == "" || newDoctor.MiddleName == "" || newDoctor.Specialisation == "" || newDoctor.Password == ""||newDoctor.RepeatPassword =="")
        //    {
        //        MessageBox.Show("Заполните все поля!");
        //        return;
        //    }
        //    if (Pass1.Text != Pass2.Text)
        //    {
        //        MessageBox.Show("Пароли не совпадают!");
        //        return;
        //    }
        //    if (!File.Exists("id.txt"))
        //    {
        //        currentID = "00001";
        //        File.WriteAllText("id.txt", currentID);
        //    }
        //    else
        //    {
        //        count = File.ReadAllLines("id.txt").Length;
        //        count++;
        //        newDoctor.Id = count;
        //        currentID = count.ToString().PadLeft(5, '0');
        //        File.AppendAllText("id.txt", "\n" + currentID);
        //    }
        //    string jsonString = JsonSerializer.Serialize(newDoctor);
        //    File.WriteAllText("D_" + currentID + ".json", jsonString);
        //    MessageBox.Show($"Успешно зарегистрирован, \n\nВАЖНО: Ваш ID для входа - {count}");
        //    info.Refresh();

        //}
        ////Вход (Доктор)
        //private void D_SignIn(object sender, RoutedEventArgs e)
        //{
        //    D_SignId.Text = D_SignId.Text.PadLeft(5, '0');
        //    if (!File.Exists("D_" + $"{D_SignId.Text}" + ".json"))
        //    {
        //        MessageBox.Show("Такой идентификатор пользователя не найден");
        //        return;
        //    }
        //    else
        //    {
        //        string json = File.ReadAllText("D_" + $"{D_SignId.Text}" + ".json");
        //        Doctor? findedDoctor = JsonSerializer.Deserialize<Doctor>(json);
        //        if (findedDoctor?.Password == D_SignPass.Password)
        //        {
        //            CurrentDoctor = findedDoctor;
        //            MessageBox.Show("Вход успешен!");
        //            DoctorSigned = true;
        //            D_current.DataContext = CurrentDoctor;
        //        }
        //    }
        //}
        ////Поиск (Пациент)
        //private void Search(object sender, RoutedEventArgs e)
        //{
        //    if (!DoctorSigned)
        //    {
        //        MessageBox.Show("Войдите как доктор!");
        //        return;
        //    }
        //    string find;
        //    find = findedPatient.Id.ToString().PadLeft(7, '0');
        //    if (!File.Exists("P_" + $"{find}" + ".json"))
        //    {
        //        MessageBox.Show("Такой пациент не найден");
        //        return;
        //    }
        //    else
        //    {
        //        string json = File.ReadAllText("P_" + $"{find}" + ".json");
        //        Patient? findedPacient = JsonSerializer.Deserialize<Patient>(json);
        //        CurrentPatient = findedPacient;
        //        changePatient = JsonSerializer.Deserialize<Patient>(json);
        //        P_current.DataContext = CurrentPatient;
        //        P_Change.DataContext = changePatient;
        //    }
        //}
        ////Начать новый прием (Пациент)
        //private void StartNewVisit(object sender, RoutedEventArgs e)
        //{
        //    CurrentPatient.LastDoctor = CurrentDoctor.Id;
        //    CurrentPatient.LastVisit = DateTime.Now;
        //}
        ////Сохранить (Прием пациента)
        //private void SaveNewData(object sender, RoutedEventArgs e)
        //{
        //    string json = JsonSerializer.Serialize(CurrentPatient);
        //    File.WriteAllText("P_" + $"{CurrentPatient.Id.ToString().PadLeft(7, '0')}" + ".json",json);
        //    Patient? patient = JsonSerializer.Deserialize<Patient>(json);
        //    changePatient = patient;
        //}
        ////Без кнопки
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new LoginPage());
            //DataContext = CurrentDoctor;
            //D_RegisterForm.DataContext = newDoctor;
            //P_RegisterForm.DataContext = newPatient;
            //D_current.DataContext = CurrentDoctor;
            //P_current.DataContext = CurrentPatient;
            //P_Change.DataContext = changePatient;
            //P_Search.DataContext = findedPatient;
            //InfoPanel.DataContext = info;
            //info.Refresh();
        }

        private void SwitchTheme(object sender, RoutedEventArgs e)
        {
            ThemeHelper.Toggle();
        }
        // //Изменить (Пациент)
        // private void ChangePatient(object sender, RoutedEventArgs e)
        // {
        //     changePatient.LastVisit = DateTime.Now;
        //     changePatient.LastDoctor = CurrentDoctor.Id;
        //     string id = changePatient.Id.ToString().PadLeft(7, '0');
        //     string jsonString = JsonSerializer.Serialize(changePatient);
        //     File.WriteAllText("P_" + id + ".json", jsonString);
        //     MessageBox.Show($"Пациент успешно изменен!");
        //     CurrentPatient = JsonSerializer.Deserialize<Patient>(jsonString);
        //     P_current.DataContext = CurrentPatient;
        // }
        ////Зарегистрировать (Пациент)
        // private void NewPatient(object sender, RoutedEventArgs e)
        // {
        //     if (!DoctorSigned)
        //     {
        //         MessageBox.Show("Сначала войдите как доктор");
        //         return;
        //     }
        //     string currentID = "";
        //     int count = 0;
        //     if (newPatient.Name == "" || newPatient.LastName == "" || newPatient.MiddleName == ""||P_BD.SelectedDate == null)
        //     {
        //         MessageBox.Show("Заполните все поля!");
        //         return;
        //     }
        //     if (!File.Exists("P_id.txt"))
        //     {
        //         currentID = "0000001";
        //         File.WriteAllText("P_id.txt", currentID);
        //     }
        //     else
        //     {
        //         count = File.ReadAllLines("P_id.txt").Length;
        //         count++;
        //         newPatient.LastVisit = DateTime.Now;
        //         newPatient.LastDoctor = CurrentDoctor.Id;

        //         newPatient.Id = count;
        //         currentID = count.ToString().PadLeft(7, '0');
        //         File.AppendAllText("P_id.txt", "\n" + currentID);
        //     }
        //     string jsonString = JsonSerializer.Serialize(newPatient);
        //     File.WriteAllText("P_" + currentID + ".json", jsonString);
        //     MessageBox.Show($"Пациент успешно зарегистрирован! \nЕго идентификатор - {currentID}");
        //     //PatientSelected = true;
        //     //CurrentPatient = newPatient;
        //     //P_current.DataContext = CurrentPatient;

        //     string json = File.ReadAllText("P_" + $"{currentID}" + ".json");
        //     changePatient = JsonSerializer.Deserialize<Patient>(json);
        //     P_Change.DataContext = changePatient;
        //     info.Refresh();
        // }

    }
}