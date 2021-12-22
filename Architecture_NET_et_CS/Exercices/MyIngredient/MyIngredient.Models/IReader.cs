namespace MyIngredient.Models
{
    public interface IReader
    {
        public IWriter Writer { get; set; }


        public Ingredient ReadIngredient();
    }
}