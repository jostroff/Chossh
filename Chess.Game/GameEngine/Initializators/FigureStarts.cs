using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game.GameEngine.Initializators
{
    using Chess.Game.GameEngine.Contracts;
    using System;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Players.Contracts;
    using System.Collections.Generic;
    using Chess.Game.Figures;
    using Chess.Game.Commons;
    using Chess.Game.Figures.Contracts;
    public class FigureStarts
    { //JOstroff - New object structure.
        Type type;
        Position position; //Takes row (side), col (varies by piece).
        bool pawnStatus;

        public FigureStarts(Type t, Position p, bool ps)
        {
            type = t;
            position = p;
            pawnStatus = ps;
        }
        public FigureStarts()
        {
            type = typeof(Pawn);
            position = new Position(0, 0);
            pawnStatus = true;
        }
        public Type getType()
        {
            return type;
        }
        public Position getPosition()
        {
            return position;
        }
        public bool isPawn()
        {
            return pawnStatus;
        }
    }
}
