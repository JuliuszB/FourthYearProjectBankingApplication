using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{
    [Route("api/BankController")]
    [ApiController]
    public class BankController : ControllerBase
    {

        private readonly BankContext _dbContext;

        public BankController(BankContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<BankAccount>> GetAll()
        {
            var accounts = _dbContext.BankAccount.ToList();
            return Ok(accounts);
        }

        /* [HttpGet("getUser")]
         [ProducesResponseType(StatusCodes.Status200OK)]
         public ActionResult<projectAPI.Person> GetOne([FromQuery]string userPhoneNo, [FromQuery]string userPass)
         {

            // var person = _dbContext.Person.Where(p => p.phoneNo == userPhoneNo && p.password == userPass).SingleOrDefault();
             var person = _dbContext.Person.FirstOrDefault(p => p.phoneNo == userPhoneNo && p.password == userPass);
             return Ok(person);
         }
        */

        [HttpPost("getAccount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetOne(string IBAN)
        {


            var account = _dbContext.BankAccount.FirstOrDefault(a => a.IBAN == IBAN);
            return Ok(account);

        }

        [HttpPost("getAllAccounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetByNumber([FromBody]string phoneNo)
        {


            var accounts = _dbContext.BankAccount.Where(a => a.accountOwner == phoneNo);
            return Ok(accounts);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Insert(BankAccount accountToAdd)
        {
            _dbContext.BankAccount.Add(accountToAdd);
            try
            {


                await _dbContext.SaveChangesAsync(); //IMPORTANT ! COMMIT STATEMENT
                return Ok();
            }

            catch (Exception e)
            {
                return StatusCode(500);
            }

        }
    }
}
