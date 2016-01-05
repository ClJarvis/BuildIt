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
using Newtonsoft.Json;
using System.Web.Mvc;
using System.Net.Http.Formatting;

namespace BuildIt.Controllers
{
    public class ProjectInventoriesController : ApiController   //remove api controller 
    {
        private InventoryContext context = new InventoryContext();

        // GET: api/ProjectInventories
        public string GetProjectInventories()
        {
            var list = context.ProjectInventories;
            return JsonConvert.SerializeObject(list);
        }

        

        // GET: ProjectInventories/5
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
        [System.Web.Mvc.HttpPost]
        [System.Web.Http.Route("projectInventories/PostProjectInventory")]
        public void PostProjectInventory(FormDataCollection data)
        {
            int projectId = int.Parse(data.Get("ProjectId"));
            int inventoryId = int.Parse(data.Get("InventoryId"));
            Project project = context.Projects.Find(projectId);
            Inventory inventory = context.Inventories.Find(inventoryId);
            ProjectInventory projectInventory = new ProjectInventory
            {
                Project = project, Inventory = inventory, ProjectId = projectId, InventoryId = inventoryId
            };
            context.ProjectInventories.Add(projectInventory);
            context.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = projectInventory.ProjectInventoryId }, projectInventory);
        }

        // DELETE: api/ProjectInventories/5
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("projectInventories/DeleteProjectInventory")]
        public IHttpActionResult DeleteProjectInventory(FormDataCollection data)
        {
            int projectId = int.Parse(data.Get("ProjectId"));
            int index = int.Parse(data.Get("ProjectInventoryIndex"));
            Project project = context.Projects.Find(projectId);
            ProjectInventory projectInventory = project.ProjectInventories.ToList<ProjectInventory>()[index];
            if (projectInventory == null)
            {
                return NotFound();
            }

            context.ProjectInventories.Remove(projectInventory);
            context.SaveChanges();

            return Ok();
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