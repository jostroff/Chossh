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

    public class TwoPlayersInitializationChossh : IGameInitializationStrategy
    {
        //Originally Type[].
        //private FigureStarts[] figureTypes;
        private FigureStarts[] firstFigures, secondFigures;

        public TwoPlayersInitializationChossh()
        {
            this.firstFigures = new FigureStarts[]
            { //Note this is 0 Ro, 1 Kn, 2 Bi, 3 Qu, 4 Ki, 5 Bi, 6 Kn, 7 Ro
                new FigureStarts(typeof(Rook), new Position(0, 0), false),
                new FigureStarts(typeof(Knight), new Position(0, 1), false),
                new FigureStarts(typeof(Bishop), new Position(0, 2), false),
                new FigureStarts(typeof(Queen), new Position(0, 3), false),
                new FigureStarts(typeof(King), new Position(0, 4), false),
                new FigureStarts(typeof(Bishop), new Position(0, 5), false),
                new FigureStarts(typeof(Knight), new Position(0, 6), false),
                new FigureStarts(typeof(Rook), new Position(0, 7), false)
                ,
                new FigureStarts(typeof(Pawn), new Position(1, 0), true),
                new FigureStarts(typeof(Pawn), new Position(1, 1), true),
                new FigureStarts(typeof(Pawn), new Position(1, 2), true),
                new FigureStarts(typeof(Queen), new Position(1, 3), false),
                new FigureStarts(typeof(Pawn), new Position(1, 4), true),
                new FigureStarts(typeof(Pawn), new Position(1, 5), true),
                new FigureStarts(typeof(Pawn), new Position(1, 6), true),
                new FigureStarts(typeof(Pawn), new Position(1, 7), true)
            };
            this.secondFigures = new FigureStarts[]
            { //Note this is 0 Ro, 1 Kn, 2 Bi, 3 Qu, 4 Ki, 5 Bi, 6 Kn, 7 Ro
                new FigureStarts(typeof(Rook), new Position(7, 0), false),
                new FigureStarts(typeof(Knight), new Position(7, 1), false),
                new FigureStarts(typeof(Bishop), new Position(7, 2), false),
                new FigureStarts(typeof(Queen), new Position(7, 3), false),
                new FigureStarts(typeof(King), new Position(7, 4), false),
                new FigureStarts(typeof(Bishop), new Position(7, 5), false),
                new FigureStarts(typeof(Knight), new Position(7, 6), false),
                new FigureStarts(typeof(Rook), new Position(7, 7), false)
                ,
                new FigureStarts(typeof(Pawn), new Position(6, 0), true),
                new FigureStarts(typeof(Pawn), new Position(6, 1), true),
                new FigureStarts(typeof(Pawn), new Position(6, 2), true),
                new FigureStarts(typeof(Pawn), new Position(6, 3), true),
                new FigureStarts(typeof(Pawn), new Position(6, 4), true),
                new FigureStarts(typeof(Pawn), new Position(6, 5), true),
                new FigureStarts(typeof(Pawn), new Position(6, 6), true),
                new FigureStarts(typeof(Pawn), new Position(6, 7), true)
            };
        }


        public void Initialize(IList<IPlayer> players, IChessboard board)
        {
            this.ValidateStrategy(players, board);

            var firstPlayer = players[0];
            var secondPlayer = players[1];

            //Add to bottom of board.   ...board, 7)
            this.AddSpecialFigures(firstPlayer, board, firstFigures);
            //this.AddPawns(firstPlayer, board, firstFigures);

            //Add to top of board.      ...board, 7)
            this.AddSpecialFigures(secondPlayer, board, secondFigures);
            //this.AddSpecialFigures(secondPlayer, board, 0);
            //this.AddPawns(secondPlayer, board, secondFigures);
        }

        //Adds figures that aren't pawns.       ...board, int row)
        private void AddSpecialFigures(IPlayer player, IChessboard board, FigureStarts[] figures)
        {
            for (int i = 0; i < figures.Length; i++)
            {
                Console.Write("Arrived figure " + i + ": ");
                if (figures[i].isPawn())
                {
                    //Console.debug... WHY ARE THESE PAWNS NOT WORKING???
                    Console.WriteLine("Position:" + figures[i].getPosition().ToString() + "...");
                    var pawn = new Pawn(player.Color); //This changes the pawn's actual functionality upon initialization.
                    player.AddFigure(pawn);
                    var position = figures[i].getPosition(); //Takes row (side), col (varies by piece).
                    board.AddFigure(pawn, position);
                } else { 
                    var figure = (IFigure)Activator.CreateInstance(figures[i].getType(), player.Color);
                    player.AddFigure(figure); 

                    //Originally, this was: new Position(row, i)
                    var position = figures[i].getPosition(); //Takes row (side), col (varies by piece).
                    board.AddFigure(figure, position);
                }
            }
        }

        //No longer really relevant. Leaving it in here for shame. SHAME.
        private void AddPawns(IPlayer player, IChessboard board, FigureStarts[] figures)
        {
            for (int i = 0; i < 8; i++)
            {
                if (!figures[i].getType().Equals(typeof(Pawn))) continue;
                var pawn = new Pawn(player.Color); //This changes the pawn's actual functionality upon initialization.
                player.AddFigure(pawn);
                var position = figures[i].getPosition(); //Takes row (side), col (varies by piece).
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
