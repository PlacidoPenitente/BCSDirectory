using BCSDirectory.Model;
using BCSDirectory.Workspace;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;

namespace BCSDirectory.Users
{
    public class AddEditUserViewModel : WorkspacePage
    {
        private readonly WorkspaceViewModel _workspaceViewModel;

        public UserFacade User { get; set; }

        public DelegateCommand SaveCommand { get; set; }

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

        public AddEditUserViewModel(User user, WorkspaceViewModel workspaceViewModel)
        {
            Items = new ObservableCollection<string> { "Biking" };
            _workspaceViewModel = workspaceViewModel;
            Title = "New User";
            IconName = "Create";

            User = new UserFacade(new User());
            SaveCommand = new DelegateCommand(Save);
        }

        public override void GotoPage()
        {
            _workspaceViewModel.TargetPage = this;
        }

        private void Save()
        {
            Console.WriteLine(JsonConvert.SerializeObject(User));

        }
    }
}
