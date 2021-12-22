namespace MyIngredient
{
    public class MemoryPersistance<TItem>
    {
        public List<TItem> Items { get; set; } = new List<TItem>();

        public void Save(IEnumerable<TItem> items)
        {
            Items.Clear();
            Items.AddRange(items);
        }

        public IEnumerable<TItem> Load()
        {
            return Items; 
        }
    }
}
