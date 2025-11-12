using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace _7_TRPO
{
    internal class C : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int P_count
        {
            get => File.ReadAllLines("P_id.txt").Length;
        }

        public int D_count
        {
            get => File.ReadAllLines("id.txt").Length;
        }

        public int All_count
        {
            get => P_count + D_count;
        }

        public void Refresh()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(P_count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(D_count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(All_count)));
        }
    }
}

