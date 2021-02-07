using Chess.Game.Commons;
using Chess.Game.Figures.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game.Players.Contracts
{
    public interface IPlayer
    {
        string Name { get; }

        ChessColor Color { get; }

        void AddFigure(IFigure figure);

        void RemoveFigure(IFigure figure);

    }
}
