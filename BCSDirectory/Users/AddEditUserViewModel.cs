using BCSDirectory.Model;
using BCSDirectory.Workspace;

namespace BCSDirectory.Users
{
    public class AddEditUserViewModel : WorkspacePage
    {
        private readonly WorkspaceViewModel _workspaceViewModel;

        public AddEditUserViewModel(User user, WorkspaceViewModel workspaceViewModel)
        {
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
