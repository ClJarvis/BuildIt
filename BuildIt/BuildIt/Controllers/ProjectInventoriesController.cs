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
    public class ProjectInventoriesController : ApiController
    {
        private InventoryContext context = new InventoryContext();

        // GET: api/ProjectInventories
        public IQueryable<ProjectInventory> GetProjectInventories()
        {
            return context.ProjectInventories;
        }

        // GET: api/ProjectInventories/5
        [ResponseType(typeof(ProjectInventory))]
        public IHttpActionResult GetProjectInventory(int id)
        {
            ProjectInventory projectInventory = context.ProjectInventories.Find(id);
            if (projectInventory == null)
            {
                return NotFound();
            }

            return Ok(projectInventory);
        }

        // PUT: api/ProjectInventories/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProjectInventory(int id, ProjectInventory projectInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Entry(projectInventory).State = System.Data.Entity.EntityState.Modified;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectInventoryExists(id))
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

        // POST: api/ProjectInventories
        [ResponseType(typeof(ProjectInventory))]
        public IHttpActionResult PostProjectInventory(ProjectInventory projectInventory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.ProjectInventories.Add(projectInventory);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = projectInventory.ProjectInventoryId }, projectInventory);
        }

        // DELETE: api/ProjectInventories/5
        [ResponseType(typeof(ProjectInventory))]
        public IHttpActionResult DeleteProjectInventory(int id)
        {
            ProjectInventory projectInventory = context.ProjectInventories.Find(id);
            if (projectInventory == null)
            {
                return NotFound();
            }

            context.ProjectInventories.Remove(projectInventory);
            context.SaveChanges();

            return Ok(projectInventory);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectInventoryExists(int id)
        {
            return context.ProjectInventories.Count(e => e.ProjectInventoryId == id) > 0;
        }
    }
}