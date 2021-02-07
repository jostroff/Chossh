namespace Chess.Game.Players
{
    using Chess.Game.Commons;
    using Chess.Game.Figures.Contracts;
    using Chess.Game.Globals.Validators;
    using Chess.Game.Players.Contracts;
    using System;
    using System.Collections.Generic;
    using static Chess.Game.Globals.Constants;

    public class Player : IPlayer
    {
        private readonly ICollection<IFigure> figures;

        public Player(string name, ChessColor color)
        {
            this.Name = name;
            this.Color = color;
            this.figures = new List<IFigure>();
        }

        public string Name { get; private set; }

        public ChessColor Color { get; private set; }

        public void AddFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsValid(figure, NullFigureMessage);
            this.CheckIfFigureExists(figure);
            this.figures.Add(figure);
        }

        public void RemoveFigure(IFigure figure)
        {
            ObjectValidator.CheckIfObjectIsValid(figure, NullFigureMessage);
            this.CheckIfFigureDoesntExists(figure);
            this.figures.Remove(figure);
        }

        private void CheckIfFigureExists(IFigure figure)
        {
            if (this.figures.Contains(figure))
            {
                throw new InvalidOperationException(FigureExistMessage);
            }
        }

        private void CheckIfFigureDoesntExists(IFigure figure)
        {
            if (!this.figures.Contains(figure))
            {
                throw new InvalidOperationException(FigureDoesntExistMessage);
            }
        }
    }
}
