using System;
using System.Text;

namespace BasesCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Les types
            int maChiffre = 0; // déclaration de variable built_in.
            int monChiffre2 = 0; // Ici on à deux type built_in donc deux emplacement mémoire différents.

            string monString = "";    // type primitif -> valeur stocké dans l'espace mémoire
            String monStringRef = ""; // type référence (Tout ce qui n'est pas un primitif : classe perso par exemple)

            bool test = true; // primitif (ou type valeur)
            Boolean test2 = true;// type référence

            Demo demo = new Demo(10);   // Référence vers l'espace mémoire (Demo est une classe perso)
            Demo demo2 = demo;        // Ici on a deux réfrence mais sur le même emplacement mémoire, ce n'est pas une copie

            Demo demo3 = new Demo(11); // = null // par défaut un type référence à la valeur nulle
            bool test3; // un type valeur à une valeur par défaut

            /// Les conditions            
            if(demo == demo2)
            {
                Console.WriteLine("c'est égal"); // les deux références sont égales car pointent sur la même adresse
            }

            if (demo.Equals(demo3)) // il faut bien utiliser le equals et pas l'opérateur ==
            {
                Console.WriteLine("c'est égal"); // les deux références sont égales car pointent sur la même adresse
            }
            else
            {
                Console.WriteLine("c'est différent");
            }
            
            //Console.WriteLine(demo3.ToString());
            int retour = demo.Calcul(1, 2, 5);
            Console.WriteLine(retour);

            /// Les boucles
            // for classique
            for (int i = 0; i < 100; i++) 
            {
                Console.WriteLine(i);
            }

            int[] array = new int[] { 1, 2, 3 }; // tableau de int nommé array. Le [] en paramètre devrait prendre la taille du tableau
            int[] array2 = { 1, 2, 3 }; // déclaration équivalente
            int[,] array3 = { { 1,4 }, { 2,5 }, { 3,6 } }; // la virgule dans [] permet des tableau mutlidimensionnels 
            int[,] array4 = new int[,] { { 1, 4 }, { 2, 5 }, { 3, 6 } }; // syntaxe équivalente
            // le foreach 
            foreach (var vvv in array)  // équivalent a ne boucle for avec indexation de l'array : array[i]         
            {
                Console.WriteLine(vvv);
            }

            // Le while 
            int j = 0;
            while (j <100)
            {
                Console.WriteLine(j);
                j++;
            }

            // String
            string cc = "Coucou";
            string cc2 = "Coucou";

            if (cc == cc2)
            {
                Console.WriteLine("égal");
            }

            string cc3; // initialisé à empty
            string cc4 = string.Empty; // Visual Studio veut une initialisation à un moment donné pour afficher
            Console.WriteLine(cc4);

            // Concatenation de string et formatage
            Console.WriteLine(string.Format("j'affiche {0} , {1}", cc+cc2, cc4, "coucou3"));

            // String interpolation
            Console.WriteLine($"j'affiche {cc+cc2}, coucou3");

            cc2 = cc2 + "test2"; // un string n'est pas mutable, cc2 est donc override ici!

            // Concatenation des string plus efficace
            StringBuilder sb = new StringBuilder(); // nécessite System.Text
            sb.Append(cc);
            sb.Append(cc2);

            Demo2 ma_demo = new Demo2();
            ma_demo.Age = 10; // appel le setter de la propriété Age pour changer l'attribut age

            Demo2 demo4 = new Demo2();
            Console.WriteLine(demo4); // l'affichage dépend de la méthode ToString (sans surchage on affiche namespace+classe)
            Demo demo5 = new Demo(10);
            Console.WriteLine(demo5); // l'affichage dépend de la méthode ToString (sans surchage on affiche namespace+classe)
            demo5.ToString();

            // conversion type valeur (voir demo pour check type valeur par référence)
            string ii= "5";
            int testResult;
            int.TryParse(ii, out testResult);// Essaie de convertir i en int puis passe le résultat via out (par référence)
                                             // à test Result 
            int.Parse(ii); // même chose qu'au dessus mais lève une erreur en cas d'impossibilité

            // sur le out, passage par référence
            var calcul = new Calcul();
            int v1 = 1;
            int v2 = 2;
            int v3;
            int v4 = 5; 
            var resultReturn = calcul.CalculInt(v1, v2, out v3, ref v4);// ref force l'initialisation de la variable
            var resultReturn2 = calcul.CalculInt2(v1, v2, out v3, ref v4);// ref force l'initialisation de la variable
            var v5 = resultReturn2.Item1; // valeur du tuple en sortie
            resultReturn2.Item1 = 5; // valeur du tuple en sortie
            Console.WriteLine($"Result : {v1}");
            Console.WriteLine($"Result : {v3}");

            Console.WriteLine($"Result : {resultReturn}");

            // sur les paramètres par défaut 
            calcul.Calc2(5, c: 8); // ici on skip la définition de b mais on affecte 8 à la valeur c

            // Sur Exercice Ref, Out, valeurs par défaut
            var TT = new ExerciceRefOutParDefaut();
            int a = 3;
            int b = 10;
            string c = "C";

            Console.WriteLine($"Hors classe : c = {c}");
            Console.WriteLine("Premier appel");
            TT.PrintRes(a, ref b, out c);
            Console.WriteLine("Second appel");
            TT.PrintRes(a, ref b, out c, e: 0);

            // Enumération
            //voir ExEnum
            var enum_chat = MonEnum.Chat;

            var chatConst = DemoConst.CHAT;

            calcul.Animal = MonEnum.Cochon; // ici c'est le setter de la propriété qui affecte la valeur
        }
    }
}
