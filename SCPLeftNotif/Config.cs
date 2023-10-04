using System.ComponentModel;
using Exiled.API.Interfaces;

namespace SCPLeftNotif
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;
        
        [Description("What message should brodcast to admins, when SCP leaves")]
        public string AdminMessage { get; set; } = "A Player left as a SCP! Check your console by pressing ;";
        [Description("The message to send in the console")]
        public string ConsoleMessage { get; set; } = "Player %name% left! ID: %userid%, ROLE: %role%";
    }
}