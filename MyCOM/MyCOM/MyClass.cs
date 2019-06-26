using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MyCOM
{
    [ComVisible(true)]
    [Guid("1A811554-2B7A-4844-B334-9C07D7E71802")]
    //[Guid("B13D6B05-E897-415D-8E09-0C16B94A84DE")]
    public interface IMyClass
    {
        void Initialize();
        void Dispose();
        int Add(int x, int y);
        float[] Try(float star1, float star2, float star3, float star4, float star5, int num);
    }

    [ComVisible(true)]
    [Guid("35B9DED3-A55A-47BD-A869-FFFA845564D8")]
    //[Guid("EC11767D-F089-4C00-AC21-94B403D76914")]
    [ProgId("MyCOM.MyClass")]
    public class MyClass : IMyClass
    {
        public void Initialize()
        {
            //nothing
        }

        public void Dispose()
        {
            //nothing
        }

        public int Add(int x, int y)
        {
            return x + y;
        }

        public float[] Try(float old_star1, float old_star2, float old_star3, float old_star4, float old_star5, int old_rating)
        {
            old_star1 = 100 * old_star1 / old_rating;
            old_star2 = 100 * old_star2 / old_rating;
            old_star3 = 100 * old_star3 / old_rating;
            old_star4 = 100 * old_star4 / old_rating;
            old_star5 = 100 * old_star5 / old_rating;

            float[] res = { old_star1, old_star2, old_star3, old_star4, old_star5 };

            /*
            foreach (float i in res)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            */

            return res;
        }
    }
}
