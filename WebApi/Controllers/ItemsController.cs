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
    [RoutePrefix("game/v1/accounts/{accountId:int}/characters/{characterId:int}/inventory/items")]
    public class ItemsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Item> GetAllItems(int characterId)
        {
            return DB.Items.FindAllByCharacterId(characterId);
        }

        [HttpPost]
        [Route("")]
        public Item AddItem(int characterId, [FromBody]Item item)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            item.CharacterId = characterId;
            var entity = DB.Items.Add(item);
            return entity;
        }

        [HttpPut]
        [Route("")]
        public IEnumerable<Item> UpdateItemsInInventory(int characterId, [FromBody]List<Item> items)
        {
            DB.Items.UpdateInventory(characterId, items);

            var updatedItems = DB.Items.FindAllByCharacterId(characterId);
            return updatedItems;
        }

        [HttpGet]
        [Route("{itemId:int}")]
        public Item GetItem(int itemId)
        {
            var item = DB.Items.Find(itemId);
            return item;
        }

        [HttpPut]
        [Route("{itemId:int}")]
        public Item UpdateItem(int itemId, [FromBody]Item item)
        {
            item.Id = itemId;
            DB.Items.Update(item);

            var updatedItem = DB.Items.Find(itemId);
            return updatedItem;
        }

        [HttpDelete]
        [Route("{itemId:int}")]
        public void RemoveItem(int itemId)
        {
            var entity = DB.Items.Find(itemId);
            DB.Items.Delete(entity);
        }
    }
}
