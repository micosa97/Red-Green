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
    public partial class Form1 : Form
    {
        Game game = new Game();
        public Form1()
        {
            InitializeComponent();

            game.prepare(this);
            Form2 dialog = new Form2();
            DialogResult i = dialog.ShowDialog();
            if (Convert.ToInt16(i) == 7) game.FistMove();      

        }

      

        private void Test ()
        {
            //button1.Text = "s";

        }
       
        public void choose(object sender, EventArgs e)
        {
            
            //System.Threading.Thread thr = new System.Threading.Thread(thr());
            game.edit(sender);
            //label1.Visible = false;

        }
        public void thr(Form1 send)
        {
            label1.Visible = true;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
           // game.imCheck();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            game.Redo();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
