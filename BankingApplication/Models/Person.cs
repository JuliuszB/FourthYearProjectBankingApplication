using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using System.Text;
using SQLite;

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

        public static MobileServiceClient client = new MobileServiceClient("HTTP connection goes here :)");

       /* public async Task<bool> savePerson()
        {
            try
            {
                await client.GetTable<Person>().InsertAsync(this);
                return true;
            }
            catch (MobileServiceInvalidOperationException msioe)
            {
                var response = await msioe.Response.Content.ReadAsStringAsync();
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static async Task<List<Person>> ReadPerson()
        {
            return await client.GetTable<Person>().ToListAsync();
        }
       */






    }
}
