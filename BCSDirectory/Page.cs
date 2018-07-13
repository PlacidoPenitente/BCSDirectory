namespace BCSDirectory
{
    public abstract class Page : BaseInpc
    {
        #region TitleProperty

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        #endregion
    }
}
