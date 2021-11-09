using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace JokeGenerator
{
   public class Joke
    {

        [JsonProperty("icon_url")]
        public string IconUrl { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
