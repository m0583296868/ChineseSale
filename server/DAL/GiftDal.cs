using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.DAL
{
    public class GiftDal:IGiftDal
    {
        private readonly MsDBContext msDBContext;
        private readonly IMapper mapper;

        public GiftDal(MsDBContext MsDBContext,IMapper mapper)
        {
            msDBContext = MsDBContext;
            this.mapper = mapper;
        }
        public async Task<Gifts> Add(GiftsDTO gift)
        {
            try
            {


                var g1 = mapper.Map<Gifts>(gift);
                
               await msDBContext.gifts.AddAsync(g1);
               await msDBContext.SaveChangesAsync();
        return g1;
            }
            catch (Exception e)                   
            {
                throw new Exception();
            }


        }

        public async Task< Gifts> Get(int id)
        {
            try
            {
                Gifts c =await msDBContext.gifts.FirstOrDefaultAsync(c => c.Id == id);

                return c;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        public async Task< Donors> GetDonor(int id)
        {
            var g =await Get(id);
            var d =await msDBContext.donors.FirstOrDefaultAsync(dd => dd.Id == g.DonorId);
            return d;
        }

    //public List<Gifts> FindGiftByName(string name)
    //{
    //    try
    //    {
    //        var c = (from cc in msDBContext.gifts
    //                 where cc.Name == name
    //                 select cc).ToList();

    //        return c;
    //    }
    //    catch (Exception e)
    //    {
    //        throw new Exception();
    //    }
    //}
    public List<Gifts> FindGiftByName(string name)
    {
      try
      {
        var c = (from cc in msDBContext.gifts
                 where cc.Category == name
                 select cc).ToList();

        return c;
      }
      catch (Exception e)
      {
        throw new Exception();
      }
    }

    public List<Gifts> FindGiftByNameDonor(string name)
        {
            var d = (from dd in msDBContext.donors
                     where dd.Name == name
                     select dd).ToList();

            List<Gifts> g = new List<Gifts>();
            foreach (var dd in d)
            {
                var newG = (from gg in msDBContext.gifts
                            where gg.DonorId == dd.Id
                            select gg).ToList();
                foreach (var item in newG) g.Add(item);
               
            }
            return g;

        }

        public async Task <List<Gifts> >FindGiftByAmountCards(int amount)
        {
            List<Gifts> g = new List<Gifts>();
            
            var c =await Get();
            foreach (var item in c)
            {
                if (await GetAmount(item.Id) == amount)
                    g.Add(item);
            }
            return g;
        }
            public async Task <List<Gifts> >Get()
        {
            try
            {
                return await msDBContext.gifts.ToListAsync();


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
                var d = msDBContext.gifts.FirstOrDefault(c => c.Id == id);
                msDBContext.gifts.Remove(d);
                msDBContext.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception();
            }

        }


        public async Task< int> GetAmount(int id)
        {
            
            var c = (from gg in msDBContext.cards
                     where gg.GiftId == id
                     select gg).ToList();
            return c.Count;
        }

        public async Task Update(int id, GiftsDTO contactDTO)
        {
            try
            {
                var d =await Get(id);
                Gifts g = mapper.Map<Gifts>(contactDTO);
                g.Id = id;
                msDBContext.gifts.Entry(d).CurrentValues.SetValues(g);
               await msDBContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        ////////////
        ///לקוח
        ////////////
        public async Task< List<Gifts>> FindGiftByCost(int cost)//jgfj
        {
            List<Gifts> g = new List<Gifts>();

            var c =await Get();
            foreach (var item in c)
            {
                if (item.Cost == cost)
                    g.Add(item);
            }
            return g;
        }


        public async Task< List<Gifts> >FindGiftByCategory(string  cat)//hfjhjhjhghjhjbjuhgjhkk
        {
            List<Gifts> g = new List<Gifts>();

            var c =await Get();
            foreach (var item in c)
            {
                if (item.Category == cat)
                    g.Add(item);
            }
            return g;
        }

    public async Task<bool>isWasRandom()
    {
      var c = await Get();
      foreach (var item in c)
      {
        if (item.IdGeter == 0)
          return false;
      }
      return true;
    }


  }
}


