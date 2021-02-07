namespace Chess.Game.Figures.Movements.Abstracts
{
    using Chess.Game.Figures.Movements.Contracts;
    using System;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;

    public abstract class Movement : IMovement
    {
        public virtual void Validate(IChessboard board, Position from, Position to, ChessColor playerColor)
        {
            var figure = board.GetBoard[from.Row, from.Col];
            var enemyFigure = board.GetBoard[to.Row, to.Col];

            if (figure == null)
            {
                throw new InvalidOperationException("You have to select a figure");
            }

            if (enemyFigure != null && enemyFigure.Color == playerColor)
            {
                throw new InvalidOperationException("You cannot get own figure");
            }

            if (figure.Color != playerColor)
            {
                throw new InvalidOperationException("You cannot move enemy figure");
            }
        }

        protected void JumpOverValidate(IChessboard board, Position from, Position to)
        {
            bool reachedRow = false;
            bool reachedCol = false;

            var remainingRows = from.Row - to.Row;
            var remainingCols = from.Col - to.Col;

            var destinationRow = to.Row;
            var destinationCol = to.Col;

            while (!reachedRow || !reachedCol)
            {
                if (remainingRows != 0)
                {
                    remainingRows = remainingRows > 0 ? remainingRows - 1 : remainingRows + 1;
                }
                if (remainingCols != 0)
                {
                    remainingCols = remainingCols > 0 ? remainingCols - 1 : remainingCols + 1;
                }

                if (remainingCols == 0)
                {
                    reachedCol = true;
                }
                if (remainingRows == 0)
                {
                    reachedRow = true;
                }

                if (reachedRow && reachedCol)
                {
                    break;
                }

                var currentFigure = board.GetBoard[destinationRow + remainingRows, destinationCol + remainingCols];

                if (currentFigure != null && (!reachedCol || !reachedRow))
                {
                    throw new InvalidOperationException("You cannot step onto a figure");
                }
            }
        }
    }
}
