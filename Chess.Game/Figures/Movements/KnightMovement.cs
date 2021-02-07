namespace Chess.Game.Figures.Movements
{
    using Chess.Game.Figures.Movements.Abstracts;
    using Chess.Game.Figures.Movements.Contracts;
    using System;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;

    public class KnightMovement : Movement, IMovement
    {
        public override void Validate(IChessboard board, Position from, Position to, ChessColor playerColor)
        {
            base.Validate(board, from, to, playerColor);

            var verticalMoves = Math.Abs(from.Row - to.Row);
            var horizontalMoves = Math.Abs(from.Col - to.Col);

            if ((verticalMoves == 1 && horizontalMoves == 2) || (verticalMoves == 2 && horizontalMoves == 1))
            {
                return;
            }

            throw new InvalidOperationException("You cannot move this figure there");
        }
    }
}
