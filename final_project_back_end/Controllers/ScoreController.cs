using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Service;

namespace final_project_back_end.Controllers
{
    using System.Runtime.InteropServices;

    [Route("Score")]
    public class ScoreController : ApiController
    {
        [DllImport("C++", EntryPoint = "sum")]
        public static extern int Sum(int a, int b);

        [DllImport("C++", EntryPoint = "calc")]
        public static extern float Calc(float old_score, int old_rating, int score);

        private bookEntities1 db = new bookEntities1();

        private ScoreService scoreService = new ScoreService();

        private static object Lock = new object();

        [Route("Score/Add")]
        [HttpPost]
        public IHttpActionResult Postscore(Service.score score)
        {
            lock (Lock)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                //db.score.Add(score);
                scoreService.AddScore(score);

                var s = (from b in db.book_info where b.id == score.bookid select new { b.score, b.rating_num, b.star1, b.star2, b.star3, b.star4, b.star5 }).ToList();
                float old_score = s[0].score.Value / 2;
                int old_rating = s[0].rating_num.Value;
                float old_star1 = old_rating * s[0].star1.Value / 100;    //1星人数
                float old_star2 = old_rating * s[0].star2.Value / 100;
                float old_star3 = old_rating * s[0].star3.Value / 100;
                float old_star4 = old_rating * s[0].star4.Value / 100;
                float old_star5 = old_rating * s[0].star5.Value / 100;




                float new_score = Calc(old_score, old_rating, score.score1);


                //float new_score = 2 * (old_score * old_rating + score.score1) / (old_rating + 1);
                if (score.score1 == 1)
                {
                    old_star1 += 1;
                }
                else if (score.score1 == 2)
                {
                    old_star2 += 1;
                }
                else if (score.score1 == 3)
                {
                    old_star3 += 1;
                }
                else if (score.score1 == 4)
                {
                    old_star4 += 1;
                }
                else if (score.score1 == 5)
                {
                    old_star5 += 1;
                }
                //old_rating += 1;
                //old_rating = Sum(old_rating, 1);

                System.Type type = Type.GetTypeFromProgID("MyCOM.MyClass");
                dynamic temp = Activator.CreateInstance(type);
                old_rating = temp.Add(old_rating, 1);

                old_star1 = 100 * old_star1 / old_rating;
                old_star2 = 100 * old_star2 / old_rating;
                old_star3 = 100 * old_star3 / old_rating;
                old_star4 = 100 * old_star4 / old_rating;
                old_star5 = 100 * old_star5 / old_rating;

                book_info book_info = db.book_info.Find(score.bookid);
                book_info.score = new_score;
                book_info.rating_num = old_rating;
                book_info.star1 = old_star1;
                book_info.star2 = old_star2;
                book_info.star3 = old_star3;
                book_info.star4 = old_star4;
                book_info.star5 = old_star5;

                db.Entry(book_info).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    throw;
                }

                return Json("success");
            }
        }
        private bool scoreExists(string id)
        {
            return db.score.Count(e => e.username == id) > 0;
        }
    }
}
