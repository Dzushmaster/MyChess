using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic
{
    sealed class Coords
    {
        public sbyte Row { get; set; }
        public sbyte Column { get; set; }
        public Coords(sbyte Row, sbyte Column)
        {
            this.Row = Row;
            this.Column = Column;
        }
        public override string ToString()
        {
            return Row + ";" + Column;
        }
    }
}
