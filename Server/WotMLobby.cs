using PlayerIO.GameLibrary;
using System;
using WotMServer.Data;
using System.Collections.Generic;

namespace WotMServer
{
    [RoomType("WotMLobby")]
    public class WotMLobby : Game<Wizard>
    {

        SortedList<int, string> Names { get; set; }

        public WotMLobby()
        {
            Names = new SortedList<int, string>();
        }

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

            foreach (KeyValuePair<int, string> pair in Names)
            {
                m.Add(pair.Key);
                m.Add(pair.Value);
            }

            player.Send(m);

            Console.WriteLine("Wizard " + player.Id + " has joined the lobby.");

            base.UserJoined(player);
        }

        public override void UserLeft(Wizard player)
        {
            Broadcast("WizardLeft", player.Id);
            Console.WriteLine("Wizard " + Names[player.Id] + " (" + player.Id + ") left the lobby.");
            Names.Remove(player.Id);
            base.UserLeft(player);
        }

        public override void GotMessage(Wizard player, Message message)
        {
            switch (message.Type)
            {
                case "WizardText":
                    Console.WriteLine(Names[player.Id] + ": " + message.GetString(0));
                    Broadcast("WizardText", player.Id, message.GetString(0));
                    break;
                case "WizardJoined":
                    Names.Add(player.Id, message.GetString(0));
                    Console.WriteLine("Wizard " + player.Id + " introduced himself as " + Names[player.Id] + ".");
                    Broadcast("WizardJoined", player.Id, Names[player.Id]);
                    break;
            }
                    
            base.GotMessage(player, message);
        }
    }
}
