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
        [Route("UserInfo/Update")]
        [HttpPost]
        public IHttpActionResult Updateuser(user user)
        {
            bookEntities1 ctx = new bookEntities1();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ctx.Entry(user).State = EntityState.Modified;

            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
               throw;
            }

            return Json("success");
        }
    }
}
