using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOKR
{
    class Game 
    {
        protected Pole[,] pola = new Pole[15, 15];
        protected System.Windows.Forms.Button[,] nB = new System.Windows.Forms.Button[15, 15];
        protected Translator translator = new Translator();
       // protected Checker checker = new Checker();
        private WinChecker WinChecker = new WinChecker();
        protected Tactics tactics = new Tactics();
        public void imsdCheck()
        {
            MessageBox.Show(Convert.ToString(WinChecker.check(pola)));
        }
        public void prepare (Form1 form)
        {
            
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    pola[i, j] = Pole.Cant;
                    nB[i,j] = new System.Windows.Forms.Button();
                    nB[i,j].Size = new System.Drawing.Size(25, 25);
                    nB[i,j].Location = new System.Drawing.Point(10 + 25 * (i), 10 + (j) * 25);
                    nB[i,j].Name = "B" + ((i < 10) ? "0" : "") + ((i).ToString()) + ((j < 10) ? "0" : "") + (j).ToString();
                    nB[i,j].Click += new EventHandler(form.choose);
                   // nB[i,j].BackColor = System.Drawing.Color.Tan;
                    //nB[i,j].Enabled = false;


                    form.Controls.Add(nB[i,j]);
                }
            }
          //  nB[7,7].BackColor = System.Drawing.Color.Gray;
           // nB[7,7].Enabled = true;
            pola[7, 7] = Pole.Can;
            translator.ArrayToForm(pola, nB);

        }
        public void Redo ()
        {
            tactics.moving.Redo(pola);
            translator.ArrayToForm(pola, nB);
        }
        public void AI ()
        {
            
            tactics.move(pola);
            translator.ArrayToForm(pola, nB);
            if (WinChecker.check(pola)) GameOver();
            /*if (checker.Check(pola) == BoolCheck.Win) MessageBox.Show("Win");
            else
            if (checker.Check(pola) == BoolCheck.Loose) MessageBox.Show("Loose");
            else
            if (checker.Check(pola) == BoolCheck.Draw) MessageBox.Show("Draw");
              */  

        }
        private void GameOver()
        {
            for (int i=0; i<15; i++)
                for (int j=0; j<15; j++)
                {
                    nB[i, j].Enabled = false;
                }
            
        }
        public void FistMove()
        {
            int h = 7, l = 7;
            tactics.moving.move(pola, Pole.Green, ref h, ref l);
            translator.ArrayToForm(pola, nB);

        }
        public void edit (object w)
        {
            // MessageBox.Show((sender as Button).Name.ToString());
            Button przycisk = (w as Button);
            // MessageBox.Show((Convert.ToInt16(((w as Button).Name.ToString())[1])).ToString());
            int h = (Convert.ToInt16(((w as Button).Name.ToString())[1]) - 48) * 10 + Convert.ToInt16((((w as Button).Name.ToString())[2]) - 48);
            int l = (Convert.ToInt16(((w as Button).Name.ToString())[3]) - 48) * 10 + Convert.ToInt16((((w as Button).Name.ToString())[4]) - 48);

            
            tactics.moving.move(pola, Pole.Red, ref h, ref l);
            translator.ArrayToForm(pola, nB);
            if (WinChecker.check(pola))
                GameOver();
            else
            /*if (checker.Check(pola) == BoolCheck.Win) MessageBox.Show("Win");
            else
            if (checker.Check(pola) == BoolCheck.Loose) MessageBox.Show("Loose");
            else
            if (checker.Check(pola) == BoolCheck.Draw) MessageBox.Show("Draw");
            else*/
                AI();


        }


    }
}
