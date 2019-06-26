using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Share;
namespace Services
{
    public class UserService
    {
        bookEntities ctx = new bookEntities();

        public user Getuser(user u)
        {
            var user = ctx.user.Where(x => x.username == u.username).ToList();
            user[0].password = Share.Class1.DecodeBase64(user[0].password);
            return user[0];
        }


        public bool SignUp(user user)
        {
            user.password = Share.Class1.EncodeBase64(user.password);
            ctx.user.Add(user);

            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (userExists(user.username))
                {
                    return false;
                }
                else
                {
                    throw;
                }
            }

            return true;
        }

        public bool Updateuser(user user)
        {
            user.password = Share.Class1.EncodeBase64(user.password);
            ctx.Entry(user).State = EntityState.Modified;

            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return true;
        }

        public bool Login(user userInfo)
        {

            var user = ctx.user.Find(userInfo.username);

            if (user == null)
            {
                return false;
            }
            else
            {
                if (Share.Class1.DecodeBase64(user.password) == userInfo.password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

            private bool userExists(string id)
        {
            return ctx.user.Count(e => e.username == id) > 0;
        }

    }
}
