using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Linq;
using System.Security.Cryptography;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using commands;

namespace DiscordBotGo
{
    class Program {
        static DiscordClient discord;
        static CommandsNextModule commands;
        static string inputToken;
        static void Main(string[] args) {
            Console.WriteLine("Please enter your token.");
            inputToken = Console.ReadLine();
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args) {
            discord = new DiscordClient(new DiscordConfiguration{
                Token = inputToken,
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });
            commands = discord.UseCommandsNext(new CommandsNextConfiguration{StringPrefix = "go "});
            commands.RegisterCommands<commands.Commands>();
            discord.UseInteractivity(new InteractivityConfiguration {
                // default pagination behaviour to just ignore the reactions
                PaginationBehaviour = TimeoutBehaviour.Ignore,

                // default pagination timeout to 5 minutes
                PaginationTimeout = TimeSpan.FromMinutes(5),

                // default timeout for other actions to 2 minutes
                Timeout = TimeSpan.FromMinutes(2)
            });

            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
