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
using System.Net.Http.Json;

namespace BankingApplication.Models
{
   public class BankAccount
    {
        public string accountOwner { get; set; }
        public string accountName { get; set; }
        public string accountNumber { get; set; }
        public double balance { get; set; }

        [JsonProperty("iban")]
        public string iban { get; set; }

        //Base URI
        private static readonly string baseURI = "https://10.0.2.2:5001/api/";

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
        public static async Task RunPost(BankAccount accountToAdd)
        {
            try
            {
                var result = await httpClient.PostAsJsonAsync(baseURI + "BankController", accountToAdd);

                result.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        //Get a single account  by iban
        public static async Task<BankAccount> getAccount(string iban )
        {
            try
            {
               var result = await httpClient.PostAsJsonAsync(baseURI + "BankController/getAccount",iban );
                var accountData = await result.Content.ReadAsStreamAsync();
                var fetchedAccount = await System.Text.Json.JsonSerializer.DeserializeAsync<BankAccount>(accountData);
                result.EnsureSuccessStatusCode();
                return fetchedAccount;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        //Get all accounts by Account owner name
        public static async Task<List<BankAccount>> getAllAccounts(string accountOwner)
        {
            try
            {
                var result =  await httpClient.PostAsJsonAsync(baseURI + "BankController/getAllAccounts", accountOwner);
                var accountData =  await result.Content.ReadAsStreamAsync();
                List<BankAccount> fetchedAccounts = await System.Text.Json.JsonSerializer.DeserializeAsync<List<BankAccount>>(accountData);
                //result.EnsureSuccessStatusCode();
                return fetchedAccounts;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
