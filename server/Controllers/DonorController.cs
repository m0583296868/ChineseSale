using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMA.BL;
using MSMA.Models;
using MSMA.Models.DTO;
using static System.Net.Mime.MediaTypeNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MSMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService iDonorService;

        public DonorController(IDonorService ICardService)
        {
            iDonorService = ICardService;
        }
        [Authorize(Roles = "Admin")]
        // GET: api/<DonorController>
        [HttpGet]
        public async Task< List<Donors>> Get()
        {
            try { 
            return await iDonorService.Get();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]

        // GET api/<DonorController>/5
        [HttpGet("{id}")]
        public async Task< Donors> Get(int id)
        {
            try { 
            return await iDonorService.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("gifts/{id}")]
        public async Task< List<Gifts>> GetGifts(int id)
        {
            try { 
            return await iDonorService.GetGifts(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("name/{cont}")]
        public List<Donors> FindDonorByName( string cont)
        {
            try {
            return iDonorService.FindDonorByName(cont);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("mail/{cont}")]
        public Donors FindDonorByMail( string cont)
        {
            try { 
            return iDonorService.FindDonorByMail(cont);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("gift/{cont}")]
        public async Task< Donors> FindDonorByGift(int cont)
        {
            try {
            return await iDonorService.FindDonorByGift(cont);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        // POST api/<DonorController>
        [Authorize(Roles = "Admin")]
        

        [HttpPost]
        public async Task Post([FromBody] DonorsDTO value)
        {
            try { 
            await iDonorService.Add(value);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        // PUT api/<DonorController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] DonorsDTO value)
        {
            try { 
            await iDonorService.Update(id,value);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

        }

        // DELETE api/<DonorController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            try { 
            await iDonorService.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
    }
}
