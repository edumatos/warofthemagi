using System;
using PlayerIO.DevelopmentServer;

namespace DebugServer
{
    public static class DebugServer
    {
        [STAThread]
        static void Main()
        {
            Server.StartWithDebugging();
        }
    }
}
