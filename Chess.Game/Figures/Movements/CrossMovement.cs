namespace Chess.Game.Figures.Movements
{
    using Chess.Game.Figures.Movements.Abstracts;
    using Chess.Game.Figures.Movements.Contracts;
    using System;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;

    public class CrossMovement : Movement, IMovement
    {
        public override void Validate(IChessboard board, Position from, Position to, ChessColor playerColor)
        {
            base.Validate(board, from, to, playerColor);

            var verticalMoves = Math.Abs(from.Row - to.Row);
            var horizontalMoves = Math.Abs(from.Col - to.Col);
            
            if (verticalMoves - horizontalMoves != 0)
            {
                throw new InvalidOperationException("You cannot move this figure there");
            }

            base.JumpOverValidate(board, from, to);
        }
    }
}
