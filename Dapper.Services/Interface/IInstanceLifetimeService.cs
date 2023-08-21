using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper.Services.Interface
{
    public interface IInstanceLifetimeService
    {
        string getTransient();

        string getScoped();

        string getSingleton();
    }
}
