namespace MyIngredient.Models
{
    internal class ConsoleWriter : IWriter
    {
        public void Display(string s)
        {
            Console.WriteLine(s);
        }

        public void DisplayIngredient(Ingredient ingredient)
        {
            Console.WriteLine(ingredient);
        }
    }
}
