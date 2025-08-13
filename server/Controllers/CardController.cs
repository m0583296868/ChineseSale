using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMA.BL;
using MSMA.DAL;
using MSMA.Models;
using MSMA.Models.DTO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MSMA.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService iCardService;

        public CardController(ICardService ICardService)
        {
            iCardService = ICardService;
        }
        // GET: api/<CardController>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IEnumerable<Cards> >Get()

        {
            try
            {

                return await iCardService.Get();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        // GET api/<CardController>/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<Cards> Get(int id)
        {
            try { 
            return await iCardService.Get(id);}
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]

        [HttpGet("random/{id}")]
        public async Task<string> TheRandom(int id)
        {
            try { 
            return await iCardService.TheRandom(id);}
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        // POST api/<CardController>
        [Authorize(Roles = "User")]

        [HttpPost]
        public async Task<bool> Post([FromBody] CardsDTO value)
        {
            try { 
         return await  iCardService.Add(value);}
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "User")]
        // PUT api/<CardController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CardsDTO value)
        {
            try { 
            iCardService.Update(id,value);}
            catch (Exception ex)
            {
                throw new Exception();
            }

        }
        [Authorize(Roles = "User")]
        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try{ 
            await iCardService.Remove(id);
            }
             catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("sortBy{type}")]
        public async Task<List<Cards>> GetBySort(int type)
        {
            try { 
            return await iCardService.GetBySort(type);}
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("gift{id}")]
        public async Task<List<Cards>> GetGift(int id)
        {
            try { 
            return await iCardService.GetGift(id);}
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("customers")]
        public async Task< List<Users>> GetCustomers()
        {
            try { 
            return await iCardService.GetCustomers();}
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("benefits")]
          public async Task< int> Benefits(){
            try { 
           return   await iCardService.Benefits();}
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        [HttpGet("geters")]

        public async Task< List<Object>> Getgeters()
        {
            try { 
            List<Object> c = new List<Object>();
            c =await iCardService.Getgeters();
            return c;
        }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    [Authorize(Roles = "User")]
    [HttpGet("myCard/{id}")]
    public async Task<List<Cards>> GetMyCard(int id)
    {
      try { 
      return await iCardService.GetMyCard(id);}
      catch (Exception ex)
      {
        throw new Exception();
      }
    }

    }
}
