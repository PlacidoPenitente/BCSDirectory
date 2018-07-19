using BCSDirectory.Model;
using BCSDirectory.Models;
using BCSDirectory.Users;
using System.Collections.Generic;

namespace BCSDirectory.Workspace
{
    public class WorkspaceViewModel : Page
    {
        #region PagesProperty

        private List<WorkspacePage> _pages;

        public List<WorkspacePage> Pages
        {
            get => _pages;
            set
            {
                _pages = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region TargetPageProperty

        private WorkspacePage _targetPage;

        public WorkspacePage TargetPage
        {
            get => _targetPage;
            set
            {
                if (_targetPage != value)
                {
                    _targetPage = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion

        public User User { get; set; }
        public UserFacade UserFacade { get; set; }

        public WorkspaceViewModel()
        {
            User = new User();
            UserFacade = new UserFacade(User);

            Pages = new List<WorkspacePage>()
            {
                new AddEditUserViewModel(UserFacade, this),
                new UsersViewModel(this)
            };
        }
    }
}
