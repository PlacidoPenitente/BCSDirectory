using BCSDirectory.Model;
using BCSDirectory.Workspace;
using System.Collections.ObjectModel;

namespace BCSDirectory.Users
{
    public class AddEditUserViewModel : WorkspacePage
    {
        private readonly WorkspaceViewModel _workspaceViewModel;

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
            Items = new ObservableCollection<string> {"Biking"};
            _workspaceViewModel = workspaceViewModel;
            Title = "New User";
            IconName = "Create";
        }

        public override void GotoPage()
        {
            _workspaceViewModel.TargetPage = this;
        }
    }
}
