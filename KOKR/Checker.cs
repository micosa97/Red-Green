using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOKR
{
    class Checker
    {
        public BoolCheck Check (Pole[,] pola)
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 11; j++)
                {
                    if (pola[i, j] == pola[i, j + 1] && pola[i, j + 1] == pola[i, j + 2] && pola[i, j + 2] == pola[i, j + 3] && pola[i, j + 3] == pola[i, j + 4])
                    {
                        if (pola[i, j] == Pole.Red)
                        {
                            return BoolCheck.Win;
                        }
                        if (pola[i, j] == Pole.Green)
                        {
                            return BoolCheck.Loose;
                        }

                    }
                }

            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (pola[i, j] == pola[i + 1, j] && pola[i + 1, j] == pola[i + 2, j] && pola[i + 2, j] == pola[i + 3, j] && pola[i + 3, j] == pola[i + 4, j])
                    {
                        if (pola[i, j] == Pole.Red)
                        {
                            return BoolCheck.Win;
                        }
                        if (pola[i, j] == Pole.Green)
                        {
                            return BoolCheck.Loose;
                        }

                    }
                }

            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 11; j++)
                {
                    if (pola[i, j] == pola[i + 1, j + 1] && pola[i + 1, j + 1] == pola[i + 2, j + 2] && pola[i + 2, j + 2] == pola[i + 3, j + 3] && pola[i + 3, j + 3] == pola[i + 4, j + 4])
                    {
                        if (pola[i, j] == Pole.Red)
                        {
                            return BoolCheck.Win;
                        }
                        if (pola[i, j] == Pole.Green)
                        {
                            return BoolCheck.Loose;
                        }

                    }
                }
            for (int i = 0; i < 11; i++)
                for (int j = 0; j < 11; j++)
                {
                    if (pola[i+4, j] == pola[i + 3, j + 1] && pola[i + 3, j + 1] == pola[i + 2, j + 2] && pola[i + 2, j + 2] == pola[i + 1, j + 3] && pola[i + 1, j + 3] == pola[i, j + 4])
                    {
                        if (pola[i+4, j] == Pole.Red)
                        {
                            return BoolCheck.Win;
                        }
                        if (pola[i+4, j] == Pole.Green)
                        {
                            return BoolCheck.Loose;
                        }

                    }
                }
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (pola[i,j]==Pole.Can) return BoolCheck.Null;
                }

            return BoolCheck.Draw;

                    
        }
    }
}
