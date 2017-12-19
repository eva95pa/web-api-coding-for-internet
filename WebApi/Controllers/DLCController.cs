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
    [RoutePrefix("game/v1/accounts/{accountId:int}/DLC")]
    public class DLCController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<DLC> GetAllDLC(int accountId)
        {
            return DB.DLC.FindAllByAccountId(accountId);
        }

        [HttpPost]
        [Route("")]
        public DLC AddDLC(int accountId, [FromBody]DLC dlc)
        {
            dlc.AccountId = accountId;

            var entity = DB.DLC.Add(dlc);
            return entity;
        }

        [HttpPut]
        [Route("{dlcID:int}")]
        public DLC UpdateDLC(int dlcID, int accountId, [FromBody]DLC dlc)
        {
            dlc.Id = dlcID;
            dlc.AccountId = accountId;
            DB.DLC.Update(dlc);

            var updateDLC = DB.DLC.Find(dlcID);
            return updateDLC;
        }

        [HttpDelete]
        [Route("{dlcID:int}")]
        public void RemoveDLC(int dlcID)
        {
            var dlc = DB.DLC.Find(dlcID);
            DB.DLC.Delete(dlc);
        }


    }
}
