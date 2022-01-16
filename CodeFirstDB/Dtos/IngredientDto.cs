namespace Dtos
{
    public abstract class IngredientDto
    {
        public Guid IngredientId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}