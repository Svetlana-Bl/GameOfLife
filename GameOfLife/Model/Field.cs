using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model
{
    public class Field
    {
        bool[,] UniverseField { get; set; }
        int FieldSize { get; set; }
    }
}
