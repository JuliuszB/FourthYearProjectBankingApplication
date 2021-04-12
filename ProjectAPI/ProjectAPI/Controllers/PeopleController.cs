using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI
{
    public class loginCredentials
    {
        public string phoneNo { get; set; }
        public string password { get; set; }
    }

    [ApiController]
    [Route("api/PeopleController")]
    public class PeopleController : ControllerBase
    {
        private readonly BankContext _dbContext;

        public PeopleController(BankContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<projectAPI.Person>> GetAll()
        {
            var people = _dbContext.Person.ToList();
            return Ok(people);
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

        [HttpPost("getuser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetOne([FromBody]loginCredentials user)
        {
            
            
            var person = _dbContext.Person.FirstOrDefault(p => p.phoneNo == user.phoneNo && p.password == user.password);
            return Ok(person);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Insert(projectAPI.Person personToAdd)
        {
            _dbContext.Person.Add(personToAdd);
            try { 

                
                await _dbContext.SaveChangesAsync(); //IMPORTANT ! COMMIT STATEMENT
                return Ok();
            }

            catch (Exception e)
            {
                return StatusCode(500);
            }

        }
        [HttpPut("put")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> update(projectAPI.Person personToUpdate)
        {
            
            try
            {
                var person = _dbContext.Person.FirstOrDefault(p => p.id == personToUpdate.id);
                person.copy(personToUpdate);
                _dbContext.Person.Update(person);
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