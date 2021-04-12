using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace projectAPI.Controllers
{
    [Route("api/PeopleController")]
    public class PeopleController : ApiController
    {
        DataTable dataTable = new DataTable { TableName = "People" };
        public HttpResponseMessage Get()
        {

            

            string query = @"SELECT ID,fName, sName,phoneNo FROM Person;";

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Year4XamarinSQLDatabase"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(dataTable);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dataTable);
        }
        
        //POST
        [HttpPost]
        public string Insert(Person personToAdd)
        {
            
            try
            {

                string query = @"INSERT INTO dbo.Person VALUES ('" + personToAdd.ID + @"','" + personToAdd.fName + @"', '" + personToAdd.sName + @"' , '" + personToAdd.phoneNo + @"' , '" + personToAdd.password + @"' );";

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["Year4XamarinSQLDatabase"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(dataTable);
                }

                
                return "Added";
            } 
            catch (Exception e)
            {

                return "Failed to add";
            }
        }
    }
}
