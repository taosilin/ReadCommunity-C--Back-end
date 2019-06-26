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
    public class ScoreService
    {
        bookEntities ctx = new bookEntities();
        public bool AddScore(score score)
        {
            ctx.score.Add(score);

            try
            {
                ctx.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (scoreExists(score.username))
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
        private bool scoreExists(string id)
        {
            return ctx.score.Count(e => e.username == id) > 0;
        }
    }
}
