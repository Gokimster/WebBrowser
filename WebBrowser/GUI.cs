using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
            address.KeyDown += new KeyEventHandler(address_KeyDown);
            //address.Click += new EventHandler(address_Click);
        }

        private void address_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               pageContent.Text= WebManager.getPage(address.Text);
            }
        }
        private void address_GotFocus(object sender, KeyEventArgs e)
        {
            address.SelectAll();
        }


    }
}
