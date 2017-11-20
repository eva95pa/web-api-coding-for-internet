using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class InventoriesRepository:Repository<Inventory>
    {
        public Inventory FindByCharacterId(int characterId)
        {
            var entity = this.Find(c => { return c.CharacterId == characterId; });
            return entity;
        }
    }
}