using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Share;
using Services;
namespace final_project_back_end.Controllers
{
    [Route("UserInfo")]
    public class UserInfoController : ApiController
    {
        private bookEntities1 db = new bookEntities1();

        private UserService userService = new UserService();

        [Route("UserInfo/Detail")]
        [HttpPost]
        public IHttpActionResult Getuser(Services.user u)
        {
            //bookEntities1 ctx = new bookEntities1();
            //var user = ctx.user.Where(x => x.username == u.username);
            var user = userService.Getuser(u);
            if (user == null)
            {
                return NotFound();
            }

            return Json(user);
        }

        [Route("UserInfo/SignUp")]
        [HttpPost]
        public IHttpActionResult SignUp(Services.user user)
        {
            /*
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //密码加密
            user.password = Share.Class1.EncodeBase64(user.password);

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
            */
            bool res = userService.SignUp(user);
            if (res == true)
            {
                return Json("success");
            }
            else
            {
                return Json("error");
            }
        }

        [Route("UserInfo/Update")]
        [HttpPost]
        public IHttpActionResult Updateuser(Services.user user)
        {
            // bookEntities1 ctx = new bookEntities1();
            /*
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
            */
            userService.Updateuser(user);
            return Json("success");
        }

        private bool userExists(string id)
        {
            return db.user.Count(e => e.username == id) > 0;
        }
    }
}
