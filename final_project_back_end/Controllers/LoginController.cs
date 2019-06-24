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

namespace final_project_back_end.Controllers
{
    public class UserInfo
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    [Route("Login")]
    public class LoginController : ApiController
    {

        [Route("Login/user")]
        [HttpPost]
        public IHttpActionResult Login(UserInfo userInfo)
        {
            bookEntities1 ctx = new bookEntities1();
            // var user = ctx.user.Where(x => x.username == userInfo.username);
            var user = ctx.user.Find(userInfo.username);
            /*
            var temp = from s in ctx.user
                       where s.username == userInfo.name
                       select s;
            */
            if (user == null)
            {
                return Json("error");
            }
            else
            {
                if (user.password == userInfo.password)
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
