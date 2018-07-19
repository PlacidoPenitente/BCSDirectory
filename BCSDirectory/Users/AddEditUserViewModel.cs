using BCSDirectory.Models;
using BCSDirectory.Workspace;
using System.Collections.ObjectModel;

namespace BCSDirectory.Users
{
    public class AddEditUserViewModel : WorkspacePage
    {
        private readonly WorkspaceViewModel _workspaceViewModel;

        public DelegateCommand SaveCommand { get; set; }

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

        public AddEditUserViewModel(User user, WorkspaceViewModel workspaceViewModel)
        {
            _workspaceViewModel = workspaceViewModel;
            Title = "New User";
            IconName = "Create";

            Items = new ObservableCollection<string>();
            SaveCommand = new DelegateCommand(Save);
        }

        public override void GotoPage()
        {
            _workspaceViewModel.TargetPage = this;
        }

        private void Save()
        {

        }
    }
}
