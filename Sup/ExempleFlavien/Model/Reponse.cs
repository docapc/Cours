
namespace Model
{
    public class Reponse
    {
        public Guid Id { get; set; }
        public string ReponseText { get; set;}
        public string ReponseExplication { get; set;}
        public List<Links> Links { get; set; }
        public virtual Question Question { get; set; }
        public bool isTrool { get; set; }

        public List<UserQuizz> UserQuizz { get; set; }

        public Reponse( string ReponseText, string ReponseExplication)
        {
            this.ReponseText = ReponseText;
            this.ReponseExplication = ReponseExplication;
            Links = new List<Links>();
        }

     }
}