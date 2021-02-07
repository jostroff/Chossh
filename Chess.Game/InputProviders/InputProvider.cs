namespace Chess.Game.InputProviders
{
    using Chess.Game.InputProviders.Contracts;
    using System;
    using Chess.Game.Players.Contracts;
    using System.Collections.Generic;
    using Chess.Game.Players;
    using Chess.Game.Commons;

    public class InputProvider : IInputProvider
    {
        public IList<IPlayer> GetPlayers(string firstPlayerName, string secondPlayerName)
        {
            var players = new List<IPlayer>();
            var firstPlayer = new Player(firstPlayerName, ChessColor.White);
            var secondPlayer = new Player(secondPlayerName, ChessColor.Black);
            players.Add(firstPlayer);
            players.Add(secondPlayer);
            return players;
        }
    }
}
