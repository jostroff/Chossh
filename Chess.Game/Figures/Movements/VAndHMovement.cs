namespace Chess.Game.Figures.Movements
{
    using Chess.Game.Figures.Movements.Abstracts;
    using Chess.Game.Figures.Movements.Contracts;
    using System;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;

    public class VAndHMovement : Movement, IMovement
    {
        public override void Validate(IChessboard board, Position from, Position to, ChessColor playerColor)
        {
            base.Validate(board, from, to, playerColor);

            if ((from.Col != to.Col && from.Row == to.Row) || (from.Col == to.Col && from.Row != to.Row))
            {
                base.JumpOverValidate(board, from, to);

                return;
            }
            else
            {
                throw new InvalidOperationException("You cannot move there");
            }

        }
    }
}
