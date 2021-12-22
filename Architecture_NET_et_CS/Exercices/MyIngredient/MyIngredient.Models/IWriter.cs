namespace MyIngredient.Models
{
    public interface IWriter
    {
        public void Display(string s);

        public void DisplayIngredient(Ingredient ingredient);
    }
}