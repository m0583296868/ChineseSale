using Microsoft.AspNetCore.Mvc;
using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.BL
{
    public interface IGiftService
    {
       Task<IActionResult> UploadGiftImage(IFormFile file, int giftId);
       Task<Gifts> Add(GiftsDTO contact);
       Task Update(int id, GiftsDTO contactDTO);
       void Remove(int id);
       Task<Gifts> Get(int id);
       Task<Donors> GetDonor(int id);
       Task<bool> isWasRandom();
       Task<List<Gifts>> FindGiftByAmountCards(int amount);
       List<Gifts> FindGiftByNameDonor(string name);
       List<Gifts> FindGiftByName(string name);
       Task < int> GetAmount(int id);
       Task<  List<Gifts> >Get();
    }
}
