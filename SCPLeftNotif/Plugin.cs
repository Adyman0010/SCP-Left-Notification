using System;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace SCPLeftNotif
{
    public class Plugin : Plugin<Config>
    {
        public override string Author { get; } = "Adyman0010";

        public override string Name { get; } = "SCPLeftNotif";
        
        public override string Prefix => Name;

        public override Version RequiredExiledVersion { get; } = new Version(8, 2, 1, 0);

        public override Version Version { get; } = new Version(1, 0, 1);

        public static Plugin Instance;
        
        public override void OnEnabled()
        {
            Instance = this;

            Exiled.Events.Handlers.Player.Left += OnScpLeft;
            
            base.OnEnabled();
        }
        
        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Left -= OnScpLeft;

            Instance = null;
            
            base.OnDisabled();
        }
        
        public void OnScpLeft(LeftEventArgs ev)
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
                        player.ShowHint(Instance.Config.AdminMessage, 10f);
                        //player.SendConsoleMessage($"Player {ev.Player.DisplayNickname} his/her STEAMID: {ev.Player.UserId} has left as a SCP, his/her role was {ev.Player.Role.Type}", "yellow");
                        player.SendConsoleMessage(Instance.Config.ConsoleMessage.Replace("%name%", ev.Player.DisplayNickname).Replace("%userid%", ev.Player.UserId).Replace("%role%", ev.Player.Role.Type))
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
            }
        }
    }
}