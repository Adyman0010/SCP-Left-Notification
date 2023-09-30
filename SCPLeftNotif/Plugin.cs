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

        public static Plugin Instance;
        
        public override void OnEnabled()
        {
            Instance = this;

            Exiled.Events.Handlers.Player.Left += OnScpLeft;
            
            base.OnEnabled();
        }
        
        public override void OnDisabled()
        {
            Instance = null;

            Exiled.Events.Handlers.Player.Left -= OnScpLeft;
            
            base.OnDisabled();
        }
        
        public void OnScpLeft(LeftEventArgs ev)
        {
            if (ev.Player.IsScp)
            {
                foreach (Player player in Player.List)
                {
                    if (player.RemoteAdminAccess)
                    {
                        player.ShowHint(Instance.Config.AdminMessage, 10f);
                        player.SendConsoleMessage($"Player {ev.Player.DisplayNickname} his/her STEAMID: {ev.Player.UserId} has left as a SCP, his/her role was {ev.Player.Role.Type}", "yellow");
                        Log.Info("SCP Left the server! A message was sent to all available staff");
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