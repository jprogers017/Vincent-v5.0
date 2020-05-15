using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Interactivity;
using System.Threading.Tasks;

namespace Vincent.Commands
{
    public class BasicCommands : BaseCommandModule
    {
        [Command("hello")]
        [Description("Hello!!!")]
        [RequireRoles(RoleCheckMode.None)]
        public async Task Hello(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync($"Hello, {ctx.User.Username}, I'm Vincent!").ConfigureAwait(false);
        }


        [Command("respondmessage")]
        [Description("")]
        [RequireRoles(RoleCheckMode.All, "owner")]
        public async Task RespondMessage(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var msg = await interactivity.WaitForMessageAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(msg.Result.Content);
        }

        [Command("respondreaction")]
        [Description("")]
        [RequireRoles(RoleCheckMode.All, "owner")]
        public async Task RespondReaction(CommandContext ctx)
        {
            var interactivity = ctx.Client.GetInteractivity();

            var msg = await interactivity.WaitForReactionAsync(x => x.Channel == ctx.Channel).ConfigureAwait(false);

            await ctx.Channel.SendMessageAsync(msg.Result.Emoji);
        }
    }
}
