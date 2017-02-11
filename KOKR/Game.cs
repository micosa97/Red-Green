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
        protected Pole[,] P = new Pole[15, 15];  //tablica na któej dokonujemy symulacji
        protected Button[,] nB = new Button[15, 15];  //tablica buttonów na form1
        protected Translator translator = new Translator(); //zamienianie tablicy P na rzeczywiste zmieny na w nB na buttonach
        private WinChecker WinChecker = new WinChecker(); //sprawdzanie zwycięstwa i wyświetlanie komunikatów
        protected Tactics tactics = new Tactics(); //klasa taktyczna
        public void prepare(Form1 form)
        {

            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    P[i, j] = Pole.Cant;
                    nB[i, j] = new Button();
                    nB[i, j].Size = new System.Drawing.Size(25, 25);
                    nB[i, j].Location = new System.Drawing.Point(10 + 25 * (i), 10 + (j) * 25);
                    nB[i, j].Name = "B" + ((i < 10) ? "0" : "") + ((i).ToString()) + ((j < 10) ? "0" : "") + (j).ToString();
                    nB[i, j].Click += new EventHandler(form.choose);
                    form.Controls.Add(nB[i, j]);
                }
            }
            P[7, 7] = Pole.Can;  //zaczęcie
            translator.ArrayToForm(P, nB);

        }
        public void AI()  //algo wykonujący ruch komputeraz
        {

            tactics.move(P);
            translator.ArrayToForm(P, nB);
            if (WinChecker.check(P)) GameOver();
        }
        private void GameOver()  //gdy gra się konczy to mrozimy forme
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    nB[i, j].Enabled = false;
                }

        }
        public void FistMove()
        {
            int h = 7, l = 7;
            tactics.moving.move(P, Pole.Green, ref h, ref l);
            translator.ArrayToForm(P, nB);

        }
        public void edit(object w)  //player gra nacikając na Button z sendera
        {

            Button przycisk = (w as Button);
            int h = (Convert.ToInt16(((w as Button).Name.ToString())[1]) - 48) * 10 + Convert.ToInt16((((w as Button).Name.ToString())[2]) - 48);
            int l = (Convert.ToInt16(((w as Button).Name.ToString())[3]) - 48) * 10 + Convert.ToInt16((((w as Button).Name.ToString())[4]) - 48);
            //zamiana na wspolrzedna w Pole P[,];

            tactics.moving.move(P, Pole.Red, ref h, ref l); //wykonaj ruch
            translator.ArrayToForm(P, nB); //...i dokonaj zmian na formie
            if (WinChecker.check(P))
                GameOver();
            else
                AI();


        }


    }
}
