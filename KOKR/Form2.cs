using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOKR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  Game game = new Game();
            this.Close();
         //   this.Hide();
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            //  Game game = new Game();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            //   this.Close();
        }
    }
}
