using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.IO;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.EventHandling;
using DSharpPlus.Interactivity.Extensions;
using DSharpPlus.Interactivity.Enums;

namespace bot
{

    class roller
    {
        public string adminrole { get; set; }
        public string role { get; set; }



    }

    class Program
    {

        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }
        static async Task MainAsync()
        {



            var discord = new DiscordClient(new DiscordConfiguration()
            {
                Token = "",
                TokenType = TokenType.Bot
            });

            Console.WriteLine("Botunuz Aktif");
            Console.WriteLine("sefaadsiz625#3169");



            discord.MessageDeleted += async (s, e) =>
            {



            };




            var commands = discord.UseCommandsNext(new CommandsNextConfiguration()
            {
                StringPrefixes = new[] { "*" }
            });





            commands.RegisterCommands<com>();

                        DiscordActivity activity = new DiscordActivity();




        
            await discord.ConnectAsync();



            await Task.Delay(-1);


        }
    }
}

