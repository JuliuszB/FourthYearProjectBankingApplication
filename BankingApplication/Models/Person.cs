using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Text;
using SQLite;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
namespace BankingApplication.Models
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string fName { get; set; }
        public string sName { get; set; }
        public string phoneNo { get; set; }
        public string password { get; set; }

        //public static MobileServiceClient client = new MobileServiceClient("HTTP connection goes here :)");

        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string baseURI = "https://10.0.2.2:44380/api/";

        

             
       
        //POST method
       public static async Task RunPost(Person personToAdd)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync(baseURI+"PeopleController", personToAdd);

                result.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
     





    }
}
