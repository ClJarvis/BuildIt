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
    public class ProjectsController : ApiController
    {
        private InventoryContext context = new InventoryContext();

        // GET: api/Projects
        public IQueryable<Project> GetProjects()
        {
            return context.Projects;
        }

        // GET: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult GetProject(int id)
        {
            Project project = context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        // PUT: api/Projects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Entry(project).State = System.Data.Entity.EntityState.Modified;
           

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(project.ProjectId))
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

        // POST: api/Projects
        [ResponseType(typeof(Project))]
        public IHttpActionResult PostProject(Project project)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Projects.Add(project);
            context.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = project.ProjectId }, project);
        }

        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = context.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            context.Projects.Remove(project);
            context.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return context.Projects.Count(e => e.ProjectId == id) > 0;
        }
    }
}