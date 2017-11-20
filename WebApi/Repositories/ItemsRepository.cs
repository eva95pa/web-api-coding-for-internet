using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class ItemsRepository : Repository<Item>
    {
        public IEnumerable<Item> FindAllByCharacterId(int characterId)
        {
            var entitiesFromDb = this.FindAllBy(c => { return c.CharacterId == characterId; });
            return entitiesFromDb;
        }

        public void UpdateInventory(int characterId, List<Item> items)
        {
            foreach (var item in FindAllByCharacterId(characterId))
                Delete(item);

            foreach (var item in items)
            {
                item.CharacterId = characterId;
                Add(item);
            }
        }
    }
}