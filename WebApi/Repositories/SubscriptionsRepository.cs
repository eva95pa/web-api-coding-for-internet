using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Models;

namespace WebApi.Repositories
{
    public class SubscriptionsRepository : Repository<Subscription>
    {
        public IEnumerable<Subscription> FindAllByAccountId(int accountId)
        {
            var entitiesFromDb = this.FindAllBy(c => { return c.AccountId == accountId; });
            return entitiesFromDb;
        }


    }
}