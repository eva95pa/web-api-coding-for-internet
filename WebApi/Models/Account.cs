using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Account : DbEntity
    {
        public string Nickname { get; set; }
        public List<string> Roles { get; set; }
    }
}