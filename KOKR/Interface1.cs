using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOKR
{
    enum Pole
    {
        Green,
        Red,
        Can, //mozna klinąć
        Cant //nie można i niekolorowe
    }

    enum BoolCheck
    {
        Win,
        Loose,
        Null, //brak wyniku
        Draw
    }
}
