﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using System.Xml.Serialization;

namespace AdminWarnings
{
    public class WarningsConfig : IRocketPluginConfiguration
    {
        public bool Enabled;
        public bool AnnouceWarningKicksAndBansServerWide;
        public bool AnnouceWarningsServerWide;
        public string MessageColor;
        public int DaysWarningsExpire;
        [XmlArrayItem(ElementName = "WarningPoint")]
        public List<WarningPoint> WarningPoints;
        [XmlArrayItem(ElementName = "PlayerWarning")]
        public List<PlayerWarning> PlayerWarnings;

        public void LoadDefaults()
        {
            Enabled = true;
            MessageColor = "Green";
            DaysWarningsExpire = 7;
            AnnouceWarningKicksAndBansServerWide = true;
            AnnouceWarningsServerWide = false;
            WarningPoints = new List<WarningPoint> {
                new WarningPoint{ WarningsToTrigger = 1, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 3600, ConsoleCommand = "" },
                new WarningPoint{ WarningsToTrigger = 2, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 10800, ConsoleCommand = "" },
                new WarningPoint{ WarningsToTrigger = 3, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 86400, ConsoleCommand = "" },
                new WarningPoint{ WarningsToTrigger = 4, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 172800, ConsoleCommand = "" },
                new WarningPoint{ WarningsToTrigger = 5, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 259200, ConsoleCommand = "" }
                new WarningPoint{ WarningsToTrigger = 6, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 604800, ConsoleCommand = "" }
                new WarningPoint{ WarningsToTrigger = 7, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 9999999999, ConsoleCommand = "" }
            };
            PlayerWarnings = new List<PlayerWarning>();
        }
    }

    public class WarningPoint
    {
        public int WarningsToTrigger;
        public bool KickPlayer;
        public bool BanPlayer;
        public uint BanLengthSeconds;
        public string ConsoleCommand;
    }

    public class PlayerWarning
    {
        [XmlAttribute]
        public string CSteamID;
        [XmlAttribute]
        public int Warnings;
        [XmlAttribute]
        public DateTime DateAdded;
    }

}
