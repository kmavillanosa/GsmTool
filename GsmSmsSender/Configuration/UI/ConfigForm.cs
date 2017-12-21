using GsmSmsSender.Configuration.Data;
using GsmSmsSender.Configuration.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GsmSmsSender.Configuration.UI
{
    public partial class ConfigForm : Form
    {
        GsmConfiguration cf = new GsmConfiguration();
        public ConfigForm()
        {
            InitializeComponent();
            propertyGrid1.SelectedObject = cf.config;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cf.Save(cf.config);
            this.Close();
            this.Dispose();
        }
    }
}
