using Chess.Game.Commons;
using Chess.Game.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game.Controllers.Contracts
{
    public interface IController
    {
        void MakeMove(IPlayer player, Position from, Position to);
    }
}
