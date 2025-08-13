using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.DAL
{
    public interface IUserDal
    {
        Task Add(UsersDTO contact);

        void Update(int id, UsersDTO contactDTO);

        void Remove(int id);
        Task< Users >Get(int id);


       Task< List<Users>> Get();
    }
}
