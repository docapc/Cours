using System.Collections.ObjectModel;
namespace DemonBinding.Models
{
    public class UsersList : ObservableObject
    {
        private ObservableCollection<UserModel> users;

        private UserModel currentUser;

        public UserModel CurrentUser
        {
            get { return currentUser; }
            set
            {
                if (currentUser != value)
                {
                    currentUser = value;
                    OnNotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Cette partie est nécessaire pour notifier que la référence de l'objet observable connection à changé.
        /// </summary>
        public ObservableCollection<UserModel> Users // L'observable collection notifie seulement lors d'un changement 
                                                     // dans la liste (create, update, delete)
        {
            get { return users; }
            set
            {
                if (users != value)
                {
                    users = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
