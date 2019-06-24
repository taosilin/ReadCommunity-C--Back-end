﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;

namespace final_project_back_end.Controllers
{
    public class LikeBookController : ApiController
    {
        private bookEntities1 db = new bookEntities1();

        public class LikeBook
        {
            public string username { get; set; }
            public string type { get; set; }
        }

        // GET: api/LikeBook/5
        [HttpGet]
        [ResponseType(typeof(user_book))]
        public IHttpActionResult Getuser_book(LikeBook likeBook)
        {
            //user_book user_book = db.user_book.Find(id);
            bookEntities1 ctx = new bookEntities1();
            var like_book = ctx.user_book.Where(x => x.username == likeBook.username && x.type == likeBook.type);

            if (like_book == null)
            {
                return NotFound();
            }

            return Json(like_book);
        }


        // POST: api/LikeBook
        [HttpPost]
        [ResponseType(typeof(user_book))]
        public IHttpActionResult Postuser_book(user_book user_book)
        {
            bookEntities1 ctx = new bookEntities1();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.user_book.Add(user_book);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                var like_book = ctx.user_book.Where(x => x.username == user_book.username && x.bookid == user_book.bookid && x.type == user_book.type);

                if (like_book != null)
                {
                    return Json("exist");
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = user_book.username }, user_book);
        }
    }
}
