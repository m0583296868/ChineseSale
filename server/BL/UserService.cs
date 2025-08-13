using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MSMA.DAL;
using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.BL
{
    public class UserService:IUserService
    {
        private readonly IUserDal iUserDal;
        private readonly IJwtTokenService jwtTokenService;

        public UserService(IUserDal IUserDal, IJwtTokenService jwtTokenService)
        {
            iUserDal = IUserDal;
            this.jwtTokenService = jwtTokenService;
        }
        public async Task  Add(UsersDTO customer)
        {
          
            List<Users> customers =await iUserDal.Get();
            Users exsistCustomer = customers.FirstOrDefault(u => u.Mail == customer.Mail
                || u.UserName.Equals(customer.UserName));

                if (exsistCustomer != null)
                    return;

            UsersDTO newCustomer = new UsersDTO();
                newCustomer.Name = customer.Name;
                newCustomer.UserName = customer.UserName;
           
                newCustomer.Mail = customer.Mail;
                newCustomer.Phone = customer.Phone;
                newCustomer.Password = BCrypt.Net.BCrypt.HashPassword(customer.Password);
             
             
            await   iUserDal.Add(newCustomer);
      
        }

        public async Task< Users> Get(int id)
        {
            return await iUserDal.Get(id);
        }

        public async Task< List<Users>> Get()
        {

            return await iUserDal.Get();
        }

        public async Task<resUser> Login(string username, string password)
        {
            List<Users> users = await iUserDal.Get();
            Users user = users.FirstOrDefault(c => c.UserName.Equals(username));
            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))

                return null;


            var roles = new List<string>();
            if (user.Role == "Admin")
            {
                roles.Add("Admin");
                roles.Add("User");
            }
            else
                roles.Add("User");

            // Generate JWT Token
            var token =await jwtTokenService.GenerateJwtToken(username, user.Id, roles);
            resUser ru = new resUser();
            ru.UserId=user.Id;
            ru.Role = user.Role;
            ru.Token = token.ToString();
            return ru;
    }

        public void Remove(int id)
        {
            iUserDal.Remove(id);
        }

        public void Update(int id, UsersDTO contactDTO)
        {
            iUserDal.Update(id, contactDTO);
        }

    
  }
}

