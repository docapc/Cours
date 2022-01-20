namespace Model
{
    public class Question
    {
        public Guid Id { get; set; }
        public string QuestionText{ get; set; }

        public List<Reponse> Reponses { get; set; }
        public virtual ThemeEx ThemeEx { get; set; }

        public List<UserQuizz> UserQuizz { get; set; }
        public Question( string QuestionText)
        {
            this.QuestionText = QuestionText;
            Reponses=new List<Reponse>();
        }

    }
}