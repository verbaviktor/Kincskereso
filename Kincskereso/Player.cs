using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace Kincskereso
{
    internal class Player:INotifyPropertyChanged
    {
        private Point position;

        public Point Position
        {
            get { return position; }
            set { position = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Position")); }
        }
        private int utcount;

        public int Utcount
        {
            get { return utcount; }
            set { utcount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Utcount")); }
        }

        private int asocount;

        public int Asocount
        {
            get { return asocount; }
            set { asocount = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Asocount")); }
        }
        private bool[] _traversed;

        public bool[] traversed
        {
            get { return _traversed; }
            set { _traversed = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("traversed")); }
        }
        private int kincsekcount;

        public int Kincsekcsount
        {
            get { return kincsekcount; }
            set { kincsekcount = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Kincsekcsount")); }
        }


        private int lepescount;

        public int Lepescount
        {
            get { return lepescount; }
            set { lepescount = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Lepescount")); }
        }


        private Resources resources;

        public Resources anyagok
        {
            get { return resources;
            
            }
            set { resources = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("anyagok")); }
        }


        public Player(Point pos)
        {
            traversed = new bool[5];
            anyagok = new Resources();
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
