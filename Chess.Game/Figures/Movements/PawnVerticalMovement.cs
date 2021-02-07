namespace Chess.Game.Figures.Movements
{
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;
    using Chess.Game.Figures.Movements.Abstracts;
    using Chess.Game.Figures.Movements.Contracts;
    using System;

    public class PawnVerticalMovement : Movement, IMovement
    {
        public override void Validate(IChessboard board, Position from, Position to, ChessColor playerColor)
        {
            base.Validate(board, from, to, playerColor);

            var enemyFigure = board.GetBoard[to.Row, to.Col];

            if (playerColor == ChessColor.White)
            {
                if (from.Row != 6)
                {
                    if (from.Row - 1 != to.Row)
                    {
                        throw new InvalidOperationException("You cannot move this pawn there");
                    }
                }
                else
                {
                    if (from.Row - 2 > to.Row)
                    {
                        throw new InvalidOperationException("You cannot move this pawn there");
                    }
                }
            }
            else if (playerColor == ChessColor.Black)
            {
                if (from.Row != 1)
                {
                    if (from.Row + 1 != to.Row)
                    {
                        throw new InvalidOperationException("You cannot move this pawn there");
                    }
                }
                else
                {
                    if (from.Row + 2 < to.Row)
                    {
                        throw new InvalidOperationException("You cannot move this pawn there");
                    }
                }
            }

            if (enemyFigure == null && from.Col - to.Col != 0)
            {
                throw new InvalidOperationException("You cannot move this pawn there");
            }
            else if (enemyFigure != null && enemyFigure.Color != playerColor && Math.Abs(from.Col - to.Col) != 1)
            {
                throw new InvalidOperationException("You cannot move this pawn there");
            }

            base.JumpOverValidate(board, from, to);

        }
    }
}
