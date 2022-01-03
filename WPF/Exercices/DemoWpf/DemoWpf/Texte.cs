namespace DemoWpf
{
    public class Texte
    {
        private static int _sid = 0;
        public int Id { get; set; }

        public string Name { get; set; }

        public Texte(string texte)
        {
            Id = ++_sid;
            Name = texte;
        }
    }
}