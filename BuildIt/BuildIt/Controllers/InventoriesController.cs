using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BuildIt.Models;
using BuildIt.DAL;

namespace BuildIt.Controllers
{
    public class InventoriesController : ApiController
    {
        private InventoryContext context = new InventoryContext();

        // GET: api/Inventories
        public IQueryable<Inventory> GetInventories()
        {
            return context.Inventories;
        }

        // GET: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult GetInventory(int id)
        {
            Inventory inventory = context.Inventories.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }

            return Ok(inventory);
        }

        // PUT: api/Inventories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Entry(inventory).State = System.Data.Entity.EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryExists(inventory.InventoryID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Inventories
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult PostInventory(Inventory inventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Inventories.Add(inventory);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = inventory.InventoryID }, inventory);
        }

        // DELETE: api/Inventories/5
        [ResponseType(typeof(Inventory))]
        public IHttpActionResult DeleteInventory(int id)
        {
            Inventory inventory = context.Inventories.Find(id);
            if (inventory == null)
            {
                return NotFound();
            }

            context.Inventories.Remove(inventory);
            context.SaveChanges();

            return Ok(inventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InventoryExists(int id)
        {
            return context.Inventories.Count(e => e.InventoryID == id) > 0;
        }
    }
}