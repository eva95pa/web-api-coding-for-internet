using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class AchievementsRepository:Repository<Achievements>
    {
        public IEnumerable<Achievements> FindAllByCharacterId(int characterId)
        {
            var entitiesFromDb = this.FindAllBy(c => { return c.CharacterId == characterId; });
            return entitiesFromDb;
        }
    }
}