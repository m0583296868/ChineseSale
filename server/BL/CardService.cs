using MSMA.DAL;
using MSMA.Models;
using MSMA.Models.DTO;
using System.Collections.Generic;

namespace MSMA.BL
{
    public class CardService : ICardService
    {
        private readonly ICardDal cardDal;

        public CardService(ICardDal cardDal)
        {
            this.cardDal = cardDal;
        }
        public async Task<bool> Add(CardsDTO c)
        {
          return await cardDal.Add(c);
        }


        public async Task< Cards >Get(int id)
        {
            return await cardDal.Get(id);
        }

        public async Task<List<Cards>> Get()
        {

            return await cardDal.Get();
        }

        public async Task Remove(int id)
        {
           await cardDal.Remove(id);
        }

        public void Update(int id, CardsDTO contactDTO)
        {
            cardDal.Update(id, contactDTO);
        }
         public async Task< List<Cards>> GetBySort(int type)
         {
             return await cardDal.GetBySort(type);          
         }
         public async Task< List<Cards>> GetGift(int id)
         {
             return await cardDal.GetGift(id);
         }
         public async Task< List<Users>> GetCustomers()
         {
             return await cardDal.GetCustomers();
         }

        public async Task<string >TheRandom(int idGift)
        {
            return await cardDal.TheRandom(idGift);
        }
        public async Task<int >Benefits()
        {
            return await cardDal.Benefits();
        }
       public async Task< List<Object>> Getgeters(){
            List<Object> c = new List<Object>();
            c =await cardDal.Getgeters();
            return c;
       }
       public async Task<List<Cards>> GetMyCard(int id)
       {
        return await cardDal.GetMyCard(id);
       }
    }
}
