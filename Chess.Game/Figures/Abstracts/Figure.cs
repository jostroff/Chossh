namespace Chess.Game.Figures.Abstracts
{
    using Chess.Game.Figures.Contracts;
    using System;
    using Chess.Game.Commons;
    using Chess.Game.Figures.Movements.Contracts;
    using System.Collections.Generic;
    using Chess.Game.Figures.Movements;

    public abstract class Figure : IFigure
    {
        protected readonly string name;
        protected ICollection<IMovement> movements;

        protected Figure(ChessColor color)
        {
            this.Color = color;
            this.name = this.GetType().Name;
        }

        public ChessColor Color { get; private set; }

        public string Name { get { return this.name; } }

        public virtual ICollection<IMovement> GetMovements
        {
            get
            {
                return new List<IMovement>()
                {
                    new PawnVerticalMovement()
                };
            }
        }
    }
}
