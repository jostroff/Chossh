namespace Chess.Models.HubModels
{
    using Chess.Game.GameEngine.Contracts;
    using System;
    using System.Collections.Generic;
    using Chess.Game.Commons;
    using System.Linq;
    using Chess.Game.Figures.Contracts;

    public class GameHub
    {
        public string NextPlayerId;

        public GameHub(IList<UserHub> players, IEngine engine)
        {
            this.Players = players;
            this.GameId = Guid.NewGuid();
            this.GameEngine = engine;
            NextPlayerId = Players[0].ConnectionId;
        }

        public Guid GameId { get; set; }

        public IEngine GameEngine { get; set; }

        public IList<UserHub> Players { get; set; }

        public void MakeMove(string connectionId, Position from, Position to)
        {
            if (connectionId == NextPlayerId)
            {
                var currentPlayer = Players.FirstOrDefault(x => x.ConnectionId == connectionId);

                GameEngine.Play(currentPlayer.Username, from, to);

                NextPlayerId = this.Players.FirstOrDefault(x => x.ConnectionId != connectionId).ConnectionId;
            }
        }

        public IFigure[,] GetBoard()
        {
            return this.GameEngine.GetBoard.GetBoard;
        }
    }
}
