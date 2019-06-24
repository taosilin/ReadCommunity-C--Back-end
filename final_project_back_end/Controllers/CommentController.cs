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
    public class Username
    {
        public string username { get; set; }
    }

    public class CommentController : ApiController
    {
        private bookEntities1 db = new bookEntities1();

        // GET: api/Comment
        public IHttpActionResult GetUsercomment(Username user)
        {
            bookEntities ctx = new bookEntities();
            var comments = ctx.comment.Where(x => x.user.username == user.username);
            if (comments == null)
            {
                return NotFound();
            }

            return Json(comments);
        }

        // GET: api/Comment/5      
        public IHttpActionResult GetBookcomment(int id)
        {
            bookEntities ctx = new bookEntities();
            var comments = ctx.comment.Where(x => x.book_info.id == id);
            if (comments == null)
            {
                return NotFound();
            }

            return Json(comments);
        }

       

        // PUT: api/Comment/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putcomment(int id, comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comment.commentid)
            {
                return BadRequest();
            }

            db.Entry(comment).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!commentExists(id))
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

        // POST: api/Comment
        [ResponseType(typeof(comment))]
        public IHttpActionResult Postcomment(comment comment)
        {
            bookEntities1 ctx = new bookEntities1();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ctx.comment.Add(comment);
            ctx.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = comment.commentid }, comment);
        }

        // DELETE: api/Comment/5
        [ResponseType(typeof(comment))]
        public IHttpActionResult Deletecomment(int id)
        {
            comment comment = db.comment.Find(id);
            if (comment == null)
            {
                return NotFound();
            }

            db.comment.Remove(comment);
            db.SaveChanges();

            return Ok(comment);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool commentExists(int id)
        {
            return db.comment.Count(e => e.commentid == id) > 0;
        }
    }
}