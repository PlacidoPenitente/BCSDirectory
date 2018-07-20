using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSDirectory.Services.Interfaces
{
    public interface IApiRepository<T> : IWriteOnlyApiRepository<T>, IReadOnlyApiRepository<T>
    {
    }
}
