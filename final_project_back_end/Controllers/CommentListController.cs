using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using Service;
namespace final_project_back_end.Controllers
{
    
    [Route("CommentList")]
    public class CommentListController : ApiController
    {
        private static object Lock = new object();

        private CommentService commentService = new CommentService();
        [Route("CommentList/Add")]
        [HttpPost]
        public IHttpActionResult Postcomment(Service.comment comment)
        {
            lock (Lock)
            {
                //bookEntities1 ctx = new bookEntities1();
                //if (!ModelState.IsValid)
                //{
                //  return BadRequest(ModelState);
                //}

                //ctx.comment.Add(comment);
                //ctx.SaveChanges();
                commentService.Postcomment(comment);
                return Json("success");
            }
        }

        [Route("CommentList/Book")]
        [HttpPost]
        public IHttpActionResult BookComment(Service.book_info book)
        {
            lock (Lock)
            {
                
                bookEntities1 ctx = new bookEntities1();
                var query = from u in ctx.user join c in ctx.comment on u.username equals c.username where c.bookid == book.id select new { c.commentid, c.bookid, c.username, c.content, c.commenttime, u.nickname };
                var result = query.ToList();
                return Json(result);
            }
        }

        [Route("CommentList/User")]
        [HttpPost]
        public IHttpActionResult UserComment(user user)
        {
            lock (Lock)
            {
                bookEntities1 ctx = new bookEntities1();
                var query = from b in ctx.book_info join c in ctx.comment on b.id equals c.bookid where c.username == user.username select new { c.commentid, c.bookid, c.username, c.content, c.commenttime, b.book_name, b.author, b.book_image, b.score };
                var result = query.ToList();
                return Json(result);
            }    
        }

        [Route("CommentList/Delete")]
        [HttpPost]
        public IHttpActionResult Deletecomment(Service.comment comment)
        {
            lock (Lock)
            {
                /*
                bookEntities1 ctx = new bookEntities1();
                comment c = ctx.comment.Find(comment.commentid);
                if (c == null)
                {
                    return NotFound();
                }
                ctx.comment.Remove(c);
                ctx.SaveChanges();
                */
                bool res = commentService.Deletecomment(comment);
                if(res == true)
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
}
