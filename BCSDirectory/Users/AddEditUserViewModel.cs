using BCSDirectory.Model;
using BCSDirectory.Services;
using BCSDirectory.Workspace;
using System.Collections.ObjectModel;
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

        #region ItemsProperty

        private ObservableCollection<string> _items;

        public ObservableCollection<string> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region MonthProperty

        private string _month;

        public string Month
        {
            get => _month;
            set
            {
                _month = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region DayProperty

        private string _day;

        public string Day
        {
            get => _day;
            set
            {
                _day = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region YearProperty

        private string _year;

        public string Year
        {
            get => _year;
            set
            {
                _year = value;
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
            Items = new ObservableCollection<string>();
            SaveCommand = new DelegateCommand(Save);
        }

        public override void GotoPage()
        {
            _workspaceViewModel.TargetPage = this;
        }

        private void Save()
        {
            Task.Run(() =>
            {
                UserRepository repo = new UserRepository();
                repo.ApiAdd(User.User);
            });
        }
    }
}
