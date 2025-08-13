using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using MSMA.Models;
using MSMA.Models.DTO;
using System.Collections.Generic;

namespace MSMA.DAL
{

    public class DonorDal : IDonorDal
    {
        private readonly MsDBContext msDBContext;
        private readonly IMapper mapper;
        private readonly IGiftDal giftDal;
      
        public DonorDal(MsDBContext MsDBContext,IMapper mapper,IGiftDal giftDal)
        {
            msDBContext = MsDBContext;
            this.mapper = mapper;
            this.giftDal = giftDal;
        }
        public async Task Add(DonorsDTO d)
        {
            try
            {
                var d1 = mapper.Map<Donors>(d);
                await msDBContext.donors.AddAsync(d1);
                await msDBContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception();
            }


        }

        public async Task< Donors >Get(int id)
        {
            try
            {
                Donors c = await msDBContext.donors.FirstOrDefaultAsync(c => c.Id == id);

                return c;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public async Task< List<Donors>> Get()
        {
            try
            {
                var s = await msDBContext.donors.ToListAsync();
                return s;


            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public async Task Remove(int id)
        {

            try
            {
                var d =  await  msDBContext.donors.FirstOrDefaultAsync(c => c.Id == id);
                msDBContext.donors.Remove(d);
                msDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public async Task< List<Gifts>> GetGifts(int id)
        {
            try { 
                 var gifts = await(from g in msDBContext.gifts
                             where g.DonorId == id
                             select g).ToListAsync();

                 return gifts;
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }
        
        public async Task Update(int id, DonorsDTO contactDTO)
        {
            try
            {
                
                var d =await Get(id);
                Donors d1 = mapper.Map<Donors>(contactDTO);
                d1.Id = id;

                msDBContext.donors.Entry(d).CurrentValues.SetValues(d1);
                msDBContext.SaveChanges();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        public async Task< Donors> FindDonorByGift( int content)
        {
            var g =await giftDal.Get(content);
            return await Get(g.DonorId);


        }

        public List<Donors> FindDonorByName(string content)
        {
       
                  var  findDonor = (from dd in msDBContext.donors
                                 where dd.Name ==content
                                 select dd).ToList();
            return findDonor;
        }


        public Donors FindDonorByMail(string content)
        {
            
            var findDonor = msDBContext.donors.FirstOrDefault(c => c.Mail == content);
            return findDonor;

        }
    }
}
