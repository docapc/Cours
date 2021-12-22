using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIngredient.Models
{
    internal class ConsoleReader : IReader
    {
        public IWriter Writer { get; set; }


        public Ingredient ReadIngredient()
        {
            Writer.Display("Donne moi le nom d'un ingredient"); 
            var ingredientName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ingredientName))
            {
                Writer.Display("Ce nom n'est pas bon !");
                return ReadIngredient();
            }

            return new Ingredient { Name = ingredientName };
        }



    }
}
