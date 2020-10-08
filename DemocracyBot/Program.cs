using System;


namespace DemocracyBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.Run().GetAwaiter().GetResult();
            
        }
    }
}
