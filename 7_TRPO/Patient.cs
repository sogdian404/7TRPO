using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _7_TRPO
{
    internal class Patient
    {
        private int _id = 0;

        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _name = "";

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();

            }
        }

        private string _lastName = "";

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();

            }
        }

        private string _middleName = "";

        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
                OnPropertyChanged();

            }
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
        private DateTime _birthgday ;
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
            get =>_lastVisit;
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