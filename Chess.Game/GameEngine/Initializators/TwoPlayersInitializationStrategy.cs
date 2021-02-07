namespace Chess.Game.GameEngine.Initializators
{
    using Chess.Game.GameEngine.Contracts;
    using System;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Players.Contracts;
    using System.Collections.Generic;
    using Chess.Game.Figures;
    using Chess.Game.Commons;
    using Chess.Game.Figures.Contracts;

    public class TwoPlayersInitializationStrategy : IGameInitializationStrategy
    {
        private Type[] figureTypes;

        public TwoPlayersInitializationStrategy()
        {
            this.figureTypes = new Type[]
            {
                typeof(Rook), typeof(Knight), typeof(Bishop), typeof(Queen), typeof(King), typeof(Bishop), typeof(Knight), typeof(Rook)
            };
        }

        public void Initialize(IList<IPlayer> players, IChessboard board)
        {
            this.ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            this.AddSpecialFigures(firstPlayer, board, 7);
            this.AddPawns(firstPlayer, board, 6);

            this.AddSpecialFigures(secondPlayer, board, 0);
            this.AddPawns(secondPlayer, board, 1);

        }

        private void AddSpecialFigures(IPlayer player, IChessboard board, int row)
        {
            for (int i = 0; i < figureTypes.Length; i++)
            {
                var figure = (IFigure)Activator.CreateInstance(figureTypes[i], player.Color);
                player.AddFigure(figure);
                var position = new Position(row, i);
                board.AddFigure(figure, position);
            }
        }

        private void AddPawns(IPlayer player, IChessboard board, int row)
        {
            for (int i = 0; i < 8; i++)
            {
                var pawn = new Pawn(player.Color);
                player.AddFigure(pawn);
                var position = new Position(row, i);
                board.AddFigure(pawn, position);
            }
        }

        private void ValidateStrategy(IList<IPlayer> players, IChessboard board)
        {
            if (players.Count != 2)
            {
                throw new InvalidOperationException("This strategy expect two players!");
            }

            if (board.Rows != 8 || board.Cols != 8)
            {
                throw new InvalidOperationException("This strategy requires 8 rows and 8 cols");
            }
        }
    }
}
