using System;
using PlayerIO.GameLibrary;
using WotMServer.Data;
using System.Collections.Generic;

namespace WotMServer
{
    [RoomType("WotMMatch")]
    public class Match : Game<Wizard>
    {
        #region Properties

        public bool GameRunning { get; set; }

        public bool GameOver { get; set; }

        public float GameStateTimer { get; private set; }

        public float SpawnTimer { get; private set; }

        public float WaveTime { get; set; }

        public int Wave { get; set; }

        public SortedList<int, Area> Areas { get; set; }

        #endregion

        public Match()
        {
            Areas = new SortedList<int, Area>();
        }

        public override void GameStarted()
        {
            GameRunning = false;
            GameOver = false;
            Wave = 0;
            WaveTime = 120f;

            AddTimer(Update, 20);
            base.GameStarted();
        }

        public override void GameClosed()
        {
            base.GameClosed();
        }

        public override void UserJoined(Wizard player)
        {
            int maxplayers;
            Areas.Add(player.Id, new Area(player));
            player.ViewPlayerId = player.Id;
            //Parse roomdata
            if (!int.TryParse(RoomData["maxplayers"], out maxplayers))
                maxplayers = 4; //Default
            if (Areas.Count == maxplayers)
                GameRunning = true;
            base.UserJoined(player);
        }

        public override void UserLeft(Wizard player)
        {
            // remove the area belonging to this player
            Areas.Remove(player.Id);

            base.UserLeft(player);
        }

        public override bool AllowUserJoin(Wizard player)
        {
            int maxplayers; //Default

            if (GameRunning)
            {
                player.Send("Started");
                return false;
            }

            //Parse roomdata
            if (!int.TryParse(RoomData["maxplayers"], out maxplayers))
                maxplayers = 4; //Default

            //Check if there's room for this player.
            if (Areas.Count < maxplayers - 1)
                return true;

            player.Send("Full");
            return false;
        }

        public override void GotMessage(Wizard player, Message message)
        {
            switch (message.Type)
            {
                case "MaxPlayers":
                    int mp = message.GetInt(0);
                    if (mp >= 2)
                        RoomData["maxplayers"] = mp.ToString();
                    break;
                case "WizardJoined":
                    Broadcast("WizardJoined", player.Id, message.GetString(0));
                    break;
                case "WizardSurrender":
                    Broadcast("WizardSurrender", player.Id);
                    Areas.Remove(player.Id);
                    CheckForWinner();
                    break;
            }
            base.GotMessage(player, message);
        }

        private void CheckForWinner()
        {
            //TODO: declare winner, end game
            if (Areas.Count == 1)
            {
                Areas.Values[0].Owner.Send("Win");
                GameOver = true;
            }
        }

        void Update()
        {
            const float delta = 20f / 1000;

            if (GameRunning && !GameOver)
            {

                //TODO: update wave
                WaveTime -= delta;
                if (Wave == 0)
                {
                    bool allready = true;
                    foreach (Wizard w in Players)
                        if (w.Ready == false)
                            allready = false;
                    if (allready)
                    {
                        GameRunning = true;
                        GotoNextWave();
                    }
                }
                if (WaveTime <= 0)
                {
                    GotoNextWave();
                }
                else
                {
                    //spawn some units
                    SpawnTimer += delta;
                    if (SpawnTimer >= .25f)
                    {
                        SpawnTimer -= .25f;
                        SpawnNeutrals();
                    }
                }

                //update players
                foreach (Wizard w in Players)
                    w.Update(delta);

                // update units and buildings
                foreach (KeyValuePair<int, Area> a in Areas)
                    a.Value.Update(delta);

                //TODO: send out gamestate
                GameStateTimer += delta;
                if (GameStateTimer >= .1f)
                {
                    GameStateTimer -= .1f;
                    //TODO: compile data for gamestate
                    //foreach (Wizard w in Players)
                    //{
                    //    Message gamestate = Message.Create("State");

                    //    w.Send(gamestate);
                    //}
                }
            }
        }

        private void SpawnNeutrals()
        {
            //TODO: spawn neutrals
        }

        void GotoNextWave()
        {
            Wave++;
            WaveTime = 30f;
            //TODO: setup some params for neutral units for this wave
        }

    }
}
