using System.Collections.Generic;

namespace SCPLeftNotif.Utils
{
    internal class WebHook
    {
        public List<Embed> embeds { get; set; }
    }

    internal class Embed
    {
        public string title { get; set; }
        
        public int color { get; set; }
        
        public Dictionary<string, string> author { get; set; }
        
        public Dictionary<string, string> thumbnail { get; set; }
        
        public List<Field> fields { get; set; }
    }

    internal class Field
    {
        public string name { get; set; }
        
        public string value { get; set; }
        
        public bool inline { get; set; }    
    }
}