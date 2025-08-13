using MSMA.Models.DTO;
using MSMA.Models;

namespace MSMA.DAL
{
    public interface IOrderDal
    {
        Task<int> Add(int er);
        Task Update(int id, Orders contactDTO);
        void Remove(int id);
        Task <Orders> Get(int id);
        Task<List<Orders>> Get();
        Task saveOrder(int id);
    }
}
