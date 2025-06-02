using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Data.SqlClient;
using System.Data;
namespace ESP32EWebConnection_.Controllers
{
    public class ValuesController : ApiController
    {
        Database_Access_Layer.db dblayer = new Database_Access_Layer.db();



        [HttpGet]
        [Route("api/values/getbyid/{id}")]
        public IHttpActionResult GetById(int id)
        {
            DataTable dt = dblayer.GetRecordbyid(id).Tables[0];

            if (dt.Rows.Count == 0)
                return NotFound();

            var result = dt.AsEnumerable().Select(row => new
            {
                ProfessorName = row["ProfessorName"].ToString(),
                ProfessorStatus = row["ProfessorStatus"].ToString(),
                DropdownListOptions = row["DropdownListOptions"].ToString(),
                ESP32MacAddress = row["ESP32MacAddress"].ToString(),
                WifiConnectionSSID = row["WifiConnectionSSID"].ToString(),
                WifiConnectionPassword = row["WifiConnectionPassword"].ToString()
            });

            return Ok(result);
        }

        // Other methods (Get, Post, etc.)
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        public DataSet GetRecord(int id)
        {
            DataSet ds = dblayer.GetRecordbyid(id);
            return ds;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
