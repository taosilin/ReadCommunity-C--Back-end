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

    public class BookController : ApiController
    {
        private bookEntities1 db = new bookEntities1();

        // GET: api/Book
        public IQueryable<book_info> Getbook_info()
        {
            return db.book_info;
        }

        // GET: api/Book/5
        public IHttpActionResult Getbook_info(int id)
        {
            bookEntities1 ctx = new bookEntities1();
            var book_info = ctx.book_info.Where(x => x.id == id);
            if (book_info == null)
            {
                return NotFound();
            }

            return Json(book_info);
        }

        // PUT: api/Book/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbook_info(int id, book_info book_info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book_info.id)
            {
                return BadRequest();
            }

            db.Entry(book_info).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!book_infoExists(id))
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

        // POST: api/Book
        [ResponseType(typeof(book_info))]
        public IHttpActionResult Postbook_info(book_info book_info)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.book_info.Add(book_info);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (book_infoExists(book_info.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = book_info.id }, book_info);
        }

        // DELETE: api/Book/5
        [ResponseType(typeof(book_info))]
        public IHttpActionResult Deletebook_info(int id)
        {
            book_info book_info = db.book_info.Find(id);
            if (book_info == null)
            {
                return NotFound();
            }

            db.book_info.Remove(book_info);
            db.SaveChanges();

            return Ok(book_info);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool book_infoExists(int id)
        {
            return db.book_info.Count(e => e.id == id) > 0;
        }
    }
}