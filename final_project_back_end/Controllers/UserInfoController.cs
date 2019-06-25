using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace final_project_back_end.Controllers
{
    [Route("UserInfo")]
    public class UserInfoController : ApiController
    {
        private bookEntities1 db = new bookEntities1();

        [Route("UserInfo/Detail")]
        [HttpPost]
        public IHttpActionResult Getuser(user u)
        {
            bookEntities1 ctx = new bookEntities1();
            var user = ctx.user.Where(x => x.username == u.username);
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [Route("UserInfo/SignUp")]
        [HttpPost]
        public IHttpActionResult SignUp(user user)
        {
            // bookEntities1 ctx = new bookEntities1();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.user.Add(user);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (userExists(user.username))
                {
                    return Json("error");
                }
                else
                {
                    throw;
                }
            }

            return Json("success");
        }

        [Route("UserInfo/Update")]
        [HttpPost]
        public IHttpActionResult Updateuser(user user)
        {
            // bookEntities1 ctx = new bookEntities1();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(user).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
               throw;
            }

            return Json("success");
        }

        private bool userExists(string id)
        {
            return db.user.Count(e => e.username == id) > 0;
        }
    }
}
