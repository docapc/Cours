namespace MyIngredient.Models
{
    public class IngredientManager
    {
        private IReader Reader { get; }

        private IWriter Writer { get; }

        private IList<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

        public IngredientManager(IReader reader, IWriter writer)
        {
            Reader = reader;
            Reader.Writer = writer;
            Writer = writer;
        }

        public void Create()
        {
            try
            {
                Ingredients.Add(Reader.ReadIngredient());
            }
            catch (Exception ex)
            {
                Writer.Display($"Attention un prolbème est survenue : {ex.Message}"); 
            }
        }

        public void Read()
        {

        }

        public void Update()
        {

        }

        public void Delete()
        {

        }

        public void ReadAll()
        {
            try
            {
                foreach(var ingredient in Ingredients)
                {
                    Writer.DisplayIngredient(ingredient);
                }
            }
            catch (Exception ex)
            {
                Writer.Display($"Attention un prolbème est survenue : {ex.Message}");
            }
        }
    }
}
