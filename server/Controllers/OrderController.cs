using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MSMA.BL;
using MSMA.Models;
using MSMA.Models.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MSMA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService IOrderService;

        public OrderController(IOrderService iOrderService)
        {
            IOrderService = iOrderService;
        }

        // GET: api/<OrderController>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task< List<Orders> >Get()
        {
            try { 
              return await IOrderService.Get();
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        // GET api/<OrderController>/5
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<Orders> Get(int id)
        {
            try {
           return await IOrderService.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        // POST api/<OrderController>
       [Authorize(Roles = "User")]
        [HttpPost]
        public async Task< int >Post(int value)
        {
            try { 
                return await IOrderService.Add(value);
            }


            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        [Authorize(Roles = "Admin")]
        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Orders value)
        {
            try { 
            IOrderService.Update(id,value);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        // DELETE api/<OrderController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try { 
            IOrderService.Remove(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
       [Authorize(Roles = "User")] 
        [HttpPut("save/{id}")]
        public async Task saveOrder(int id)
        {
            try {
           await IOrderService.saveOrder(id);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

    }
}
