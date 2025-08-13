using Microsoft.AspNetCore.Mvc;
using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.BL
{
    public interface IUserService
    {
        Task Add(UsersDTO contact);
        void Update(int id, UsersDTO contactDTO);
        void Remove(int id);
        Task< Users> Get(int id);
        Task< resUser >Login(string username, string password);
        Task< List<Users>> Get();
    }
}
