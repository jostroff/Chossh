namespace Chess.Game.Figures.Movements
{
    using Chess.Game.Figures.Movements.Abstracts;
    using Chess.Game.Figures.Movements.Contracts;
    using System;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;

    public class QueenMovement : Movement, IMovement
    {
        public override void Validate(IChessboard board, Position from, Position to, ChessColor playerColor)
        {
            base.Validate(board, from, to, playerColor);

            var verticalMoves = Math.Abs(from.Row - to.Row);
            var horizontalMoves = Math.Abs(from.Col - to.Col);

            if (verticalMoves != horizontalMoves && verticalMoves != 0 && horizontalMoves != 0)
            {

                throw new InvalidOperationException("Queen cannot move there");
            }

            base.JumpOverValidate(board, from, to);

        }
    }
}
