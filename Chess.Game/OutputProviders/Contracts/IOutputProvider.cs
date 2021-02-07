using Chess.Game.Figures.Contracts;
using Chess.Game.GameEngine.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Game.OutputProviders.Contracts
{
    public interface IOutputProvider
    {
        IFigure[,] GetBoardToRender(IEngine engine);
    }
}
