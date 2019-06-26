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
using Share;
using Services;
namespace final_project_back_end.Controllers
{
    /*
    public class UserInfo
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    */
    [Route("Login")]
    public class LoginController : ApiController
    {
        private UserService userService = new UserService();

        [Route("Login/user")]
        [HttpPost]
        public IHttpActionResult Login(Services.user userInfo)
        {
            /*
            bookEntities1 ctx = new bookEntities1();

            var user = ctx.user.Find(userInfo.username);

            if (user == null)
            {
                return Json("error");
            }
            else
            {
                if (Share.Class1.DecodeBase64(user.password) == userInfo.password)
                {
                    return Json("success");
                }
                else
                {
                    return Json("error");
                }
            }
            */
            bool res = userService.Login(userInfo);
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
