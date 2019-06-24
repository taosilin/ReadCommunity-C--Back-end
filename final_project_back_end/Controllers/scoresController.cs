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
using final_project_back_end;

namespace final_project_back_end.Controllers
{
    public class scoresController : ApiController
    {
        private bookEntities1 db = new bookEntities1();

        // GET: api/scores
        public IQueryable<score> Getscore()
        {
            return db.score;
        }

        // GET: api/scores/5
        [ResponseType(typeof(score))]
        public IHttpActionResult Getscore(string id)
        {
            score score = db.score.Find(id);
            if (score == null)
            {
                return NotFound();
            }

            return Ok(score);
        }

        // PUT: api/scores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putscore(string id, score score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != score.username)
            {
                return BadRequest();
            }

            db.Entry(score).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!scoreExists(id))
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

        // POST: api/scores
        [ResponseType(typeof(score))]
        public IHttpActionResult Postscore(score score)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.score.Add(score);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (scoreExists(score.username))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = score.username }, score);
        }

        // DELETE: api/scores/5
        [ResponseType(typeof(score))]
        public IHttpActionResult Deletescore(string id)
        {
            score score = db.score.Find(id);
            if (score == null)
            {
                return NotFound();
            }

            db.score.Remove(score);
            db.SaveChanges();

            return Ok(score);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool scoreExists(string id)
        {
            return db.score.Count(e => e.username == id) > 0;
        }
    }
}