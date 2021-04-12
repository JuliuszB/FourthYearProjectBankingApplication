using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Text;
using System.Text.Json;
using SQLite;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
namespace BankingApplication.Models
{
    public class Person
    {
        public int id { get; set; }
        public string fName { get; set; }
        public string sName { get; set; }
        public string phoneNo { get; set; }
        public string password { get; set; }
        public string isLoggedIn { get; set; }
        public string email { get; set; }
        public void setIsLoggedIn(string input)
        {
            this.isLoggedIn = input;
        }

        //public static MobileServiceClient client = new MobileServiceClient("HTTP connection goes here :)");

        //private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string baseURI = "https://10.0.2.2:5001/api/";

        // This method must be in a class in a platform project, even if
        // the HttpClient object is constructed in a shared project.
        public static HttpClientHandler GetInsecureHandler()
        {
            HttpClientHandler handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
            {
                if (cert.Issuer.Equals("CN=localhost"))
                    return true;
                return errors == System.Net.Security.SslPolicyErrors.None;
            };
            return handler;
        }
#if DEBUG
       static HttpClientHandler insecureHandler = GetInsecureHandler();
        private static readonly HttpClient httpClient = new HttpClient(insecureHandler);
#else
   HttpClient httpClient = new HttpClient();
#endif


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
        //PUT UPDATE method
        public static async Task RunPut(Person personToUpdate)
        {
            try
            {
                var result = await httpClient.PutAsJsonAsync(baseURI + "PeopleController/put", personToUpdate);

                result.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        //Get a single user by phone number and password
        public static async Task<Person> getUser(loginCredentials passAndPhoneNo)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync(baseURI + "PeopleController/getuser", passAndPhoneNo);
                var personData = await result.Content.ReadAsStreamAsync();
                var fetchedUser = await System.Text.Json.JsonSerializer.DeserializeAsync<Person>(personData);
                result.EnsureSuccessStatusCode();
                return fetchedUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }


        public class loginCredentials
        {
            public loginCredentials(string phone, string pass)
            {
                phoneNo = phone;
                password = pass;
            }
            public string phoneNo { get; set; }
            public string password { get; set; }
        }


    }
}
