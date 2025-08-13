using MSMA.Models;
using Microsoft.EntityFrameworkCore;
using MSMA.Models.DTO;
using AutoMapper;
using System.Drawing;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Collections.Generic;


namespace MSMA.DAL
{
    public delegate Task < bool> GreatGift(Cards g, Cards g1);

    public class CardDal : ICardDal
    {
        private readonly MsDBContext msDBContext;
        private readonly IMapper mapper;
        private readonly IGiftDal giftDal;
        private readonly IUserDal userDal;
        private readonly IOrderDal orderDal;

        public CardDal(MsDBContext MsDBContext, IMapper mapper, IGiftDal giftDal,IUserDal userDal,IOrderDal orderDal)
        {
            msDBContext = MsDBContext;
            this.mapper = mapper;
            this.giftDal = giftDal;
            this.userDal = userDal;
            this.orderDal = orderDal;
        }

        public async Task<bool> Add(CardsDTO c)
        {
            try
            {
              var gg =await giftDal.Get(c.GiftId);

        if (gg.IdGeter != 0)
          return false;
             
        var c1 = mapper.Map<Cards>(c);
                await msDBContext.cards.AddAsync(c1);
                await msDBContext.SaveChangesAsync();
        return true;
            }

            catch (Exception e)
            {
                throw new Exception();
            }


        }
        async Task<bool> CompareCost(Cards g1, Cards g2)
        {
            Gifts gg1 =await giftDal.Get(g1.GiftId);
            Gifts gg2 =await giftDal.Get(g2.GiftId);

            return gg1.Cost < gg2.Cost;
        }
    async Task<bool> CompareAmount(Cards g1, Cards g2)
        {
            return await giftDal.GetAmount(g1.GiftId) <await giftDal.GetAmount(g2.GiftId);
        }
        public async Task Sort(List<Cards> g, GreatGift greatGift)
        {

            Cards tmp;
            for (int i = 0; i < g.Count - 1; i++)
            {
                for (int j = i + 1; j < g.Count; j++)
                {
                    if (await greatGift(g[i], g[j]))
                    {
                        tmp = g[i];
                        g[i] = g[j];
                        g[j] = tmp;
                    }

                }
            }
        }

        public async Task<List<Cards>> GetBySort(int type)
        {
            List<Cards> d = new List<Cards>();

           d =await Get();
            switch (type)
            {
                case 1:
                   await  Sort (d, CompareCost); break;
                case 2:
          await Sort(d, CompareAmount); break;
                default:
                    return null;

            }
            return d;
        }
        public async Task<Cards> Get(int id)
        {
            try
            {
           
                Cards c =await msDBContext.cards.FirstOrDefaultAsync(c => c.Id == id);

                return c;
            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }

        public async Task <List<Cards> >Get()
        {
           
            try
            {
                var c =await (from cc in msDBContext.cards
                         join oo in msDBContext.orders
                         on cc.OrderId equals oo.Id
                         where oo.isTyuya==false
                         select cc).ToListAsync();
                return c;


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
                var a =await Get(id);
                var o = await orderDal.Get(a.OrderId);
                if (o.isTyuya==true)
                msDBContext.cards.Remove(a);
        await msDBContext.SaveChangesAsync();
      }
            catch (Exception e)
            {
                throw new Exception();
            }

        }

        public async Task Update(int id, CardsDTO contactDTO)
        {
            try
            {

                var d = await Get(id);
                Cards d1 = mapper.Map<Cards>(contactDTO);
                d1.Id = id;

                 msDBContext.cards.Entry(d).CurrentValues.SetValues(d1);
               await  msDBContext.SaveChangesAsync();

            }
            catch (Exception e)
            {
                throw new Exception();
            }
        }
        public async Task<List<Cards>> GetGift(int id)
        {
            var c =await (from cc in msDBContext.cards
                     where cc.GiftId == id
                     select cc).ToListAsync();
            return c;
        }
        public async Task<List<Users>> GetCustomers()
        {
            var list = await (from f in msDBContext.cards
                        join u in msDBContext.users
                      on f.UserId equals u.Id
                         select  u ).ToListAsync();
            return list;
        }

        public async Task <string> TheRandom(int idGift)
        {

            List<Cards> cards = new List<Cards>();
            cards =await GetGift(idGift);
      if (cards.Count > 0) { 
            int i = Random.Shared.Next(0, cards.Count - 1);
            Gifts gift = new Gifts();
            gift =await giftDal.Get(idGift);
            gift.IdGeter = cards[i].UserId;
            GiftsDTO g = mapper.Map<GiftsDTO>(gift);
           await giftDal.Update(idGift, g);
            Users u = new Users();
            u =await userDal.Get(cards[i].UserId);
     
        return u.Name;}
      else
        return "";
        }
        public async Task< List<Object>> Getgeters()
        {


            List<Object> cards = new List<Object>();
            List<Gifts> gifts = new List<Gifts>();
            gifts =await giftDal.Get();
            Users u = new Users();
            foreach (var item in gifts)
            {
                if (item.IdGeter != 0)
                {
                    u = await userDal.Get(item.IdGeter);
                    cards.Add(item);
                    cards.Add(u);

                }
            }
            return cards;
        }



        public async Task< int> Benefits() { 
            int ben = 0;
            var cards = await Get();
            foreach (var item in cards)
            {
                int x = item.Amount;
                var gift =await giftDal.Get(item.GiftId);
                int y = gift.Cost;
                int z = x * y;
                ben += z;
            }
            
            return ben;
        }

    ////////////////
    ///

    public async Task<List<Cards>> GetMyCard(int id)
    {
      var c = await(from cc in msDBContext.cards
                    where cc.UserId== id
                    join oo in msDBContext.orders
                      on cc.OrderId equals oo.Id
                      where oo.isTyuya == true //&&cc.UserId== id
                    select cc).ToListAsync();
      return c;
    }
    //את רואה טוב ויכולה להקליד?


  }


}

