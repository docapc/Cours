using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Animals
{
    public abstract class Animal : ObservableObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsFeeded { get; set; }
        //protected string _roar;
        public string Roar 
        {
            get { return GetRoar(); }
            
        }
        public abstract string GetRoar();

    }
}
