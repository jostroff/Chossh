namespace Chess.Game.GameEngine
{
    using Chess.Game.GameEngine.Contracts;
    using System;
    using Chess.Game.Players.Contracts;
    using System.Collections.Generic;
    using Chess.Game.InputProviders.Contracts;
    using Chess.Game.Chessboard;
    using Chess.Game.Chessboard.Contracts;
    using Chess.Game.Commons;
    using Chess.Game.Controllers.Contracts;
    using Chess.Game.Controllers;
    using System.Linq;
    using Chess.Game.Players;

    public class TwoPlyersEngine : IEngine
    {
        private IList<IPlayer> players;
        private readonly IInputProvider input;
        private readonly IChessboard board;
        private readonly IController controller;

        public IEnumerable<IPlayer> Players { get { return new List<IPlayer>(this.players); } }

        public TwoPlyersEngine(IInputProvider input)
        {
            this.input = input;
            this.board = new Chessboard();
            this.controller = new Controller(this.board);
        }

        public void Initialize(IGameInitializationStrategy strategy, string firstPlayerName, string secontPlayerName)
        {
            this.players = this.input.GetPlayers(firstPlayerName, secontPlayerName);
            strategy.Initialize(players, this.board);
        }

        public IChessboard GetBoard { get { return this.board; } }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void WinningCondition()
        {
            throw new NotImplementedException();
        }

        public void Play(string username, Position from, Position to)
        {
            var player = this.players.FirstOrDefault(p => p.Name == username);
            this.controller.MakeMove(player, from, to);
        }
    }
}
