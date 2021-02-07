namespace Chess.Game.Figures
{
    using Chess.Game.Figures.Contracts;
    using System;
    using Chess.Game.Commons;
    using Chess.Game.Figures.Abstracts;
    using Chess.Game.Figures.Movements.Contracts;
    using System.Collections.Generic;
    using Chess.Game.Figures.Movements;

    public class Pawn : Figure, IFigure
    {
        public Pawn(ChessColor color) : base(color)
        {
        }
    }
}
