using System.ComponentModel;
using System.Security.Cryptography;
using Exiled.API.Interfaces;

namespace SCPLeftNotif
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        public bool Debug { get; set; } = false;
        
        [Description("What message should brodcast to admins, when SCP leaves")]
        public string AdminMessage { get; set; } = "A Player left as a SCP! Check your console by pressing ;";
        
        [Description("The message to send in the console (DO NOT delete any of the %% otherwise it will result in plugin not working properly)")]
        public string ConsoleMessage { get; set; } = "Player %name% left! ID: %userid%, ROLE: %role%";

        [Description("True/False If you want to use Discord Webhook (default: true)")]
        public bool UseWebHook { get; set; } = true;

        [Description("In the '' you will insert a Discord WebHook (If you want to use this featuer ofcourse) ")]
        public string WebHook { get; set; } = string.Empty;
        
    }
}