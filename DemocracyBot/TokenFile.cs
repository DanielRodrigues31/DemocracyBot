using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DemocracyBot
{
    public class TokenFile
    {
        [JsonProperty("Token")]
        public string Token { get; private set; }

        [JsonProperty("Prefix")]
        public string Prefix { get; private set; }

        [JsonProperty("Moderators")]
        public string Moderators { get; private set; }

        [JsonProperty("Admins")]
        public string Admins { get; private set; }

        

        

        
    }
}
