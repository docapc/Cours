using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Animals
{
    public abstract class Animal : ObservableObject
    {
        private int _id;
        public int Id 
        {
            get
            {
                return _id;
            }
            set
            {
                if (_id!=value)
                {
                    _id = value;
                    // A ne pas oublier!
                    OnNotifyPropertyChanged();
                }
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { if (_name != value) { _name = value; OnNotifyPropertyChanged(); } }
        }

        public bool IsFeeded { get; set; }
        //protected string _roar;
        public string Roar 
        {
            get { return GetRoar(); }
            
        }
        public abstract string GetRoar();

    }
}
