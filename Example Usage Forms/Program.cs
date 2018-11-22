using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example_Usage_Forms {
    static public class MainGlabals {
        /// <summary>
        /// SteamID2 Regex
        /// </summary>
        public const string Steam2Regex = "^STEAM_0:[0-1]:([0-9]{1,10})$";
        /// <summary>
        /// SteamID32 Regex
        /// </summary>
        public const string Steam32Regex = "^U:1:([0-9]{1,10})$";
        /// <summary>
        /// SteamID64 Regex
        /// </summary>
        public const string Steam64Regex = "^7656119([0-9]{10})$";
        /// <summary>
        /// SteamID2 global
        /// </summary>
        public static string g_sSteamID2 = "STEAM_0:1:27046640";
        /// <summary>
        /// SteamID32 global
        /// </summary>
        public static string g_sSteamID32 = "[U:1:54093281]";
        /// <summary>
        /// SteamId 64 global
        /// </summary>
        public static string g_sSteamID64 = "76561198014359009";
        /// <summary>
        /// Text to be drawn on screen.
        /// </summary>
        public static string InfoText = "INFO";
    }
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
