using System;
using BCSDirectory.Model;
using BCSDirectory.Workspace;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;

namespace BCSDirectory.Users
{
    public class AddEditUserViewModel : WorkspacePage
    {
        private readonly WorkspaceViewModel _workspaceViewModel;

        public UserFacade User { get; set; }

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

            User = new UserFacade(new User());
            Items = new ObservableCollection<string>();
            SaveCommand = new DelegateCommand(Save);
        }

        public override void GotoPage()
        {
            _workspaceViewModel.TargetPage = this;
        }

        private void Save()
        {
            foreach (var hobbyName in Items)
            {
                User.HobbiesAndInterests.Add(new Hobby() { Name = hobbyName });
            }

            var jsonString = JsonConvert.SerializeObject(User.User);
            var request = (HttpWebRequest)WebRequest.Create("https://dotjayapi.conveyor.cloud/api/user");
            request.Method = "Post";
            request.ContentType = "Application/Json";
            request.ContentLength = jsonString.Length;
            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(jsonString);
            }

            var response = (HttpWebResponse)request.GetResponse();
            Console.WriteLine(response.StatusDescription);
        }
    }
}
