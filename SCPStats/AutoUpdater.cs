﻿using System.Net;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Loader;

namespace SCPStats
{
    internal static class AutoUpdater
    {
        private const string Version = "1.2.1-1";

        internal static async Task RunUpdater(int waitTime = 0)
        {
            if (waitTime != 0) await Task.Delay(waitTime);
            
            using (var client = new WebClient())
            {
                var res = await client.DownloadStringTaskAsync("https://scpstats.com/update/version");
                if (res == Version) return;

                var location = SCPStats.Singleton?.GetPath();
                if (location == null)
                {
                    Log.Warn("SCPStats auto updater couldn't determine the plugin path. Make sure your plugin dll is named \"SCPStats.dll\".");
                    return;
                }
                
                var githubVer = await client.DownloadStringTaskAsync("https://scpstats.com/update/github");
                await client.DownloadFileTaskAsync("https://github.com/SCPStats/Plugin/releases/download/"+githubVer.Replace("/", "")+"/SCPStats.dll", location);
                Log.Info("Updated SCPStats. Please restart your server to complete the update.");
            }
        }
    }
}