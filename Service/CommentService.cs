using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Entity;
using System.Collections.ObjectModel;
namespace Service
{
    public class CommentService
    {
        public class Info
        {
            public int commentid { get; set; }
            public int bookid { get; set; }
            public string username { get; set; }
            public string content { get; set; }
            public DateTime commenttime { get; set; }
            public string nickname { get; set; }

        }
    

        public bool Postcomment(comment comment)
        {

                bookEntities ctx = new bookEntities();

                ctx.comment.Add(comment);
                ctx.SaveChanges();

                return true;
        }

        public bool Deletecomment(comment comment)
        {

            bookEntities ctx = new bookEntities();
            comment c = ctx.comment.Find(comment.commentid);
            if (c == null)
            {
                return false;
            }

            ctx.comment.Remove(c);
            ctx.SaveChanges();

            return true;
        }

    }
}
