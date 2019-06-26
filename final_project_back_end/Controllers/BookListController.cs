using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.InteropServices;
using System.Threading;
using Services;

namespace final_project_back_end.Controllers
{
    public class SearchBook
    {
        public string name { get; set; }
        public int page { get; set; }
        public int size { get; set; }
    }

    [Route("BookList")]
    public class BookListController : ApiController
    {
        private bookEntities1 db = new bookEntities1();

        private IEnumerable<Services.book_info> list;

        private BookService bookService = new BookService();

        [DllImport("Win32.dll", EntryPoint = "getTotalPages", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getTotalPages(int a, int b, int c, int d);

        [DllImport("Win32.dll", EntryPoint = "getStartPage", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getStartPage(int a, int b, int c, int d);

        [DllImport("Win32.dll", EntryPoint = "getEndPage", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getEndPage(int a, int b, int c, int d);

        [DllImport("Win32.dll", EntryPoint = "getStartData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getStartData(int a, int b, int c, int d);

        [DllImport("Win32.dll", EntryPoint = "getEndData", CallingConvention = CallingConvention.Cdecl)]
        public static extern int getEndData(int a, int b, int c, int d);

        [Route("BookList/Detail")]
        [HttpPost]
        public IHttpActionResult Getbook_info(book_info b)
        {
            //var book_info = db.book_info.Where(x => x.id == b.id);
            var book_info = bookService.BookDetail(b.id);
            if (book_info == null)
            {
                return NotFound();
            }

            return Json(book_info);
        }

        [Route("BookList/score")]
        [HttpPost]
        public IHttpActionResult BookScoreList()
        {
            /*
            bookEntities1 ctx = new bookEntities1();
            var book_info = ctx.book_info.OrderByDescending(x => x.score).Take(10).ToList();
            if (book_info == null)
            {
                return NotFound();
            }
           
            return Json<List<book_info>>(book_info);
            */

            ThreadPool.QueueUserWorkItem(ThreadOne, 1000);

            while (list == null)
            {
                Thread.Sleep(1000);
            }


            return Json(list);
        }

        private void ThreadOne(object state)
        {
            //bookEntities1 ctx = new bookEntities1();
            //list = ctx.book_info.OrderByDescending(x => x.score).Take(10).ToList();
            list = bookService.BookScoreList();
        }

        [Route("BookList/rating")]
        [HttpPost]
        public IHttpActionResult BookRatingList()
        {
            //bookEntities1 ctx = new bookEntities1();
            //var book_info = ctx.book_info.OrderByDescending(x => x.rating_num).Take(10).ToList();
            var book_info = bookService.BookRatingList();
            if (book_info == null)
            {
                return NotFound();
            }

            return Json(book_info);
        }

        [Route("BookList/new")]
        [HttpPost]
        public IHttpActionResult BookNewList()
        {
            //bookEntities1 ctx = new bookEntities1();
            //var book_info = ctx.book_info.OrderByDescending(x => x.publish_date).Take(10).ToList();
            var book_info = bookService.BookNewList();
            if (book_info == null)
            {
                return NotFound();
            }

            return Json(book_info);
        }


        [Route("BookList/searchName")]
        [HttpPost]
        public IHttpActionResult SearchBook(SearchBook searchBook)
        {
            bookEntities1 ctx = new bookEntities1();

            int bookcount= (from b in ctx.book_info where ((b.author.Contains(searchBook.name)) || (b.book_name.Contains(searchBook.name))) select b).Count();

            int totalPages =getTotalPages(bookcount,searchBook.size,searchBook.page+1,10);
            int startPage = getStartPage(bookcount, searchBook.size, searchBook.page+1, 10);
            int endPage = getEndPage(bookcount, searchBook.size, searchBook.page+1, 10);
            int startData = getStartData(bookcount, searchBook.size, searchBook.page+1, 10);
            int endData = getEndData(bookcount, searchBook.size, searchBook.page+1, 10);

            //var book_info = (from b in ctx.book_info where ((b.author.Contains(searchBook.name)) || (b.book_name.Contains(searchBook.name))) select b)
            //  .OrderByDescending(x => x.score).Skip(searchBook.page * searchBook.size).Take(searchBook.size).ToList();
            var book_info = bookService.SearchBook(searchBook.name,searchBook.page,searchBook.size);
            if (book_info == null)
            {
                return NotFound();
            }

            return Json(book_info);
        }

        [Route("BookList/searchType")]
        [HttpPost]
        public IHttpActionResult SearchType(SearchBook searchBook)
        {
            //bookEntities1 ctx = new bookEntities1();

            //var book_info = (from b in ctx.book_info where b.tags.Contains(searchBook.name) select b)
            //  .OrderByDescending(x => x.score).Skip(searchBook.page * searchBook.size).Take(searchBook.size).ToList();
            var book_info = bookService.SearchType(searchBook.name, searchBook.page, searchBook.size);
            if (book_info == null)
            {
                return NotFound();
            }

            return Json(book_info);
        }

        [Route("BookList/Recommend")]
        [HttpPost]
        public IHttpActionResult Recommend(SearchBook searchBook)
        {
            //bookEntities1 ctx = new bookEntities1();

            //            var recommend = (from u in ctx.user_book join b in ctx.book_info on u.bookid equals b.id
            //                       where u.username == searchBook.name && u.type == "1"
            //                      select new { b.author, b.tags,u.time }).OrderByDescending(u => u.time).Take(1).ToList();

            //        string author = recommend[0].author;
            //      string tags = recommend[0].tags;
            //    string[] tag = tags.Split(',');
            //  tags = tag[0];

            //var book_info = (from b in ctx.book_info where ((b.author.Contains(author)) || (b.tags.Contains(tags))) select b)
            //    .OrderByDescending(x => x.score).Skip(searchBook.page * searchBook.size).Take(searchBook.size).ToList();
            var book_info = bookService.Recommend(searchBook.name, searchBook.page, searchBook.size);
            if (book_info == null)
            {
                return NotFound();
            }

            return Json(book_info);
        }
    }
}
