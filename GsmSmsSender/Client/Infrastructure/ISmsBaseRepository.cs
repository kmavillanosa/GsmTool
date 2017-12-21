using GsmSmsSender.Configuration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Client.Infrastructure
{
    public interface ISmsBaseRepository<A> 
        where A: ISmsConfiguration
    {
        bool Islive { get; set; }
        void RegisterConfiguration(A Config);
    }
}
