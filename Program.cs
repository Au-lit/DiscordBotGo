using System;
using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DiscordBotGo
{
    class Program {
        static DiscordClient discord;
        static CommandsNextModule commands;
        public class Commands {
            [Command("alive")]
            public async Task Allo(CommandContext ctx) {
                await ctx.RespondAsync("En vie.");
                await ctx.RespondAsync("Alive");
                await ctx.RespondAsync("私は日本語話せません。");
            }
        }
        
        static void Main(string[] args) {
            MainAsync(args).ConfigureAwait(false).GetAwaiter().GetResult();
        }
        static async Task MainAsync(string[] args) {
            discord = new DiscordClient(new DiscordConfiguration{
                Token = "NzcyMjY0MTgzNjA1NjI0ODgy.X54JEQ.fl4ZKv6mp-v87la4ZQ9qO6dIdU4",
                TokenType = TokenType.Bot,
                UseInternalLogHandler = true,
                LogLevel = LogLevel.Debug
            });
            commands = discord.UseCommandsNext(new CommandsNextConfiguration{StringPrefix = "go "});
            commands.RegisterCommands<Commands>();
            //discord.MessageCreated += async e =>
            //{
            //    if (e.Message.Content.ToLower().StartsWith("ping"))
            //        await e.Message.RespondAsync("pong!");
            //};
            await discord.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
