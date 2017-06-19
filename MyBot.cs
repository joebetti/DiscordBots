using Discord;
using Discord.Commands;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordBot1
{
	class MyBot
	{
		DiscordClient discord;

		public MyBot()
		{
			discord = new DiscordClient(x =>
			{
				x.LogLevel = LogSeverity.Info;
				x.LogHandler = Log;
			});

			discord.UsingCommands(x =>
			{
				x.PrefixChar = '!';
				x.AllowMentionPrefix = true;
			});

			var commands = discord.GetService<CommandService>();
			commands.CreateCommand("hello")
				.Do(async (e) =>
				{
					await e.Channel.SendMessage("My Name is Jeff.");
				});

			discord.ExecuteAndWait(async () =>
			{
				await discord.Connect("MzI1ODA1NTEzNzc2NDMxMTA0.DChi3A.ddDWF0WXav16hs6USuGacTSpbuc",TokenType.Bot);
			});
		}

		private void Log(object sender, LogMessageEventArgs e)
		{
			Console.WriteLine(e.Message);
		}
	}
}
