using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class CharactersRepository:Repository<Character>
    {
        public IEnumerable<Character> FindAllByAccountId(int accountId)
        {
            var entitiesFromDb = this.FindAllBy(c=> { return c.AccountId == accountId; });
            return entitiesFromDb;
        }
    }
}