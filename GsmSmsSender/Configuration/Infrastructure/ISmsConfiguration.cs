using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Configuration.Infrastructure
{
    public interface ISmsConfiguration
    {
        string Port { get; set; }
        int BaudRate { get; set; }
    }
}
