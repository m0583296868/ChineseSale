using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MSMA.BL;
using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.DAL
{
    public class UserDal:IUserDal
    {
        private readonly MsDBContext msDBContext;
        private readonly IMapper mapper;

        public UserDal(MsDBContext MsDBContext,IMapper mapper)
        {
            msDBContext = MsDBContext;
            this.mapper = mapper;
        }
        public async Task Add(UsersDTO d)
        {
            try
            {
                var u1 = mapper.Map<Users>(d);
                u1.Role = "User";
                await msDBContext.users.AddAsync(u1);
                await  msDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception();
            }


        }

        public async Task< Users> Get(int id)
        {
            try
            {
                Users c =await msDBContext.users.FirstOrDefaultAsync(c => c.Id == id);

                return c;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public async Task <List<Users> >Get()
        {
            try
            {
                return await msDBContext.users.ToListAsync();


            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public void Remove(int id)
        {

            try
            {
                var d = msDBContext.users.FirstOrDefault(c => c.Id == id);
                msDBContext.users.Remove(d);
                msDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public async void Update(int id, UsersDTO contactDTO)
        {
            try
            {
                var d =await Get(id);
                var u1 = mapper.Map<Users>(contactDTO);
                u1.Id = id;

                msDBContext.users.Entry(d).CurrentValues.SetValues(u1);
                msDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

   
    }
}


