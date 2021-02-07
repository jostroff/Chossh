using Chess.Game.Players.Contracts;
using System.Collections.Generic;
using Chess.Game.Players;
using Chess.Game.Commons;

namespace Chess.Game.InputProviders.Contracts
{
    public interface IInputProvider
    {
        IList<IPlayer> GetPlayers(string firstPlayerName, string secondPlayerName);

    }
}
