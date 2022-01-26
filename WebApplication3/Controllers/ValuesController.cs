using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace WebApplication3.Controllers
{
    public class ValuesController : ApiController
    {
        SqlConnection con = new SqlConnection(@"server=DESKTOP-POJ5QGJ; database=Project; Integrated Security = true;");
        // GET api/values
        public string Get()
        {
            //return new string[] { "value1", "value2" };
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LapId", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count>0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }

        // GET api/values/5
        public string Get(int id)
        {
            //return "value";
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LapId WHERE id = '"+id+"' ", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                return JsonConvert.SerializeObject(dt);
            }
            else
            {
                return "No data found";
            }
        }

        // POST api/values
        public string Post([FromBody] string value)
        {
            //return value + " Added Succesfully ";
            SqlCommand cmd = new SqlCommand("Insert into LapId(FirstName) VALUES('"+value+"')", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Data Inserted with the value as " + value;
            }
            else
            {
                return "No data Inserted. Please try again.";
            }
        }

        // PUT api/values/5
        public string Put(int id, [FromBody] string value)
        {
            //return value + " Record added succesfully with id " + id;
            SqlCommand cmd = new SqlCommand("UPDATE LapId SET FirstName = '"+value+"' WHERE ID = '"+id+"'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if(i == 1)
            {
                return "Record Updated with value as " + value + " and the Id as " + id;
            }
            else
            {
                return "No Data Updated. Try Againg";
            }
        }

        // DELETE api/values/5
        public string Delete(int id)
        {
            //return " record deleted successfully with id" + id;
            SqlCommand cmd = new SqlCommand("DELETE FROM LapId WHERE ID = '" + id + "'", con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i == 1)
            {
                return "Record Deleted with value as Id " + id;
            }
            else
            {
                return "No Data Deleted with Id as = '"+id+"' Try Againg";
            }
        }
    }
}
