using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

/// <summary>
/// Type principale Contenue dans le Garage
/// Important : le nombre de roues n'est absoluement pas nécessaire et est juste la pour affichage
/// </summary>
namespace ExoGarage
{
    internal abstract class Vehicle 
    {       
        private static int _sid = 0;
        
        private readonly int _id;
        private readonly string _brand;
        private readonly string _model;
        private readonly float _mileage; 

        protected int WheelsNumber { get; init; } 

        internal VehicleState State { get; set; }   

        /// <summary>
        /// Constructeur Mère abstract
        /// </summary>
        /// <param name="brand"></param>
        /// <param name="model"></param>
        /// <param name="state"></param>
        /// <param name="mileage"></param>
        /// <exception cref="MyBadStringException"></exception>
        /// <exception cref="MyNegativeParamException"></exception>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public Vehicle(string brand, string model, VehicleState state, float mileage)
        {
            // Aucun types nullable la dedans
            _id = ++_sid; // le id sert au stats du garage, pas à l'indexation dans la list
            if (string.IsNullOrWhiteSpace(brand))
                {
                throw new MyBadStringException($"Du Constructeur de véhicule : la Marque donnée est null ou vide : on attend au moins un charactère");
                }
            _brand = brand;
            if (string.IsNullOrWhiteSpace(model))
            {
                throw new MyBadStringException($"Du Constructeur de véhicule : le Modèle donné est null ou vide : on attend au moins un charactère");
//                throw new ArgumentNullException($"le Modèle donné est null ou vide : on attend au moins un charactère");
            }
            _model = model;
            if (mileage < 0)
            {
                throw new MyNegativeParamException($"Du Constructeur de véhicule : kilométrage négatif passé : on attend une valeur positive");
            }
            _mileage = mileage;
            if (Enum.IsDefined(typeof(VehicleState), state))
            {
                State = state;
            }
            else
            {
                throw new InvalidEnumArgumentException("Du constructeur de véhicule : l'état passé n'est pas dans liste autorisée" +
                    " voir VehicleSate pour les types authorisés.");
            }
        }

        /// <summary>
        /// Permet d'afficher un véhicule via Console.Write()
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() 
        {
            return $"({WheelsNumber} roues), Marque : {_brand}, Modèle : {_model}, Etat : {State.GetString()}, ({_mileage} {Rules.MILEAGE_UNIT}), Id du véhicule = {_id}";
        }
    }
}
