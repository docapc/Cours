namespace Models
{
    public class BeerModel : ObservableObject
    {
        public Guid BeerId { get; set; }

        public string Name { get; set; }

        public float Ibu { get; set; }

        public float Degree { get; set; }
    }
}