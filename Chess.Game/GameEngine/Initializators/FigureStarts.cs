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
        public FigureStarts(Type t, Position p)
        {
            type = t;
            position = p;
        }
        public FigureStarts()
        {
            type = typeof(Pawn);
            position = new Position(0, 0);
        }
        public Type getType()
        {
            return type;
        }
        public Position getPosition()
        {
            return position;
        }
    }
}
