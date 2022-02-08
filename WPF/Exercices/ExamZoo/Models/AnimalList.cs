using Models.Animals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class AnimalList : ObservableObject
    {
        private ObservableCollection<Animal> animals;

        private Animal currentAnimal;       

        public Animal CurrentAnimal
        {
            get { return currentAnimal; }
            set
            {
                if (currentAnimal != value)
                {
                    currentAnimal = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public ObservableCollection<Animal> Animals
        {
            get { return animals; }
            set
            {
                if (animals != value)
                {
                    animals = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
