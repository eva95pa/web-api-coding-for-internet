using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApi.Models
{
    public class Inventory : DbEntity
    {
        public int Capacity { set; get; }

        [JsonIgnore]
        [XmlIgnore]
        public int CharacterId { get; set; }
    }
}