using BCSDirectory.Login;
using BCSDirectory.Workspace;

namespace BCSDirectory.MainWindow
{
    public class MainWindowViewModel : BaseInpc
    {
        public WorkspaceViewModel WorkspaceViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }

        #region CurrentPageViewModelProperty

        private Page _currentPageViewModel;

        public Page CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            WorkspaceViewModel = new WorkspaceViewModel();
            LoginViewModel = new LoginViewModel();

            CurrentPageViewModel = WorkspaceViewModel;
        }

    }
}
