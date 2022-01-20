namespace Model
{
    public class UserQuizz
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PathMiniature { get; set; }
        public bool IsAdmin { get; set; }
        public List<ThemeEx> ThemeEx { get; set; }
        public List<Question> Question { get; set; }
        public List<Reponse> Reponse { get; set; }
        public List<Links> Links { get; set; }
    }
}
