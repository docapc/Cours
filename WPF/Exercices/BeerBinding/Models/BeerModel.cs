namespace Models
{
    public class BeerModel : ObservableObject
    {
        public Guid BeerId { get; set; }
        
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnNotifyPropertyChanged();
                }
            }
        }


        public float Ibu { get; set; }

        public float Degree { get; set; }

        public BeerModel()
        {
            BeerId = Guid.NewGuid();
        }
    }
}