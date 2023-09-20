using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCPLeftNotif
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;

        [Description("Is ScpLeftNotif enabled (default = true)")]
        public bool IsScpLeftNotifEnabled { get; set; } = true;

        [Description("What message should brodcast to admins, when SCP leaves")]
        public string AdminMessage { get; set; } = "A Player left as a SCP! Check your console by pressing ;";
    }
}