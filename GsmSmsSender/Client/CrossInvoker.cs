using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Client
{
    internal static class CrossInvoker
    {
        public static object CrossInvoke(this Delegate de, object sender, EventArgs e)
        {
            return de.DynamicInvoke(sender, e);
        }
    }
}
