using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebApi.Models
{
    public class Subscription:DbEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Days { get; set; }
        public bool IsTrial { get; set; }

        [JsonIgnore]
        [XmlIgnore]
        public int AccountId { get; set; }

    }
}