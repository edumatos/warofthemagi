using PlayerIO.GameLibrary;
using System;
using WotMServer.Data;

namespace WotMServer
{
    [RoomType("WotMLobby")]
    class WotMLobby : Game<Wizard>
    {
        public override void GameStarted()
        {
            Console.Write("Lobby started");
            base.GameStarted();
        }

        public override void GameClosed()
        {
            Console.Write("Lobby closed");
            base.GameClosed();
        }
    }
}
