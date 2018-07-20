using BCSDirectory.Models;
using BCSDirectory.Services;
using BCSDirectory.Workspace;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BCSDirectory.Users
{
    public class UsersViewModel : WorkspacePage
    {
        private readonly WorkspaceViewModel _workspaceViewModel;

        #region UsersProperty

        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public UsersViewModel(WorkspaceViewModel workspaceViewModel)
        {
            _workspaceViewModel = workspaceViewModel;
            Title = "View Users";
            IconName = "View";
            UserRepository repo = new UserRepository();
            Task.Run(() => Users = new ObservableCollection<User>(repo.ApiGetAll()));
        }

        public override void GotoPage()
        {
            Task.Run(() => _workspaceViewModel.TargetPage = this);
        }
    }
}
