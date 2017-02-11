using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOKR
{
    class Translator
    {
        public void FormsdToArray(Button[,] B, Pole[,] P)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                    if (B[i, j].BackColor == System.Drawing.Color.Tan) P[i, j] = Pole.Cant;
                    if (B[i, j].BackColor == System.Drawing.Color.Gray) P[i, j] = Pole.Can;
                    if (B[i, j].BackColor == System.Drawing.Color.Green) P[i, j] = Pole.Green;
                    if (B[i, j].BackColor == System.Drawing.Color.Red) P[i, j] = Pole.Red;


                }
            }
        }

        public void ArrayToForm(Pole[,] P, Button[,] B)
        {
            for (int i = 0; i < 15; i++)
            {
                for (int j = 0; j < 15; j++)
                {
                     if (B[i, j].BackColor == System.Drawing.Color.LightGreen)
                    {
                        //B[i, j].BackColor = System.Drawing.Color.Aqua;
                        //System.Threading.Thread.Sleep(1000);
                        B[i, j].BackColor = System.Drawing.Color.Green;
                        // B[i, j].Enabled = false;
                    }


                    if (P[i, j] == Pole.Cant && B[i, j].BackColor != System.Drawing.Color.Tan)
                    {
                        B[i, j].BackColor = System.Drawing.Color.Tan;
                        B[i, j].Enabled = false;
                    }

                    if (P[i, j] == Pole.Can && B[i, j].BackColor != System.Drawing.Color.Gray)
                    {
                        B[i, j].BackColor = System.Drawing.Color.Gray;
                        B[i, j].Enabled = true;
                    }
                    
                    if (P[i, j] == Pole.Green && B[i, j].BackColor != System.Drawing.Color.Green)
                    {
                        //B[i, j].BackColor = System.Drawing.Color.Aqua;
                        //System.Threading.Thread.Sleep(1000);
                        B[i, j].BackColor = System.Drawing.Color.LightGreen;
                        B[i, j].Enabled = false;
                    }
                    

                    if (P[i, j] == Pole.Red && B[i, j].BackColor != System.Drawing.Color.Red)
                    {
                        B[i, j].BackColor = System.Drawing.Color.Red;
                        B[i, j].Enabled = false;
                    }


                }
            }
        }
    }
}
