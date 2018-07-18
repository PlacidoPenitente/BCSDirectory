using System.Collections.ObjectModel;

namespace BCSDirectory.Model
{
    public class Hobby
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ObservableCollection<User> Users { get; set; }
    }
}
