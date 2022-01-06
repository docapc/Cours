namespace Ipme.Proxy.Model
{
    public class User
    {
        public string Name { get; set; }
        public int LvlAccess { get; set; }

        public User(string name, int lvl_access)
        {
            Name = name;
            LvlAccess = lvl_access;
        }

        public void UseOrdinateur(IOrdinateur ordinateur)
        {
            ordinateur.DoSomeSensibleStuff();
        }

        public User(User user):this(user.Name, user.LvlAccess)
        {
            //Name = user.Name;
            //LvlAccess = user.LvlAccess;
        }

    }
}