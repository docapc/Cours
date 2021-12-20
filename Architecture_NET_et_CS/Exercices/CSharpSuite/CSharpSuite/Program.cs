using System;

namespace CSharpSuite
{
    internal class Classromm
    {
        public User Prof { get; set; }
    }

    internal class User
    {
        private string _name; // bonne convention
     // private int id; // mauvaise convention
        private readonly Guid _id; // readonly pour garantir la non modification après construction

        //public User(string name)
        //{
        //    _name = "Test"; // bonne chose
        //    //this.id = 2; // mauvaise chose
        //    //id = 2; // à vérifier si cela fonctionne
        //    _id = Guid.NewGuid(); // génère un nouvelle id unique
        //}

        // Mieux de le faire avec du chainage
        public User(string name): this(Guid.NewGuid(), name)
        {
        }
        public User(Guid id, string name)
        {
            _name = name;
            _id = id;
        }

        public int Age { get; set; }// à éviter du coup?

        // Définition d'un getter (méthode particulière sans () avec get -> c'est une property basé sur un attribut)
        public Guid Id
        {
            get { return _id; }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var classroom = new Classromm();
            Console.WriteLine(classroom.Prof.Age); // null erreur

            var user = new User("Thomas");
            Console.WriteLine(user.Id);

            var user2 = new User(string.Empty); // ne lèvera pas d'erreur mais n'est pas validé par le constrcuteur ce
                                                // qui entrainera d'autre souci plus tard... Le constructeur doit valider ou 
                                                // non ce genre de comportement

        }
    }
}
