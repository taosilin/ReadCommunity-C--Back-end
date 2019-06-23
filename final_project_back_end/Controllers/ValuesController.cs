using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;

namespace final_project_back_end.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                MySqlConnection con =
                    new MySqlConnection(
                        "Data Source=106.13.75.89;Initial Catalog=book;Integrated Security=True;User Id=root;Password=769647273");
                con.Open();
                MySqlCommand sql = new MySqlCommand("select * from user",con);
                MySqlDataAdapter sda = new MySqlDataAdapter(sql);
                DataSet dt = new DataSet();
                sda.Fill(dt);
                return Json(dt);
            }
            catch (Exception ex)
            {
                return Json<string>("error");
            }

        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
