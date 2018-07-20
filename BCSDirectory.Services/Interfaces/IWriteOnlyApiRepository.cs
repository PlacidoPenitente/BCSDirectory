using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCSDirectory.Services.Interfaces
{
    public interface IWriteOnlyApiRepository<in T>
    {
        void ApiAdd(T value);
        void ApiUpdate(int? id, T value);
        void ApiDelete(int? id);
    }
}
