using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApi.Models
{
    public class Character : DbEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Class { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public int AccountId { get; set; }
    }
}