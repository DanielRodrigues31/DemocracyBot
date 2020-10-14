using System;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Numerics;
using DSharpPlus.Interactivity;
using DSharpPlus;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace DemocracyBot
{
   public class Commands
    {
        private List<string> DiscordID = new List<string>();
        public DiscordChannel channel { get; private set; }

        bool QueueOpen { get; set; }

        public async Task Poll()
        {   
            var pollembed = new DiscordEmbedBuilder { Title = "Poll", Description = "" };
            await channel.SendMessageAsync(embed: pollembed);   
        }

      
        [Command("Enter")]
        public async Task Enter (CommandContext ctx) 
        {
            var roles = ctx.Member.Roles.ToString();
            var user = ctx.Member.Username;

            if (roles == "everyone" && QueueOpen == true) //verification 
            {
                DiscordID.Add(user);
            }
            

            
        }

        public async Task Timer() 
        {
            //reads json
            var json = string.Empty;
            using (var Read = File.OpenRead("TokenFile.json"))
            using (var Sort = new StreamReader(Read, new UTF8Encoding(false)))
                json = await Sort.ReadToEndAsync();
            var tokenfile = JsonConvert.DeserializeObject<TokenFile>(json);

            //timer
            TimeSpan endtime = TimeSpan.FromDays(tokenfile.Duration);
            endtime = endtime.Subtract(TimeSpan.FromSeconds(1));

            
            if (endtime == TimeSpan.FromSeconds(0))
            {
                await Poll();
                QueueOpen = true;
            }
        }
    }
}
