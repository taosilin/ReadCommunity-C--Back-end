using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Service
{
    public class UserBookService
    {

        public bool Postuser_book(user_book user_book)
        {
            bookEntities ctx = new bookEntities();

            ctx.user_book.Add(user_book);

            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateException)
            {
                var like_book = ctx.user_book.Where(x => x.username == user_book.username && x.bookid == user_book.bookid && x.type == user_book.type);

                if (like_book != null)
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
    }
}
