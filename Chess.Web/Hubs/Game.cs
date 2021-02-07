using Chess.Game.Figures.Abstracts;
using Chess.Game.Figures.Contracts;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Chess.Models.HubModels;
using Chess.Game.GameEngine.Contracts;
using Chess.Game.GameEngine;
using Chess.Game.InputProviders.Contracts;
using Chess.Game.InputProviders;
using Chess.Game.GameEngine.Initializators;
using Chess.Game.OutputProviders.Contracts;
using Chess.Game.OutputProviders;
using Newtonsoft.Json;
using Chess.Game.Commons;

namespace Chess.Web.Hubs
{
    public class Game : Hub
    {
        public static List<UserHub> Users = new List<UserHub>();
        public static List<GameHub> Games = new List<GameHub>();

        public void Invite(string username)
        {
            var host = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            var joinUsers = Users.Where(x => x.Username == username).ToList();
            joinUsers.ToList().ForEach(x =>
            {
                Clients.Client(x.ConnectionId).recieveInvitation(host);
            });
        }

        public void SendConfirmation(string hostId)
        {
            var host = Users.FirstOrDefault(x => x.ConnectionId == hostId);
            var guest = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            Clients.Client(host.ConnectionId).recieveConfirmation(guest);

            this.StartGame(host, guest);
        }

        private void StartGame(UserHub host, UserHub guest)
        {
            IInputProvider inputProvider = new InputProvider();
            IEngine engine = new TwoPlyersEngine(inputProvider);
            IGameInitializationStrategy strategy = new TwoPlayersInitializationStrategy();
            engine.Initialize(strategy, host.Username, guest.Username);
            IOutputProvider outputProvider = new WebOutputProvider();

            Guid gameId = Guid.NewGuid();
            var players = new List<UserHub>() { host, guest };
            var game = new GameHub(players, engine);

            Games.Add(game);

            var board = outputProvider.GetBoardToRender(engine);
            var nextPlayerName = players.FirstOrDefault(p => p.ConnectionId == game.NextPlayerId).Username;
            Clients.Client(host.ConnectionId).startGame(board);
            Clients.Client(guest.ConnectionId).startGame(board);
            Clients.Client(host.ConnectionId).recieveMessage($"Next player: {nextPlayerName}", "Judge");
            Clients.Client(guest.ConnectionId).recieveMessage($"Next player: {nextPlayerName}", "Judge");

        }

        public void MakeMove(Position from, Position to)
        {
            var game = Games.FirstOrDefault(x => x.Players.Any(p => p.ConnectionId == Context.ConnectionId));
            try
            {
                game.MakeMove(Context.ConnectionId, from, to);
                var nextPlayer = game.Players.FirstOrDefault(p => p.ConnectionId == game.NextPlayerId);

                var board = game.GetBoard();
                Clients.Client(Context.ConnectionId).drawBoard(board);
                Clients.Client(nextPlayer.ConnectionId).drawBoard(board);
                Clients.Client(Context.ConnectionId).recieveMessage($"Next player: {nextPlayer.Username}", "Judge");
                Clients.Client(nextPlayer.ConnectionId).recieveMessage($"Next player: {nextPlayer.Username}", "Judge");
            }
            catch (Exception ex)
            {
                Clients.Client(Context.ConnectionId).recieveMessage(ex.Message, "Judge");
            }


        }

        public void SendMessageToOponent(string message, string oponentConnectionId)
        {
            var username = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId).Username;
            Clients.Client(oponentConnectionId).recieveMessage(message, username);
        }

        public override Task OnConnected()
        {
            var username = Context.User.Identity.Name;
            Clients.Client(Context.ConnectionId).getMyUsername(username);

            var user = new UserHub
            {
                Username = Context.User.Identity.Name,
                ConnectionId = Context.ConnectionId
            };

            Users.Add(user);
            Clients.All.listUsers(Users.Select(x => x.Username).Distinct());
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            var userToRemove = Users.FirstOrDefault(u => u.ConnectionId == Context.ConnectionId);
            Users.Remove(userToRemove);
            Clients.All.listUsers(Users.Select(x => x.Username).Distinct());
            return base.OnDisconnected(stopCalled);
        }
    }
}