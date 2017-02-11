using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KOKR
{
    class WinChecker
    {
        Checker checker = new Checker();
        public bool check (Pole[,] P)
        {

            if (checker.Check(P) == BoolCheck.Win)
            {
                MessageBox.Show("Win");
                return true;
            }
            else
            if (checker.Check(P) == BoolCheck.Loose)
            {
                MessageBox.Show("Loose");
                return true;
            }

            else
            if (checker.Check(P) == BoolCheck.Draw)
            {
                MessageBox.Show("Draw");
                return true;
            }
            return false;
        }
    }
}
