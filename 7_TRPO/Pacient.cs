using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_TRPO
{
    internal class Pacient
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

        private string _lastName = "";

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

        private string _diagnosis = "";

        public string Diagnosis
        {
            get => _diagnosis;
            set
            {
                _diagnosis = value;
            }
        }

        private string _recomendation = "";

        public string Recomendation
        {
            get => _recomendation;
            set
            {
                _recomendation = value;
            }
        }
        private string _birthgday = "";
        public string Birthday
        {
            get => _birthgday;
            set
            {
                _birthgday = value;
            }
        }
        private string _lastVisit = "";
        public string LastVisit
        {
            get => _lastVisit;
            set
            {
                _lastVisit = value;
            }
        }
    }
}