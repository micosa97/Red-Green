using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOKR
{
    class loc
    {
        public int x;
        public int y;
        public Pole bef;
        public Pole aft;
        public loc (int x, int y, Pole bef, Pole aft) 
            {
                this.x = x;
                this.y = y;
                this.bef = bef;
                this.aft = aft;
            }

    }
    class Moving
    {
        
        Stack <loc> operations = new Stack<loc>();
        Stack <int> howmany = new Stack<int>();
       
        
        public void move (Pole[,] pola, Pole Kolor, ref int h, ref int l)
        {
            operations.Push(new loc(h, l, pola[h, l], Kolor));
            pola[h, l] = Kolor;

            int i = 1;

            try { if (pola[h + 1, l] == Pole.Cant) { operations.Push(new loc(h + 1, l, pola[h + 1, l], Pole.Can)); i++; pola[h + 1, l] = Pole.Can; } } catch { }
            try { if (pola[h - 1, l] == Pole.Cant) { operations.Push(new loc(h - 1, l, pola[h - 1, l], Pole.Can)); i++; pola[h - 1, l] = Pole.Can; } } catch { }
            try { if (pola[h, l + 1] == Pole.Cant) { operations.Push(new loc(h, l + 1, pola[h, l + 1], Pole.Can)); i++; pola[h, l + 1] = Pole.Can; } } catch { }
            try { if (pola[h, l - 1] == Pole.Cant) { operations.Push(new loc(h, l - 1, pola[h, l - 1], Pole.Can)); i++; pola[h, l - 1] = Pole.Can; } } catch { }
           // try { if (pola[h + 1, l + 1] == Pole.Cant) { operations.Push(new loc(h + 1, l + 1, pola[h + 1, l + 1], Pole.Can)); i++; pola[h + 1, l + 1] = Pole.Can; } } catch { }
            //try { if (pola[h - 1, l + 1] == Pole.Cant) { operations.Push(new loc(h - 1, l + 1, pola[h - 1, l + 1], Pole.Can)); i++; pola[h - 1, l + 1] = Pole.Can; } } catch { }
            //try { if (pola[h + 1, l - 1] == Pole.Cant) { operations.Push(new loc(h + 1, l - 1, pola[h + 1, l - 1], Pole.Can)); i++; pola[h + 1, l - 1] = Pole.Can; } } catch { }
          //  try { if (pola[h - 1, l - 1] == Pole.Cant) { operations.Push(new loc(h - 1, l - 1, pola[h - 1, l - 1], Pole.Can)); i++; pola[h - 1 ,l - 1] = Pole.Can; } } catch { }
            howmany.Push(i);
        }

        public void Redo (Pole[,] pola)
        {
           if (howmany.Count!=0)
            {
                int h = howmany.Pop();
                for (int i = 0; i < h; i++)
                {
                    loc op = new loc(-1, -1, Pole.Cant, Pole.Cant);
                    op = operations.Pop();

                    pola[op.x, op.y] = op.bef;
                }

            }
            
        }
        
        
       // public 

    }
}
