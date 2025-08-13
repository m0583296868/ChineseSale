using Microsoft.EntityFrameworkCore;
using MSMA.Models;

namespace MSMA.DAL
{
    public class OrderDal : IOrderDal
    {

        private readonly MsDBContext msDBContext;

        public OrderDal(MsDBContext MsDBContext)
        {
            msDBContext = MsDBContext;
           
        }
        public async Task<int> Add(int id)
        {
                Orders o = new Orders();
                o.userId = id;
                await msDBContext.orders.AddAsync(o);
                await msDBContext.SaveChangesAsync();
                return o.Id;
        }

        public async Task <Orders> Get(int id)
        {
                Orders c =await msDBContext.orders.FirstOrDefaultAsync(c => c.Id == id);

                return c;
        }

        public async Task< List<Orders>> Get()
        {
             return msDBContext.orders.ToList();
        }

        public void Remove(int id)
        {
              var d = msDBContext.orders.FirstOrDefault(c => c.Id == id);

                msDBContext.orders.Remove(d);
                msDBContext.SaveChanges();

        }

        public async Task Update(int id, Orders contactDTO)
        {
                var d = await Get(id);
                var u1 = contactDTO;
                u1.Id = id;

                msDBContext.orders.Entry(d).CurrentValues.SetValues(u1);
                msDBContext.SaveChangesAsync();
        }




        public async Task saveOrder(int id)
        {
            var d =await Get(id);
            if (d!=null)
            {
                var d1 = d;
                d1.isTyuya = false;

                msDBContext.orders.Entry(d).CurrentValues.SetValues(d1);
                await msDBContext.SaveChangesAsync();
            }
            else
              return;
        }


    }
}
