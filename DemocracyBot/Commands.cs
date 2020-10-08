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

namespace DemocracyBot
{
    public class MyCommands
    {
        private List<string> DiscordID = new List<string>();
        

        private bool embedstatus;


        [Command("Enter")]
        public async Task Enter (CommandContext ctx) 
        {
            var roles = ctx.Member.Roles.ToString();
            var user = ctx.Member.Username;

            for (int i = 0; i < roles.Length; i++) 
            {
                if (roles == "" && embedstatus == true) 
                {
                    DiscordID.Add(user);
                }
            }

            
        }

        [Command("poll")]
        public async Task Poll (CommandContext ctx) 
        {
            
            var pollembed = new DiscordEmbedBuilder { Title = "Poll", Description = "Modpoll"};
            await ctx.Channel.SendMessageAsync(embed: pollembed);
            

            //timer create embed, expirery timer, vector for user id's
        }

        

        
    }
}
