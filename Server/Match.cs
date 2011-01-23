using System;
using PlayerIO.GameLibrary;
using WotMServer.Data;

namespace WotMServer
{
    [RoomType("WotMMatch")]
    public class Match : Game<Wizard>
    {
        #region Properties

        public float WaveTime { get; set; }

        public int Wave { get; set; }

        #endregion

        public override void GameStarted()
        {
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
            player.ViewPlayerId = player.Id;

            base.UserJoined(player);
        }

        public override void UserLeft(Wizard player)
        {
            base.UserLeft(player);
        }

        public override bool AllowUserJoin(Wizard player)
        {
            return base.AllowUserJoin(player);
        }

        void Update()
        {
            const float delta = 20f / 1000;

            //TODO: update wave
            WaveTime -= delta;
            if (Wave == 0)
            {
                bool allready = true;
                foreach (Wizard w in Players)
                    if (w.Ready == false)
                        allready = false;
                if (allready)
                    GotoNextWave();
            }
            if (WaveTime <= 0)
            {
                GotoNextWave();
            }
            else
            {
                //TODO: spawn some units
            }

            //TODO: update player units
            foreach (Wizard w in Players)
                w.Update(delta);

            //TODO: send out gamestate
            foreach (Wizard w in Players)
            {
                Message gamestate = Message.Create("State");
                //TODO: compile data for gamestate
                //
                w.Send(gamestate);
            }
        }

        void GotoNextWave()
        {
            Wave++;
            WaveTime = 30f;
            //TODO: setup some params for neutral units for this wave
        }

        Wizard GetWizardByID(int id)
        {
            Wizard retval = null;
            foreach (Wizard w in Players)
                if (w.Id == id)
                {
                    retval = w;
                    break;
                }
            return retval;
        }
    }
}
