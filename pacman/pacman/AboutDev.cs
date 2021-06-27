using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pacman
{
    public partial class AboutDev : BorderLessForm
    {
        public AboutDev()
        {
            InitializeComponent();
        }
        private void OkAb_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
