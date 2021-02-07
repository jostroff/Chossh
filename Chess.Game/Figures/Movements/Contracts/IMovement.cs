using Chess.Game.Chessboard.Contracts;
using Chess.Game.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game.Figures.Movements.Contracts
{
    public interface IMovement
    {
        void Validate(IChessboard board, Position from, Position to, ChessColor color);
    }
}
