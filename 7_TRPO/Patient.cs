using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _7_TRPO
{
    public class Patient : INotifyPropertyChanged
    {
        private ObservableCollection<Appointment> appointmentStories = new();
        [JsonIgnore]
        public Appointment appointment { get; set; } = new Appointment();
        
        public ObservableCollection<Appointment> AppointmentStories
        {
            get => appointmentStories;
            set
            {
                appointmentStories = value; OnPropertyChanged();
            }
        }

        private string _phoneNumber = "";

        public string PhoneNumber
        {
            get => _phoneNumber;
            set { _phoneNumber = value; OnPropertyChanged(); }
        }

        private int _id = 0;

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        private string _name = "";

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        private string _lastName = "";

        public string LastName
        {
            get => _lastName;
            set { _lastName = value; OnPropertyChanged(); }
        }

        private string _middleName = "";

        public string MiddleName
        {
            get => _middleName;
            set { _middleName = value; OnPropertyChanged(); }
        }

        private string _diagnosis = "";

        public string Diagnosis
        {
            get => _diagnosis;
            set
            {
                _diagnosis = value;
                OnPropertyChanged();
            }
        }

        private string _recomendation = "";

        public string Recomendation
        {
            get => _recomendation;
            set
            {
                _recomendation = value;
                OnPropertyChanged();
            }
        }
        private DateTime _birthgday;
        public DateTime Birthday
        {
            get => _birthgday;
            set
            {
                _birthgday = value;
                OnPropertyChanged();
            }
        }
        private DateTime _lastVisit;
        public DateTime LastVisit
        {
            get {
                return AppointmentStories.Count > 0 ? AppointmentStories[AppointmentStories.Count-1].date :DateTime.Now; }
            set
            {
                _lastVisit = value;
                OnPropertyChanged();
            }
        }
        private int _lastDoctor = 0;
        public int LastDoctor
        {
            get => _lastDoctor;
            set
            {
                _lastDoctor = value;
                OnPropertyChanged();
            }
        }
        public string AreAdult
        {
            get
            {
                var age = DateTime.Now.Year - Birthday.Year;
                if (Birthday > DateTime.Now.AddYears(-age)) age--;
                return age >= 18 ? "Совершеннолетний" : "Несовершеннолетний";
            }
        }
       public string SinceLastVisit
        {
            get
            {
                var span = DateTime.Now - LastVisit;
                if (AppointmentStories.Count==1)
                    return $"Первый прием";
                return $"{(int)span.TotalDays} дн. назад";
            }
        }

        [JsonIgnore]
        private readonly string _lastDoctorName = "";
        public string LastDoctorName
        {
            get => GetNameById(LastDoctor);
        }
        private string GetNameById(int doctorId)
        {
            try
            {
                string json = File.ReadAllText("D_" + doctorId.ToString().PadLeft(5, '0') + ".json");
                Doctor doctor = JsonSerializer.Deserialize<Doctor>(json);
                return $"{doctor.LastName} {doctor.Name} {doctor.MiddleName}";
            }
            catch
            {
                return "не указан";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}