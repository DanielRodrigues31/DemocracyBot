using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemocracyBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextModule Commands { get; private set; }

        public async Task Run() 
            
        {
            var json = string.Empty;

            //reads json
            using (var Read = File.OpenRead("TokenFile.json"))
            using (var Sort = new StreamReader(Read, new UTF8Encoding(false)))
                json = await Sort.ReadToEndAsync();
            var tokenfile = JsonConvert.DeserializeObject<TokenFile>(json);

            
            var discordConfig = new DiscordConfiguration
            {
                Token = tokenfile.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };

            var commandConfig = new CommandsNextConfiguration
            {
                StringPrefix = new string (tokenfile.Prefix), 
                EnableDms = false,
                EnableMentionPrefix = true
            };

            Client = new DiscordClient(discordConfig);
            Commands = Client.UseCommandsNext(commandConfig);
            Client.Ready += OnClientReady;


            //connects to gateway
            await Client.ConnectAsync();

            //prevents bot from closing before program finishes
            await Task.Delay(-1);
            
            
        }

        private Task OnClientReady(ReadyEventArgs e) 
        {
            return Task.CompletedTask;
        }
    }
}
