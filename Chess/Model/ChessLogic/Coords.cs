using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic
{
    sealed class Coords
    {
        public SByte Row { get; set; }
        public SByte Column { get; set; }
        public Coords(SByte Row, SByte Column)
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
