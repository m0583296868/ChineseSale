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
    //[Authorize(Roles = "Admin")]

    public class GiftController : ControllerBase
    {
        private readonly IGiftService IGiftService;

        public GiftController(IGiftService i)
        {
            this.IGiftService = i;
        }
        // GET: api/<GiftController>

        [HttpGet]
        public async Task< IEnumerable<Gifts>> Get()
      {
            try { 
            return await IGiftService.Get();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        // GET api/<GiftController>/5
        [HttpGet("{id}")]
        public async Task< Gifts> Get(int id)
        {
            try { 
            return await IGiftService.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        // POST api/<GiftController>
       [Authorize(Roles = "Admin")] 
        [HttpPost]
        public async Task <Gifts> Post([FromBody] GiftsDTO value)
        {
            try { 
           return await IGiftService.Add(value);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
      
        [Authorize(Roles = "Admin")]    
        // PUT api/<GiftController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] GiftsDTO value)
        {
            try { 
          await  IGiftService.Update(id, value);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        // DELETE api/<GiftController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try {
            IGiftService.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("donor/{id}")]
        public async Task< Donors> GetDonor(int id)
        {
            try { 
            return await IGiftService.GetDonor(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("amount/{id}")]
        public async Task< int> GetAmount(int id)
        {
            try { 
            return await IGiftService.GetAmount(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("amountCard/{amount}")]
        public async Task< List<Gifts>> FindGiftByAmountCards(int amount)
        {
            try {
            return await IGiftService.FindGiftByAmountCards(amount);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("nameDonor/{name}")]
        public List<Gifts> FindGiftByNameDonor(string name)
        {
            try { 
            return IGiftService.FindGiftByNameDonor(name);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [HttpGet("name/{name}")]
        public List<Gifts> FindGiftByName(string name)
        {
            try {
            return IGiftService.FindGiftByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    [HttpGet("isRandom")]
    public async Task<bool> isWasRandom()
    {
      try
      {
        return await IGiftService.isWasRandom();
      }
      catch (Exception ex)
      {
        throw new Exception();
      }
    }

    [HttpPost("uploadGiftImage")]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UploadGiftImage(IFormFile file, int giftId)
    {
      try { 
      return await IGiftService.UploadGiftImage(file, giftId);}
        catch (Exception ex)
      {
        throw new Exception();
      }
    }
  }
}
