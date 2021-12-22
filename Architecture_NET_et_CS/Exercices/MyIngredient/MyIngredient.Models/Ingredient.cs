namespace MyIngredient.Models
{
    public class Ingredient
    {
        public string Name { get; set; }

        public override string? ToString()
        {
            return $"mon nom est {Name}";
        }
    }
}
