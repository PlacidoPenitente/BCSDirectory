using BCSDirectory.Model;
using BCSDirectory.Models;
using BCSDirectory.Services;
using BCSDirectory.Workspace;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace BCSDirectory.Users
{
    public class AddEditUserViewModel : WorkspacePage
    {
        private readonly WorkspaceViewModel _workspaceViewModel;

        public DelegateCommand SaveCommand { get; set; }

        #region UserProperty

        private UserFacade _user;

        public UserFacade User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region HobbiesProperty

        private ObservableCollection<string> _hobbies;

        public ObservableCollection<string> Hobbies
        {
            get => _hobbies;
            set
            {
                _hobbies = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public AddEditUserViewModel(UserFacade userFacade, WorkspaceViewModel workspaceViewModel)
        {
            _workspaceViewModel = workspaceViewModel;
            Title = "New User";
            IconName = "Create";

            User = userFacade;
            Hobbies = new ObservableCollection<string>(User.Hobbies.Select(x => x.Name));
            SaveCommand = new DelegateCommand(Save);
        }

        public override void GotoPage()
        {
            _workspaceViewModel.TargetPage = this;
        }

        private void Save()
        {
            User.Hobbies = new List<Hobby>(Hobbies.Select(x => new Hobby() { Name = x }));
            Task.Run(() =>
            {
                UserRepository repo = new UserRepository();
                repo.ApiAdd(User.User);
            });
        }
    }
}
