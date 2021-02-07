using Chess.Game.Commons;
using Chess.Game.Figures.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game.Chessboard.Contracts
{
    public interface IChessboard
    {
        int Rows { get; }

        int Cols { get; }
        IFigure[,] GetBoard { get; }

        void AddFigure(IFigure figure, Position position);

        IFigure RemoveFigure(Position position);
    }
}
