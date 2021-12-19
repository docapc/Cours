using System;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sur les excpetions
            try
            {
                int.Parse("toto");
                int.Parse(null);
            } // catch ou finally attendu
            catch (ArgumentNullException ane)
            {
                Console.WriteLine($"Il y a un problème de type argument null exception {ane.Message}");
            }
            catch (FormatException fe)
            {
                Console.WriteLine($"Il y a un problème de type format exception {fe.Message}");
            }
            catch (Exception e) // on récupère l'excéption aliasé e
            {
                Console.WriteLine($"Il y a un problème {e.Message}");
            }

            // Utilisation de l'exception custom 
            try
            {
                var cal = new Calcul();
                cal.Calc(-1, 2);
            }
            catch(ArgumentException me)
            {

            }
            catch(MyException me)
            {
                Console.WriteLine($"{me.Message}");
            }
            finally // finally permet d'éxécuter du code quoi qu'il arrive
            {
                Console.WriteLine("Ce message apparait quoi qu'il arrive");
            }
            //throw new Exception("coucou"); // fait planter le programme : la suite ne s'éxécute pas si cette ligne est la

            BadClass bidon = new BadClass();
            try
            {
                bidon.DivPar0(0);
            }
            catch (MyException2 me2)
            {
                Console.WriteLine($"exception Custom : {me2.Message}");
            }
            catch (DivideByZeroException dbz)
            {
                Console.WriteLine($"DBZ : {dbz.Message}");
            }
            finally
            {
                try
                {
//                    bidon.BadReturn(new MyException2("............................"));
                    bidon.BadReturn(new DivideByZeroException("DBZ injecté"));
                }
                catch (MyException2 me2)
                {
                    Console.WriteLine($"exception Custom : {me2.Message}");
                }
                catch (DivideByZeroException dbz)
                {
                    Console.WriteLine($"exception Custom : rethrow depuis bidon -> {dbz.Message}");
                }
                finally
                {
                    Console.WriteLine("Tt est géré...");
                }
            }

            // Méthode d'extention -> permet d'étendre une classe, ou une interface
            var calc2 = new Calcul();
            CalculationExtention.NouvelleMethodeDeCalcul(calc2, 1, 2);
            CalculationExtention.NouvelleMethodeDeCalcul(new Calcul(), 1, 2); // fonctionne également, il n'y a en fait aps besoin d'instance car
                                                                              // Calculation extension est statique
                                                                              // On a en fait déporter le code de calcul dans CalculationExtention
            Console.WriteLine( calc2.NouvelleMethodeDeCalcul(1, 2));

            ///???
            //List < ITest3 > = new List<ITEst3>();

            // si on a une méthode d'extention avec une signature donné on peut l'appeler sur n'importe quelle objet avec cette signature
            int test5 = 5;
            test5.MonJolieInt(); 
        }
    }
}
