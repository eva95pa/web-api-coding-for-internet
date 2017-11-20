using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    abstract public class DbEntity
    {
        public int Id { get; set; }
    }
}