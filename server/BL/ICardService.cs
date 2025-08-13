using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.BL
{
    public interface ICardService
    {
        Task <bool> Add(CardsDTO contact);

        void Update(int id, CardsDTO contactDTO);

        Task Remove(int id);
        Task<Cards> Get(int id);
        Task<int>Benefits();
        Task<  List<Object>> Getgeters();
        Task< List<Cards>> GetBySort(int type);
        Task< List<Cards>> GetGift(int id);
        Task< List<Users> >GetCustomers();
        Task< string> TheRandom(int idGift);
        Task<List<Cards>>Get();
        Task<List<Cards>> GetMyCard(int id);
    }
}
