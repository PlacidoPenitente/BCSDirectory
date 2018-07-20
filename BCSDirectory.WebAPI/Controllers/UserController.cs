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
using BCSDirectory.Models;
using BCSDirectory.WebAPI.DAL;

namespace BCSDirectory.WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private BCSDirectoryContext db = new BCSDirectoryContext();

        // GET: api/User
        public IQueryable<User> GetUsers()
        {
            return db.Users.Include(x => x.Hobbies);
        }

        // GET: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUser(int id, User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user.Id)
            {
                return BadRequest();
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/User
        [ResponseType(typeof(User))]
        public IHttpActionResult PostUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hobbies = new List<Hobby>();

            foreach (var hobby in user.Hobbies)
            {
                var hob = db.Hobbies.Where(x => x.Name.ToUpper() == hobby.Name).Select(x => x).FirstOrDefault();
                if (hob == null)
                {
                    db.Hobbies.Add(hobby);
                    db.SaveChanges();

                    hob = db.Hobbies.Where(x => x.Name.ToUpper() == hobby.Name).Select(x => x).FirstOrDefault();
                }
                hobbies.Add(hob);
            }

            user.Hobbies.Clear();
            user.Hobbies = hobbies;

            user.Birthdate = new DateTime(user.Birthdate.Year, user.Birthdate.Month, user.Birthdate.Day, 0, 0, 0, DateTimeKind.Utc);

            db.Users.Add(user);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(User))]
        public IHttpActionResult DeleteUser(int id)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }

            db.Users.Remove(user);
            db.SaveChanges();

            return Ok(user);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}