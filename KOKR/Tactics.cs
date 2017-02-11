using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOKR
{
    class Tactics
    {
        Random random = new Random();
        Checker checker = new Checker();
        public Moving moving = new Moving();
        public void move(Pole[,] P)
        {
            if (!ObviousAttack(P, Pole.Green, true))    //podstawowe strategia opierające się na symuacjach a'ala rekurencyjnych
                if (!ObviousDefence(P, Pole.Green, true))
                    if (!MakingObviousAttack(P, Pole.Green, true, false))
                        if (!MakingObviousDefence(P, Pole.Green, true))
                            if (!PreparingMakingObviousAttack(P, Pole.Green, true))
                                //if (!DefenceMakingObviousAttack(P, Pole.Green, true))  //nieskuteczne, obniżające bardzo wydajność
                                if (!PreparingMakingObviousAttack(P, Pole.Green, false))
                                //if (!DefenceMakingObviousAttack(P, Pole.Green, false))
                                {
                                    Rand(P);

                                }



        }
        private void Rand(Pole[,] P)  //losujemy i odrzucamy przypadki nieoptymalne
        {

            int rnd = random.Next(0, 14);
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[(i + rnd) % 15, (j + rnd) % 15] == Pole.Can)
                    {
                        int h = (i + rnd) % 15;
                        int l = (j + rnd) % 15;
                        moving.move(P, Pole.Green, ref h, ref l);
                        if (ObviousAttack(P, Pole.Red, false) || MakingObviousAttack(P, Pole.Red, false, false))
                            moving.Redo(P);
                        else
                            return;

                    }
                }
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[(i + rnd) % 15, (j + rnd) % 15] == Pole.Can)
                    {
                        int h = (i + rnd) % 15;
                        int l = (j + rnd) % 15;
                        moving.move(P, Pole.Green, ref h, ref l);
                        if (ObviousAttack(P, Pole.Red, false) || MakingObviousAttack(P, Pole.Red, false, true))
                            moving.Redo(P);
                        else
                            return;

                    }
                }

            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[(i + rnd) % 15, (j + rnd) % 15] == Pole.Can)
                    {
                        int h = (i + rnd) % 15;
                        int l = (j + rnd) % 15;
                        moving.move(P, Pole.Green, ref h, ref l);
                        if (ObviousAttack(P, Pole.Red, false))
                            moving.Redo(P);
                        else
                            return;

                    }
                }

            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[(i + rnd) % 15, (j + rnd) % 15] == Pole.Can)
                    {
                        int h = (i + rnd) % 15;
                        int l = (j + rnd) % 15;
                        moving.move(P, Pole.Green, ref h, ref l);
                        return;

                    }
                }

        }
        private bool DefenceMakingObviousAttack(Pole[,] P, Pole Colour, bool sure)  //nieuzywane, bledy
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[i, j] == Pole.Can)
                    {
                        moving.move(P, (Colour == Pole.Red ? Pole.Green : Pole.Red), ref i, ref j);
                        if (MakingObviousAttack(P, (Colour == Pole.Red ? Pole.Green : Pole.Red), false, sure))
                        {
                            moving.Redo(P);
                            moving.move(P, Colour, ref i, ref j);
                            return true;
                        }
                        moving.Redo(P);
                    }

                }
            return false;
        }

        private bool PreparingMakingObviousAttack(Pole[,] P, Pole Colour, bool sure)
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[i, j] == Pole.Can)
                    {
                        moving.move(P, Colour, ref i, ref j);
                        if (MakingObviousAttack(P, Colour, false, sure) && !ObviousAttack(P, (Colour == Pole.Red ? Pole.Green : Pole.Red), false))
                        {
                            return true;
                        }
                        moving.Redo(P);
                    }

                }
            return false;
        }
        private bool MakingObviousDefence(Pole[,] P, Pole Colour, bool toDo)
        {

            int tx = -1, ty = -1;
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[i, j] == Pole.Can)
                    {
                        moving.move(P, (Colour == Pole.Red ? Pole.Green : Pole.Red), ref i, ref j);
                        if (ObviousAttack(P, (Colour == Pole.Red ? Pole.Green : Pole.Red), false))
                        {
                            P[i, j] = (Colour);
                            if (!ObviousAttack(P, (Colour == Pole.Red ? Pole.Green : Pole.Red), false))
                            {
                                P[i, j] = (Colour == Pole.Red ? Pole.Green : Pole.Red); //uniknięcie sytuacji stworzenie oczywistego ataku dla gracza
                                if (!ObviousDefence(P, Colour, false))
                                {
                                    moving.Redo(P);
                                    if (toDo)
                                    {
                                        moving.move(P, Colour, ref i, ref j);
                                    }
                                    return true;
                                }
                                else
                                {
                                    tx = i; ty = j;
                                }

                            }

                        }
                        moving.Redo(P);
                    }

                }
            if (tx != -1 && ty != -1)
            {
                if (toDo) moving.move(P, Colour, ref tx, ref ty);
                return true;
            }
            return false;
        }
        private bool MakingObviousAttack(Pole[,] P, Pole Colour, bool toDo, bool sure)
        {
            int tx = -1, ty = -1;
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[i, j] == Pole.Can)
                    {
                        moving.move(P, Colour, ref i, ref j);
                        if (ObviousAttack(P, Colour, false) && !ObviousAttack(P, (Colour == Pole.Red ? Pole.Green : Pole.Red), false))
                        {
                            if (!ObviousDefence(P, (Colour == Pole.Red ? Pole.Green : Pole.Red), false))
                            {
                                if (!toDo) moving.Redo(P);
                                return true;
                            }
                            else
                            {
                                tx = i; ty = j;
                            }
                        }
                        moving.Redo(P);
                    }

                }
            if (tx != -1 && ty != -1 && !sure)
            {
                if (toDo) moving.move(P, Colour, ref tx, ref ty);
                return true;
            }
            return false;
        }
        private bool ObviousAttack(Pole[,] P, Pole Colour, bool toDo)
        {
            for (int i = 0; i < 15; i++)
                for (int j = 0; j < 15; j++)
                {
                    if (P[i, j] == Pole.Can)
                    {
                        moving.move(P, Colour, ref i, ref j);
                        if (checker.Check(P) == ((Colour == Pole.Green) ? (BoolCheck.Loose) : (BoolCheck.Win)))
                        {
                            //if (toDo) moving.move(P, Colour, ref i, ref j);
                            if (!toDo) moving.Redo(P); // neew
                            //else P[i, j] = Pole.Can;
                            return true;
                        }
                        //P[i, j] = Pole.Can;
                        moving.Redo(P);
                    }
                }
            return false;

        }

        private bool ObviousDefence(Pole[,] P, Pole Colour, bool toDo)
        {
            if (ObviousAttack(P, (Colour == Pole.Green) ? Pole.Red : Pole.Green, false))
            {
                for (int i = 0; i < 15; i++)
                    for (int j = 0; j < 15; j++)
                    {
                        if (P[i, j] == Pole.Can)
                        {
                            moving.move(P, Colour, ref i, ref j);
                            {
                                if (!ObviousAttack(P, (Colour == Pole.Green) ? Pole.Red : Pole.Green, false))
                                {
                                    if (!toDo) moving.Redo(P); //
                                    // moving.move(P, Colour, ref i, ref j);
                                   // else P[i, j] = Pole.Can;
                                    return true;
                                }
                            }
                            moving.Redo(P);
                        }
                    }
            }
            return false;


        }


    }
}
