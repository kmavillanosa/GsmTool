using GsmSmsSender.Configuration.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Configuration.Infrastructure
{
    public interface ISmsConfigRepository<T> 
        where T : ISmsConfiguration
    {
        ISmsConfiguration config { get; set; }
        void Save(T config);
        void Load();
        void LoadForm();
    }
}
