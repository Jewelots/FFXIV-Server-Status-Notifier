using System;
using System.Linq;
using System.Collections.Generic;

namespace FFXIVServerStatusNotifier
{
    /// <summary>
    /// A static class to hold unchanging Data Values
    /// </summary>
    static class DataValues
    {
        /// <summary>
        /// Dictionary of human readable string to check delay (in milliseconds)
        /// </summary>
        public static Dictionary<string, int> checkDelayValues = new Dictionary<string, int>()
        {
            {"10 seconds",      10 * 1000},
            {"20 seconds",      20 * 1000},
            {"30 seconds",      30 * 1000},
            {"45 seconds",      30 * 1000},
            {"1 minute",        60 * 1000},
            {"2 minutes",  2  * 60 * 1000},
            {"5 minutes",  5  * 60 * 1000},
            {"10 minutes", 10 * 60 * 1000},
            {"30 minutes", 30 * 60 * 1000},
            {"1 hour",     60 * 60 * 1000}
        };

        /// <summary>
        /// Get a human readable string from a preset check delay
        /// </summary>
        /// <param name="checkDelay">Check delay (in milliseconds)</param>
        /// <returns>String representing check delay</returns>
        public static string GetStringFromCheckDelay(int checkDelay)
        {
            return checkDelayValues.First(x => (x.Value == checkDelay)).Key;
        }

        /// <summary>
        /// List of all server names
        /// </summary>
        public static List<string> serverNameValues = new List<string>()
        {
            "Atomos",
            "Bahamut",
            "Chocobo",
            "Mandragora",
            "Tiamat",
            "Tonberry",
            "Garuda",
            "Ifrit",
            "Ramuh",
            "Titan",
            "Adamantoise",
            "Behemoth",
            "Cactuar",
            "Cerberus",
		    "Coeurl",
		    "Goblin",
		    "Malboro",
		    "Moogle",
		    "Ultros",
		    "Diabolos",
		    "Gilgamesh",
		    "Leviathan",
		    "Midgardsormr",
		    "Odin",
		    "Shiva",
		    "Ridill",
		    "Masamune",
		    "Durandal",
		    "Aegis",
		    "Gungnir",
		    "Sargatanas",
		    "Balmung",
		    "Hyperion",
		    "Excalibur",
		    "Ragnarok",
		    "Alexander",
		    "Anima",
		    "Carbuncle",
		    "Fenrir",
		    "Hades",
		    "Ixion",
		    "Kujata",
		    "Typhon",
		    "Ultima",
		    "Valefor",
		    "Exodus",
		    "Faerie",
		    "Lamia",
		    "Phoenix",
		    "Siren",
		    "Pandaemonium",
		    "Unicorn",
		    "Yojimbo",
		    "Famfrit",
		    "Lich",
		    "Mateus",
		    "Asura",
		    "Belias",
		    "Zeromus",
		    "Brynhildr",
		    "Zalera",
		    "Shinryu",
		    "Jenova",
		    "Zodiark"
        };
    }
}
