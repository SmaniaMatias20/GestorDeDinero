using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class UserControlRetiro : UserControl
    {
        public UserControlRetiro()
        {
            InitializeComponent();
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {

        }

        private void buttonBorrar_Click(object sender, EventArgs e)
        {

            textBoxRetiro.Text = "";
        }

        private void textBoxRetiro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
