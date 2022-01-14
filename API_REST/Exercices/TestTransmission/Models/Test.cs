namespace Models
{
    public class Test
    {
        public short UserId { get; set; }

        public string? UserName { get; set; }

        public string? Login { get; set; }

        public DateTime? Birthday { get; set; }

        public Test(short userId, string? userName, string? login, DateTime? birthday)
        {
            UserId = userId;
            UserName = userName;
            Login = login;
            Birthday = birthday;
        }

        public override string ToString()
        {
            return $"Id : {UserId}, Name : {UserName}, Login : {Login}, Birthday : {Birthday}";
        }
    }
}