using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApi.Models
{
    public class Item : DbEntity
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public bool Consumable { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public int CharacterId { get; set; }
    }
}