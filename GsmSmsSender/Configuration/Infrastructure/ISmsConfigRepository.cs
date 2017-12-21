using GsmSmsSender.Configuration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Configuration.Infrastructure
{
    public interface ISmsConfigRepository<A> 
        where A : ISmsConfiguration
    {
        ISmsConfiguration config { get; set; }
        void Save(A config);
        void Load();
        void LoadForm();
    }
}
