using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [RoutePrefix("game/v1/accounts")]
    public class AccountsController : ApiController
    {
        [Route("")]
        public IEnumerable<Account> GetAllAccounts()
        {
            return DB.Accounts.FindAll();
        }

        [HttpPost]
        [Route("")]
        public Account AddAccount([FromBody]Account account)
        {
            var entity = DB.Accounts.Add(account);
            return entity;
        }

        [Route("{accountId:int}")]
        public Account GetAccount(int accountId)
        {
            var account = DB.Accounts.Find(accountId);
            return account;
        }

        [HttpPut]
        [Route("{accountId:int}")]
        public Account UpdateAccount(int accountId, [FromBody]Account account)
        {
            account.Id = accountId;
            DB.Accounts.Update(account);

            var updatedAccount = DB.Accounts.Find(accountId);
            return updatedAccount;
        }

        [HttpDelete]
        [Route("{accountId:int}")]
        public void RemoveAccount(int accountId)
        {
            var account = DB.Accounts.Find(accountId);
            DB.Accounts.Delete(account);
        }
    }
}
