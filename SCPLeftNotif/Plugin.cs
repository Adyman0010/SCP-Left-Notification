using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;
using SCPLeftNotif.Utils;
using Newtonsoft.Json;

namespace SCPLeftNotif
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Adyman0010";

        public override string Name { get; } = "SCPLeftNotif";

        public override string Prefix => Name;

        public override Version RequiredExiledVersion { get; } = new Version(8, 8, 0);

        public override Version Version { get; } = new Version(2, 0, 0);

        private static Plugin _instance;

        public override void OnEnabled()
        {
            _instance = this;

            Exiled.Events.Handlers.Player.Left += OnScpLeft;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Left -= OnScpLeft;

            _instance = null;

            base.OnDisabled();
        }

        private void OnScpLeft(LeftEventArgs ev)
        {
            if (ev.Player.IsScp)
            {
                bool isReplaced = false;
                foreach (Player player in Player.List)
                {
                    if (!isReplaced && player.Role.Type == RoleTypeId.Spectator)
                    {
                        player.Role.Set(ev.Player.Role);
                        isReplaced = true;
                    }

                    if (player.RemoteAdminAccess)
                    {
                        player.ShowHint(_instance.Config.AdminMessage, 10f);
                        player.SendConsoleMessage(_instance.Config.ConsoleMessage
                            .Replace("%name%", ev.Player.DisplayNickname).Replace("%userid%", ev.Player.UserId)
                            .Replace("%role%", ev.Player.Role.Type.ToString()), "yellow");
                        Log.Debug("SCP Left the server! A message was sent to all available staff");
                    }
                }

                foreach (Player player2 in Player.List)
                {
                    if (player2.Role.Type == RoleTypeId.Spectator)
                    {
                        player2.Role.Set(ev.Player.Role);
                    }

                    break;
                }

                if (_instance.Config.UseWebHook)
                {
                    WebHook scpLeft = new()
                {
                    embeds = new List<Embed>()
                    {
                        new Embed()
                        {
                            title = "SCP Left Notification",
                            color = 15844367,

                            author = new Dictionary<string, string>()
                            {
                                {"name", "Made by: Adyman0010"},
                                {"url", ""},
                                {"icon_url", "https://media.discordapp.net/attachments/1108469686976397485/1225778062440792105/fd2479934813a7a80de5b77f30a9a820.png?ex=66225dc7&is=660fe8c7&hm=89bf76f8a94362a21dce428d3bab57566293eb2f8c93bcfa78c142046020083b&=&format=webp&quality=lossless&width=384&height=384"}
                            },
                            
                            thumbnail = new Dictionary<string, string>()
                            {
                                {
                                    "url",
                                    "https://cdn.discordapp.com/attachments/1108469686976397485/1225761275884208180/istockphoto-1096929156-612x612-removebg-preview.png?ex=66224e25&is=660fd925&hm=573cbd51ca37322449921347287ea984edcd6aa5a5b4535a2c9ba9fc92b879ca&"
                                }
                            },

                            fields = new List<Field>()
                            {
                                new Field()
                                {
                                    name = "Player's Nickname",
                                    value = ev.Player.Nickname,
                                    inline = false
                                },
                                new Field()
                                {
                                    name = "Player's Role",
                                    value = ev.Player.Role.Type.ToString(),
                                    inline = false
                                },
                                new Field()
                                {
                                    name = "Player's Steam ID:",
                                    value = ev.Player.UserId,
                                    inline = false
                                },
                            }
                        }
                    }
                };

                var json = JsonConvert.SerializeObject(scpLeft, Formatting.Indented);
                var wr = WebRequest.Create(_instance.Config.WebHook);
                wr.ContentType = "application/json";
                wr.Method = "POST";
                using (var sw = new StreamWriter(wr.GetRequestStream()))
                    sw.Write(json);
                wr.GetResponse();
                }
            }
        }
    }
}