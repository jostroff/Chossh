namespace Chess.Game.OutputProviders
{
    using Chess.Game.OutputProviders.Contracts;
    using System;
    using Chess.Game.Figures.Contracts;
    using Chess.Game.GameEngine.Contracts;

    public class WebOutputProvider : IOutputProvider
    {
        public IFigure[,] GetBoardToRender(IEngine engine)
        {
            var board = engine.GetBoard;
            var boardToRender = board.GetBoard;

            return boardToRender;
        }
    }
}
