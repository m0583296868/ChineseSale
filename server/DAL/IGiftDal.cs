using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.DAL
{
    public interface IGiftDal
    {
        Task <Gifts> Add(GiftsDTO contact);

        Task Update(int id, GiftsDTO contactDTO);

        void Remove(int id);
        Task<  Gifts> Get(int id);
        Task < List<Gifts>> Get();
        Task< Donors> GetDonor(int id);
        Task<bool> isWasRandom();
        Task< int> GetAmount(int id);
        Task< List <Gifts>> FindGiftByAmountCards(int amount);
        List<Gifts> FindGiftByNameDonor(string name);
        List<Gifts> FindGiftByName(string name);
       
    }
}
