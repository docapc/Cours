namespace Model
{
    public class Links
    {

        public Guid Id  { get; set; }
        public string Element { get; set; }  
        public virtual Reponse Reponse { get; set; }
        public List<UserQuizz> UserQuizz { get; set; }
        public Links(string element)
        {
            this.Element = element;
        }
    }
}
