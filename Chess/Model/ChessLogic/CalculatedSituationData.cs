using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Model.ChessLogic
{
    class CalculatedSituationData
    {
        public HashSet<Coords> EnemyPossibleAttacks { get; set; }
        public List<Coords> KingPropertyPiecesCoords { get; set; }
        public CalculatedSituationData()
        {
            EnemyPossibleAttacks = new HashSet<Coords>();
            KingPropertyPiecesCoords = new List<Coords>();
        }
    }
}
