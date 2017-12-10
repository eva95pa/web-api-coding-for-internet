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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("game/v1/credentials")]
    public class CredentialsController : ApiController
    {

        [Route("")]
        public void Post([FromBody]Credentials credentials)
        {
            var oldCredentials = DB.Credentials.Find(c => { return c.Password == credentials.Password && c.Username == credentials.Username; });
            if (oldCredentials != null)
            {
                var response = new HttpResponseMessage();
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            DB.Credentials.Add(credentials);
        }

        [Route("")]
        public void Put([FromBody]Credentials credentials)
        {
            var oldCredentials = DB.Credentials.Find(c => { return c.Password == credentials.Password && c.Username == credentials.Username; });
            if (oldCredentials == null)
            {
                var response = new HttpResponseMessage();
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            credentials.Id = oldCredentials.Id;
            DB.Credentials.Update(credentials);
        }
    }
}
