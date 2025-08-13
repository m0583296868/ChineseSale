using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MSMA.DAL;
using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.BL
{
    public class GiftService:IGiftService
    {
        private readonly IGiftDal iGiftDal;
        private readonly string _imagePath = "C://Users//USER//Downloads//proj//msma//src//assets//images";
        public GiftService(IGiftDal IGiftDal)
        {

            iGiftDal = IGiftDal;
      if (!Directory.Exists(_imagePath))
      {
        Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "UploadedImages"));
      }
    }
        public async Task<Gifts> Add(GiftsDTO c)
        {
            return await iGiftDal.Add(c);
        }
        
        public async Task<bool> isWasRandom()
        {
            return await iGiftDal.isWasRandom();
        }
        public async Task< List<Gifts>> FindGiftByAmountCards(int amount)
        {
            return await iGiftDal.FindGiftByAmountCards(amount);
        }
        public List<Gifts> FindGiftByNameDonor(string name)
        {
            return iGiftDal.FindGiftByNameDonor(name);
        }
        public List<Gifts> FindGiftByName(string name)
        {
            return iGiftDal.FindGiftByName(name);
        }
        public async Task< Gifts> Get(int id)
        {
            return await iGiftDal.Get(id);
        }

        public async Task< List<Gifts>> Get()
        {

            return await iGiftDal.Get();
        }
        public async Task< Donors> GetDonor(int id)
        {
            return await iGiftDal.GetDonor(id);
        }
        public void Remove(int id)
        {
            iGiftDal.Remove(id);
        }

        public async Task Update(int id, GiftsDTO contactDTO)
        {
            await iGiftDal.Update(id, contactDTO);
        }
        public async Task< int> GetAmount(int id)
        {
            return await iGiftDal.GetAmount(id);
        }
    
    //upload gift image
        public async Task<IActionResult> UploadGiftImage(IFormFile file, int giftId)
        {
            IEnumerable<Gifts> gifts = await iGiftDal.Get();
            Gifts gift = gifts.FirstOrDefault(g => g.Id == giftId);
            if (gift == null)
              return new BadRequestObjectResult("there is no gift by id: " + giftId);
            if (file == null || file.Length == 0)
              return new BadRequestObjectResult("No file uploaded.");

            // יצירת נתיב ייחודי לקובץ
            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_imagePath, fileName);

            // שמירת הקובץ
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
              await file.CopyToAsync(stream);
            }
            GiftsDTO g = new GiftsDTO();
              g.DonorId = gift.DonorId;
              g.Cost = gift.Cost;
              g.Category = gift.Category;
              g.Img = fileName;
              g.Name = gift.Name;
            // שמירה במסד הנתונים (כאן תוכל לשמור את הנתיב או שם הקובץ)
            //string fileUrl = Path.Combine(_imagePath, fileName);

            await Update(giftId,g);
          


            return new OkObjectResult(g);
        }

  }
}
