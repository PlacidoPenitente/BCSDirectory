namespace BCSDirectory
{
    public abstract class WorkspacePage : Page
    {
        public DelegateCommand GotoPageCommand { get; set; }

        #region IconNameProperty

        private string _iconName;

        public string IconName
        {
            get => _iconName;
            set
            {
                _iconName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public WorkspacePage()
        {
            GotoPageCommand = new DelegateCommand(GotoPage);
        }

        public abstract void GotoPage();
    }
}
