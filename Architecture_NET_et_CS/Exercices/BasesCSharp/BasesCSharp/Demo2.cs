using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasesCSharp
{
    class Demo2 //: IEquatable<T>//
    {
        private int _a;
        private int _b;
        private int _c;

        // Les propriétés : propre à c# (une propriété n'est pas tt à fait un attribut)
        public int MaProp { get; private set; } // demande une construction automatique des Getter et Setter pour MaProp
                                                // les get et set sont public par défaut mais on peut leur donner une visibilité
                                                // Ces propriété servent pour l'encapsulation

        public int MaProp11 { get; private set; } = 0; //fonctionne également (initialisation)
        public int MaProp21 { get; } = 0; // sans setter on peut faire une propriété readonly
        // On peut faire des propriété qui se base sur un attribut -> à regarder à la maison 
        //Propriété à partir d'attributs
        public int MaProp2
        {
            get => _a;
            set => _a = value; // value est un mot clef
            // équivalent à 
            //get
            //{
            //    return a;
            //}
            //set
            //{
            //    _a = value;
            //}
        }

        // Propriété calculé : la propriété inclus un calcul : ne possède pas de setter
        public int CalcProp { get => MaProp2 / 2; }

        private int age;
        public int Age // on peut (mais pas conseillé ) faire des logiques de validation via ce systeme
        {
            get { return age; }
            set
            {
                if (age > 0)
                    age = value;
            }
        }

        public Demo2()
        {
            MaProp = 1; // appel le getter automatique
            var test = MaProp; // appel le setter automatique
        }
        // Surcharge du constructeur : condition signature différente
        public Demo2(int a, int b)
        {
            _a = a;
            _b = b;
        }

        // sur le static
        public static int MyProperty { get; set; } = 50; // partagé entre tt les instance de classes 
                                                         // fonctionne aussi avec les méthodes (voir Singleton)



        // Chainage de constructeur
        public Demo2(int a, int b, int c) : this(a,b) // on ne peut qu'appeler un constructeur dans un autre mais on peut chainer ces appels 
                                                      // une chaine d'appel de constructeur
        {
            _c = c;
        }

        // Getter
        public int getA()
        {
            return _a;
        }

        //Setter 
        public void SetA(int a)
        {
            _a = a;
        }

 

    }
}
