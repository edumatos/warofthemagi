using PlayerIO.GameLibrary;
using System;
using WotMServer.Data;

namespace WotMServer
{
    [RoomType("WotMLobby")]
    public class WotMLobby : Game<Wizard>
    {
        public override void GameStarted()
        {
            Console.WriteLine("Lobby started");
            base.GameStarted();
        }

        public override void GameClosed()
        {
            Console.WriteLine("Lobby closed");
            base.GameClosed();
        }

        public override void UserJoined(Wizard player)
        {
            Message m = Message.Create("WizardList");

            m.Add(player.Id);

            foreach (Wizard w in Players)
                m.Add(w.Id);

            player.Send(m);

            Message b = Message.Create("WizardJoined");
            b.Add(player.Id);
            Broadcast(b);

            Console.WriteLine("Wizard " + player.Id + " joined the lobby.");

            base.UserJoined(player);
        }

        public override void UserLeft(Wizard player)
        {
            Message m = Message.Create("WizardLeft");
            m.Add(player.Id);
            Broadcast(m);
            Console.WriteLine("Wizard " + player.Id + " left the lobby.");
            base.UserLeft(player);
        }

        public override void GotMessage(Wizard player, Message message)
        {
            if (message.Type == "Text")
            {
                Console.WriteLine(player.ConnectUserId + ": " + message.GetString(0));
                Broadcast("Text", player.ConnectUserId, message.GetString(0));
            }
            base.GotMessage(player, message);
        }
    }
}
