using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

namespace Heritage
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemple simple de partage 
            //var animal = new Animales() { Nom = "MonAnimal" }; // pas possible pour une classe abstraite
            var chat = new Chat() { Nom = "MonChat" }; // On pourrait utiliser Animales au lieux de var
            var chien = new Chien() { Nom = "MonChien" }; // 

            //animal.Dormir(); // classe abstraite
            chien.Dormir();
            chat.Dormir();

            // override de méthodes abstraite
            chat.Manger();
            chien.Manger();

            chat.Jouer();// On pourrait utiliser Animales au niveau de la déclaration au lieux de var mais on ne pourrait plus utiliser 
                         // la méthode Jouer() du chat.

            Animales chat2 = new Chat();
            //chat2.Jouer(); // ce n'est pas possible car chat2 est un animale
            Chat monChat2 = (Chat)chat2; // marche
            monChat2.Jouer();
            ((Chat)chat2).Jouer(); // fonctionne également

            // les list permettent de regrouper les objet de même type parent (c'est du poly morphiseme)
            List<Animales> listAnimaux = new List<Animales>(); // List est dans Systel.Collection.Generic
            listAnimaux.Add(chat);
            listAnimaux.Add(chien);

            foreach (Animales animal in listAnimaux)
            {
                animal.Manger();
                if (animal is Chat monChat) // monChat est alors du type Chat (en plus d'etre du type Animales)
                                            // monChat est une nouvelle variable de référence vers animal
                {
                    monChat.Jouer();
                }
            }

            ExDeveloppeur stag1 = new ExStagiaire() { Name = "Kevin"};
            stag1.Coder();
            // Il faut jour avec ces lignes pour comprendre un peu mieux
            Chien chien2 = new Chien("monChien", 10);
            Chien chien3 = new Beagle("monChien", 10);
            chien2.Courrir();
            chien3.Courrir();
            Beagle chien4 = new Beagle("monChien", 10);
            chien4.Courrir();
        }
    }
}
