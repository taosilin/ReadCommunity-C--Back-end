using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http.Description;
using Services;
namespace final_project_back_end.Controllers
{
    [Route("LikeBook")]
    public class LikeBookController : ApiController
    {
        private bookEntities1 db = new bookEntities1();

        private UserBookService userBookService = new UserBookService();

        public class LikeBook
        {
            public string username { get; set; }
            public string type { get; set; }
        }

        [Route("LikeBook/List")]
        [HttpPost]
        public IHttpActionResult Getuser_book(LikeBook likeBook)
        {
            //user_book user_book = db.user_book.Find(id);
            bookEntities1 ctx = new bookEntities1();
            var like_book = ctx.user_book.Where(x => x.username == likeBook.username && x.type == likeBook.type);
            var result = (from u in ctx.user_book join b in ctx.book_info on u.bookid equals b.id where u.username == likeBook.username && u.type==likeBook.type select new { u.username,u.bookid,u.type,u.time,b.book_name,b.author,b.book_image,b.publisher,b.introduction}).ToList();
            if (result == null)
            {
                return NotFound();
            }

            return Json(result);
        }

        [Route("LikeBook/UserBook")]
        [HttpPost]
        public IHttpActionResult Postuser_book(Services.user_book user_book)
        {
            /*
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
            }*/
            bool res = userBookService.Postuser_book(user_book);
            if (res == true)
            {
                return Json("success");
            }
            else
            {
                return Json("error");
            }
        }
    }
}
