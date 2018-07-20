using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSDirectory.Services.Interfaces
{
    public interface IReadOnlyApiRepository<out T>
    {
        T ApiFind(int id);
        IEnumerable<T> ApiGetAll();
    }
}
