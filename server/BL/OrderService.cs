using MSMA.DAL;
using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.BL
{
    public class OrderService : IOrderService
    {
        private readonly IOrderDal iGiftDal;

        public OrderService(IOrderDal iOrderDal)
        {
            iGiftDal = iOrderDal;
        }
        public async Task< int> Add(int er)
        {
            return await iGiftDal.Add(er);
        }

        public async Task<Orders> Get(int id)
        {
             return await iGiftDal.Get(id);
        }

        public async Task <List<Orders>> Get()
        {
            return await iGiftDal.Get();
        }

        public void Remove(int id)
        {
              iGiftDal.Remove(id);
        }

        public void Update(int id, Orders contactDTO)
        {
            iGiftDal.Update(id, contactDTO);
        }
        public async Task saveOrder(int id)
        {
           await iGiftDal.saveOrder(id);
        }
    }
}
