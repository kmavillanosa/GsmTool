using GsmSmsSender.Configuration.Infrastructure;
using GsmSmsSender.Configuration.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GsmSmsSender.Configuration.Repository
{
    [Serializable()]
    public class GsmConfiguration : ISmsConfigRepository<ISmsConfiguration>
    {
        private GsmConfiguration _self;
        
        public ISmsConfiguration config
        {
            get;
            set;
        }


        public GsmConfiguration()
        {
            Load();
        }

        public void Save(ISmsConfiguration config)
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream st = new FileStream("config", FileMode.OpenOrCreate, FileAccess.Write);
                this.config = config;
                formatter.Serialize(st, this);
                st.Close();
            }
            catch
            {

            }
        }
        public void Load()
        {
            try
            {
                IFormatter formatter = new BinaryFormatter();
                Stream st = new FileStream("config", FileMode.Open, FileAccess.Read);
                _self = (GsmConfiguration)formatter.Deserialize(st);
                this.config = _self.config;
                st.Close();

            }
            catch
            {

            }
        }
        public void LoadForm()
        {
            ConfigForm cf = new ConfigForm();
            cf.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            cf.ShowDialog();
        }

      
    }
}
