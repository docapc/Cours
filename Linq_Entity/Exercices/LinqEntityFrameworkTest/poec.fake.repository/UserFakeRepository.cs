using poec.sql.dtos;

namespace poec.fake.repository
{
    public class UserFakeRepository
    {
        private IList<UserSqlDto> Users { get; } = new List<UserSqlDto>();
        private IDictionary<string, UserSqlDto> KeyUsers { get; }

        public UserFakeRepository()
        {
            Users.Add(new UserSqlDto(1, "Alex", "Lelexxx", new DateTime(1990, 10, 30, 2, 55, 0)));
            Users.Add(new UserSqlDto(2, "Toto", null, new DateTime(2000, 9, 4, 5, 0, 0)));
            Users.Add(new UserSqlDto(3, "Titi", "Tit", new DateTime(2000, 11, 1, 18, 32, 20)));
            Users.Add(new UserSqlDto(4, "Tutu", null, new DateTime(2000, 9, 4, 5, 1, 0)));

            KeyUsers = Users.ToDictionary(userSqlDto => userSqlDto.UserName + userSqlDto.UserId, userSqlDto => userSqlDto);
            //KeyUsers = Users.ToDictionary(userSqlDto => userSqlDto.UserName + userSqlDto.UserId, GetUserSqlDto); // version Linq
            //équivalent à KeyUsers = Users.ToDictionary(userSqlDto => userSqlDto.UserName + userSqlDto.UserId, GetUserSqlDto);
            //foreach (UserSqlDto userSqlDto in Users)
            //{
            //    IdUsers.Add(userSqlDto.UserId, userSqlDto);
            //}

            Users = KeyUsers.Values.ToList();
        }

        //équivalent à userSqlDto => userSqlDto.UserName + userSqlDto.UserId
        //private static string GetKeyUserSqlDto(UserSqlDto userSqlDto)
        //{
        //    return userSqlDto.UserName + userSqlDto.UserId;
        //}

        private static UserSqlDto GetUserSqlDto(UserSqlDto userSqlDto)
        {
            return userSqlDto;
        }

        // Create Read Update Delete
        #region CRUD 

        public UserSqlDto? Add(UserSqlDto userSqlDto) // on peut renvoyer la valeur nulle
        {
            throw new NotImplementedException();
        }

        //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/concepts/linq/
        public UserSqlDto? GetFirst(short id)
        {
            // A partir du dictionnaire
            //return KeyUsers.FirstOrDefault(ku => ku.Value.UserId == id).Value; // ku pour key-user (clef-valeur). .Value() car Dico.FirstOrDefault retourne KeyValuePair [une entrée d'un dico]

            // First renvoie l'élément et une erreur si il ne le trouve pas
            // FirstOrDefault renvoie l'élement ou null si il ne trouve pas
            return Users.FirstOrDefault(user => user.UserId == id); // prend un prédicat comme argument
        
            // Equivalent sans Linq
            //foreach (UserSqlDto userSqlDto in Users)
            //{
            //    if(userSqlDto.UserId == id)
            //        return userSqlDto
            //}
            //return null;
        }
        /// <summary>
        /// Renvoie un élément que si un seul et unique élément rempli la condition
        /// On utilise cette version si l'on sait qu'il y a un seul et unique élément qui va correspondre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserSqlDto? GetSingle(short id)
        {
            // Single renvoie l'élément et une erreur si il ne le trouve pas ou si il y en a plusieur
            // SingleOrDefault renvoie l'élement ou null si il ne trouve pas ou bien une exception si il en trouve plusieur
            return Users.SingleOrDefault(user => user.UserId == id);

            // Equivalent sans Linq
            //UserSqlDto? user = null;
            //foreach (UserSqlDto userSqlDto in Users)
            //{
            //    if (userSqlDto.UserId == id)
            //    {   
            //        if (user == null)
            //        {
            //            user = userSqlDto;
            //        }
            //        else
            //        {
            //            user = null;
            //            break;
            //        }
            //    }
            //}
            //return user;
            
        }
        public List<UserSqlDto> GetAll()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Fonction qui vérifie le predicate pour retourner une liste obéissant au predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IList<UserSqlDto> GetPredicate(Func<UserSqlDto, bool> predicate)
        {// Func<sortie, entrée>
            return Users.Where(predicate).ToList(); // ToList() car Where() retourne un IEnumerable
        }

        public UserSqlDto? Update(UserSqlDto userSqlDto)
        {
            throw new NotImplementedException();
        }

        public bool Delete(short id)
        {
            throw new NotImplementedException();
        }

        #endregion

        public IList<UserSqlDto> GetBestUser()
        {
            return GetPredicate(user => user.Birthday.Year == 1990);

            // équivalent à return Users.Where(user => user.Birthday.Year == 1990).ToList()
        }

        public TimeSpan GetOldUserAge()
        {
            return Users.Max(user => DateTime.Now - user.Birthday);
        }

    }
}