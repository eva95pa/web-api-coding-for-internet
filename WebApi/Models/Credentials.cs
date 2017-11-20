using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Credentials:DbEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}