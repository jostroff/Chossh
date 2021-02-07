namespace Chess.Game.Chessboard
{
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;
    using Chess.Game.Figures.Contracts;
    using Chess.Game.Globals.Validators;
    using System;
    using static Chess.Game.Globals.Constants;

    public class Chessboard : IChessboard
    {
        private readonly IFigure[,] chessboard;

        public Chessboard(int rows = DefaultGameRows, int cols = DefaultGameCols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.chessboard = new IFigure[rows, cols];
        }

        public int Rows { get; private set; }

        public int Cols { get; private set; }

        public IFigure[,] GetBoard { get { return this.chessboard; } }

        public void AddFigure(IFigure figure, Position position)
        {
            ObjectValidator.CheckIfObjectIsValid(figure, NullFigureMessage);
            ObjectValidator.CheckIfPositionIsValid(position, InvalidPositionMessage);
            int arrRow = position.Row;
            int arrCol = position.Col;
            this.chessboard[arrRow, arrCol] = figure;

        }

        public IFigure RemoveFigure(Position position)
        {
            ObjectValidator.CheckIfPositionIsValid(position, InvalidPositionMessage);

            int arrRow = position.Row;
            int arrCol = position.Col;
            var figure = this.chessboard[arrRow, arrCol];
            this.chessboard[arrRow, arrCol] = null;
            return figure;

        }
    }
}
