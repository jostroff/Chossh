using Chess.Game.Chessboard.Contracts;
using Chess.Game.Players;
using Chess.Game.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chess.Game.Commons;

namespace Chess.Game.GameEngine.Contracts
{
    public interface IEngine
    {
        IEnumerable<IPlayer> Players { get; }

        IChessboard GetBoard { get; }

        void Initialize(IGameInitializationStrategy strategy, string firstPlayerName, string secontPlayerName);

        void Start();

        void WinningCondition();
        void Play(string username, Position from, Position to);
    }
}
