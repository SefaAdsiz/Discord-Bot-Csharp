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
using DSharpPlus.EventArgs;





namespace bot
{

    public abstract class SnowflakeObject
    {
        public DateTimeOffset CreationTimestamp { get; }
        public ulong Id { get; }

    }



    public class com : BaseCommandModule
    {

        [Command("avatar")]
        [Description("Kullanıcıyı atar")]
        public async Task GreetCommand(CommandContext ctx, DiscordMember kisi)
        {

            await ctx.RespondAsync(kisi.AvatarUrl);

        }

        [Command("kick")]
        public async Task Kick(CommandContext ctx, DiscordMember kisi)
        {
            await ctx.RespondAsync($"<@{kisi.Id}> atıldı");
            await kisi.RemoveAsync();
        }

        [Command("kick")]
        public async Task Kicksebepli(CommandContext ctx, DiscordMember kisi, [RemainingText] string sebep)
        {

            await kisi.RemoveAsync();
            await ctx.RespondAsync($"{kisi.Id} idli kişi atıldı sebeb : {sebep}");
        }

        [Command("ban")]
        public async Task Ban(CommandContext ctx, DiscordMember kisi)
        {
            if (kisi.Id == 736644977362337853)
            {
                await ctx.Channel.SendMessageAsync("sen kimsin bunu banlıyon turşi\nhttps://www.youtube.com/watch?v=GHr_6Tmb9R4");

            }
            else
            {

                string url = kisi.AvatarUrl;

                await kisi.BanAsync();
                var embed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Red,
                    ImageUrl = url,
                    Description = $"<@{kisi.Id}> idli kişi uçuruldu"
                };
                await ctx.RespondAsync(embed);

            }


        }





        [Command("ban")]
        public async Task sebepBan(CommandContext ctx, DiscordMember kisi, [RemainingText] string sebep)
        {
            if (kisi.Id == 736644977362337853)
            {
                await ctx.Channel.SendMessageAsync("sen kimsin bunu banlıyon turşi\nhttps://www.youtube.com/watch?v=GHr_6Tmb9R4");

            }
            else
            {

                string url = kisi.AvatarUrl;

                var embed = new DiscordEmbedBuilder()
                {
                    Color = DiscordColor.Red,
                    ImageUrl = url,
                    Description = $"<@{kisi.Id}>Banlandı sebep : {sebep}"
                };
                await ctx.RespondAsync(embed);
                await kisi.BanAsync();


            }


        }







        [Command("unban")]
        public async Task unban(CommandContext ctx, DiscordUser user)
        {

            var embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Red,
                Description = $"{user} idli kişinin banı açıldı"
            };
            Console.WriteLine(ctx.Guild.Id);
            await ctx.Guild.UnbanMemberAsync(user);
            await ctx.RespondAsync(embed);

        }

        [Command("yardim")]
        public async Task yardim(CommandContext ctx)
        {

            var embed = new DiscordEmbedBuilder()
            {
                Color = DiscordColor.Blue,
                Description = "1- !avatar @'isim' ile kullanıcının profil fotoğrafına ulaşabilirsiniz\nDahası eklenicektir beklemede kalın"
            };


            await ctx.RespondAsync(embed);

        }

        [Command("sil")]
        public async Task sil(CommandContext ctx, int veri)
        {
  

             if (veri > 100)
            {
                await ctx.Channel.SendMessageAsync("tek seferden en fazla 100 tane mesaj silebilirsin");

            }
            else
            {

                var sess = await ctx.Channel.GetMessagesAsync(veri);
                await ctx.Channel.DeleteMessagesAsync(sess);

            }



        }




        [Command("sil")]
        public async Task silbilgi(CommandContext ctx)
        {
 
                await ctx.Channel.SendMessageAsync("sil 'adet' örnek kullanım sil 60 tek seferden unutma en fazla 100 tane mesaj silebilirsin ");


        }
        [Command("spam")]
        private async Task setasctivity(CommandContext ctx)
        {
            for (int i = 0; i < 100; i++)
            {
                await ctx.Channel.SendMessageAsync("sadas");
                System.Threading.Thread.Sleep(10);
            }
        }




        [Hidden]
        [Command("aciklama")]
        private async Task setactivity(CommandContext ctx)
        {

            DiscordActivity activity = new DiscordActivity();
            DiscordClient discord = ctx.Client;
            Console.Write("Botunuzun açıklamasını giriniz : ");
            string input = Console.ReadLine();
            activity.Name = input;
            await discord.UpdateStatusAsync(activity);

        }

        [Command("unmute")]
        public async Task unmuteCommand(CommandContext ctx, DiscordMember kisi)

        {

            var zamans = DateTime.Now.AddSeconds(0);

            var embed = new DiscordEmbedBuilder()
            {
                Description = $"<@{kisi.Id}> || <@{ctx.Member.Id}> tarafından {zamans.ToString()} tarihine kadar susturuldu"
            };

            Console.WriteLine(zamans);
            await ctx.RespondAsync(embed);
            await kisi.TimeoutAsync(zamans);

        }

        [Command("mute")]
        public async Task bilgimute (CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("mute '@isim süre saniye & dakika & saat şeklinde' kullanılır");
        }
        [Command("ban")]
        public async Task bilgiban(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("ban '@isim sebep' şeklinde kullanılır");
        }

        [Command("kick")]

        public async Task bilgikick(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("kick '@isim sebep' şeklinde kullanılır");
        }


        [Command("mute")]
        public async Task muteCommand(CommandContext ctx, DiscordMember kisi, int zaman, string zamanturu)

        {

            var zamans = DateTime.Now.AddSeconds(zaman);
            var zamansdakika = DateTime.Now.AddMinutes(zaman);
            var zamanssaat = DateTime.Now.AddHours(zaman);



            if (zamanturu.Equals("saniye"))
            {

                await kisi.TimeoutAsync(zamans);
                await ctx.RespondAsync($"<@{kisi.Id}> || <@{ctx.Member.Id}> tarafından {zamans.ToString()} tarihine kadar susturuldu");

            }
            else if (zamanturu.Equals("dakika"))
            {

                await kisi.TimeoutAsync(zamansdakika);
                await ctx.RespondAsync($"<@{kisi.Id}> || <@{ctx.Member.Id}> tarafından {zamansdakika.ToString()} tarihine kadar susturuldu");


            }

            else if (zamanturu.Equals("saat"))
            {
                await kisi.TimeoutAsync(zamanssaat);
                await ctx.RespondAsync($"<@{kisi.Id}> || <@{ctx.Member.Id}> tarafından {zamanssaat.ToString()} tarihine kadar susturuldu");


            }


            Console.WriteLine(zamans);
        }


        [Hidden]
        [Command("dm")]
        private async Task dmgonder(CommandContext ctx,DiscordMember kisi, [RemainingText]string gonder)
        {
            await kisi.SendMessageAsync(gonder);
  
        }









    }
}
