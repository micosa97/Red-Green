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

            game.prepare(this);  //przygotowanie buttonw
            Form2 dialog = new Form2();  //formatka dialogowa
            DialogResult i = dialog.ShowDialog();
            if (Convert.ToInt16(i) == 7) game.FistMove(); //if zaczyna AI wykonaj ruch      

        }

        public void choose(object sender, EventArgs e)
        {

            game.edit(sender); //wykonaj ruch - wyslij nazwe klikniętego buttona

        }


        private void button1_Click_2(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
