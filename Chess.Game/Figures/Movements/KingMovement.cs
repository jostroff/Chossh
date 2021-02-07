namespace Chess.Game.Figures.Movements
{
    using Chess.Game.Figures.Movements.Contracts;
    using System;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;
    using Chess.Game.Figures.Movements.Abstracts;

    public class KingMovement : Movement, IMovement
    {
        public override void Validate(IChessboard board, Position from, Position to, ChessColor playerColor)
        {
            base.Validate(board, from, to, playerColor);

            var verticalMoves = Math.Abs(from.Row - to.Row);
            var horizontalMoves = Math.Abs(from.Col - to.Col);

            if (verticalMoves > 1 || horizontalMoves > 1)
            {
                throw new InvalidOperationException("King cannot move there");
            }
        }
    }
}
