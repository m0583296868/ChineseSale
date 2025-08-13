using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.BL
{
    public interface IOrderService
    {
        Task< int> Add(int er);
        void Update(int id, Orders contactDTO);
        void Remove(int id);
        Task <Orders> Get(int id);
        Task< List<Orders>> Get();
        Task saveOrder(int id);
    }
}
