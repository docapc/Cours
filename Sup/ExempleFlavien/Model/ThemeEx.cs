

namespace Model
{
    public class ThemeEx
    {
        public Guid Id { get; set; }
        public string ThemeName { get; set; }
        public List<Question> Questions { get; set; }

        public ThemeEx (Guid Id, string ThemeName) 
        { 
            Id = Id; 
            ThemeName = ThemeName;
        }
        public List<UserQuizz> UserQuizz { get; set; }
        public ThemeEx(string ThemeName)
        {
            this.ThemeName = ThemeName;
            Questions = new List<Question>();
        }
    }
}