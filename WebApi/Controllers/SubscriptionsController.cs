using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [RoutePrefix("game/v1/accounts/{accountId:int}/subscriptions/")]
    public class SubscriptionsController : ApiController
    {
        [Route("")]
        public IEnumerable<Subscription> GetAllSubscription()
        {
            return DB.Subscription.FindAll();
        }

        [HttpPost]
        [Route("")]
        public Subscription AddSubscription(int accountId,[FromBody]Subscription subscription)
        {
            subscription.AccountId = accountId;

            var entity = DB.Subscription.Add(subscription);
            return entity;
        }

        [HttpPut]
        [Route("{accountId:int}")]
        public Subscription UpdateSubscription(int subscriptionID, [FromBody]Subscription subscription)
        {
            subscription.Id = subscriptionID;
            DB.Subscription.Update(subscription);

            var updateSubscription = DB.Subscription.Find(subscriptionID);
            return updateSubscription;
        }

        [HttpDelete]
        [Route("{accountId:int}")]
        public void RemoveSubscription(int subscriptionID)
        {
            var subscription = DB.Subscription.Find(subscriptionID);
            DB.Subscription.Delete(subscription);
        }
    }
}
