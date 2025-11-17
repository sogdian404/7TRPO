using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _7_TRPO
{
    public class Doctor
    {

        private int _id = 0;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
            }
        }
        private string _name = "";
        public string Name
        {
            get => _name;
            set
            {
                    _name = value;
            }
        }
        private string _lastName  = "";
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
            }
        }
        private string _middleName = "";
        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;
            }
        }
        private string _specialisation = "";
        public string Specialisation
        {
            get => _specialisation;
            set
            {
                _specialisation = value;
            }
        }
        private string _password = "";
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
            }
        }
        [JsonIgnore]
        private string _repeatPassword = "";
        public string RepeatPassword
        {
            get => _repeatPassword;
            set
            {
                _repeatPassword = value;
            }
        }


    }
}