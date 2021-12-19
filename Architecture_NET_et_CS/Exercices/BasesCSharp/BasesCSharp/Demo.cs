using System;

namespace BasesCSharp
{
    internal class Demo : IEquatable<Demo>
    {
        private int _val;

        public Demo(int valeur) 
        {
            _val = valeur;
        }

        // méthode -> visibilité type de retour nom(paramètres)
        public int Calcul(int a,int b,int c) // attention ce n'est pas une surcharge
        {
            return a + b * c;
        }

        public bool Equals(Demo other) // attention ce n'est pas une surcharge (cette méthode est nécessaire pour satisfaire le contrat IEquatable)
        {
            //return this._val == other._val; // équivalent à la ligne du dessous
            return _val.Equals(other._val);
        }

        // sur le cast (Convertion de type référence -> pas tt à fait) -> plus boxing et unboxing
        //public override bool Equals(object? obj)
        //{
        //    Demo demo2 = (Demo)obj; // vérifie si obj est bien un type Demo, sinon lève une erreur 

        //    if (demo2 is Demo test) // check si obj est de type Demo puis fait l'affectation en tant que Demo si le test est passé
        //    {// le if au dessus est juste pour l'exemple car non nécessaire
        //        Demo demo = obj as Demo; // convertion si possible sinon demo est passé à nulle
        //    }
        //}
//        public string ToString() // si pas de override, la compilation fonctionne mais le comportement de console write n'est pas changé
        public override string ToString() // override est nécessaire pour remplacer la méthode parent
        { 
            return _val.ToString();
        }

    }
}