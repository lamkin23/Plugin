﻿using System.Collections.Generic;
using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCPStats
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("The Server ID for your server. You must register your server at https://scpstats.com to obtain this.")]
        public string ServerId { get; set; } = "fill this";
        
        [Description("The Secret for your server. This should be treated like a password. You must register your server at https://scpstats.com to obtain this.")]
        public string Secret { get; set; } = "fill this";

        [Description("Serpant's hand is supported and stats for them will be recorded, even if this is disabled. If you have other plugins that use tutorials, it is recommended that you enable this option.")]
        public bool RecordTutorialStats { get; set; } = false;

        [Description("The role that should be given to nitro boosters. Your server must be linked to your discord server to do this.")]
        public string BoosterRole { get; set; } = "none";

        [Description("The role that should be given to discord members. Your server must be linked to your discord server to do this.")]
        public string DiscordMemberRole { get; set; } = "none";

        [Description("Roles that you want to sync. Adding a role here means that if the person has the role on discord, they will get it in game. If a user has multiple roles that can be synced, the highest role in this list will be chosen. Your server must be linked to your discord server to do this.")]
        public List<string> RoleSync { get; set; } = new List<string>()
        {
            "DiscordRoleID:IngameRoleName"
        };
    }
}