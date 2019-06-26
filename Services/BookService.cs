using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Entity;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web;
namespace Services
{
    public class BookService
    {
        public IEnumerable<book_info> BookScoreList()
        {
            bookEntities ctx = new bookEntities();
            var book_info = ctx.book_info.OrderByDescending(x => x.score).Take(10).ToList();
            return book_info;
        }

        public IEnumerable<book_info> BookRatingList()
        {
            bookEntities ctx = new bookEntities();
            var book_info = ctx.book_info.OrderByDescending(x => x.rating_num).Take(10).ToList();
            return book_info;
        }

        public IEnumerable<book_info> BookNewList()
        {
            bookEntities ctx = new bookEntities();
            var book_info = ctx.book_info.OrderByDescending(x => x.publish_date).Take(10).ToList();
            return book_info;
        }

        public IEnumerable<book_info> SearchBook(string name, int page, int size)
        {
            bookEntities ctx = new bookEntities();
            var book_info = (from b in ctx.book_info where ((b.author.Contains(name)) || (b.book_name.Contains(name))) select b)
                .OrderByDescending(x => x.score).Skip(page * size).Take(size).ToList();
            return book_info;
        }

        public IEnumerable<book_info> SearchType(string name, int page, int size)
        {
            bookEntities ctx = new bookEntities();
            var book_info = (from b in ctx.book_info where b.tags.Contains(name) select b)
                .OrderByDescending(x => x.score).Skip(page * size).Take(size).ToList();
            return book_info;
        }

        public book_info BookDetail(int id)
        {
            bookEntities ctx = new bookEntities();
            var book_info = ctx.book_info.Where(x => x.id == id).ToList();

            return book_info[0];
        }

        public IEnumerable<book_info> Recommend(string name, int page, int size)
        {
            bookEntities ctx = new bookEntities();

            var recommend = (from u in ctx.user_book
                             join b in ctx.book_info on u.bookid equals b.id
                             where u.username == name && u.type == "1"
                             select new { b.author, b.tags, u.time }).OrderByDescending(u => u.time).Take(1).ToList();

            string author = recommend[0].author;
            string tags = recommend[0].tags;
            string[] tag = tags.Split(',');
            tags = tag[0];

            var book_info = (from b in ctx.book_info where ((b.author.Contains(author)) || (b.tags.Contains(tags))) select b)
                .OrderByDescending(x => x.score).Skip(page * size).Take(size).ToList();

            return book_info;
        }
    }
}

