using System;

namespace Vincent
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.RynAsync().GetAwaiter().GetResult();
        }
    }
}
