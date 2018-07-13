using BCSDirectory.Workspace;

namespace BCSDirectory.Users
{
    public class UsersViewModel : WorkspacePage
    {
        private readonly WorkspaceViewModel _workspaceViewModel;

        public UsersViewModel(WorkspaceViewModel workspaceViewModel)
        {
            _workspaceViewModel = workspaceViewModel;
            Title = "View Users";
            IconName = "View";
        }

        public override void GotoPage()
        {
            _workspaceViewModel.TargetPage = this;
        }
    }
}
