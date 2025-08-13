using MSMA.DAL;
using MSMA.Models;
using MSMA.Models.DTO;

namespace MSMA.BL
{
    public class DonorService:IDonorService
    {
        private readonly IDonorDal iDonorDal;

        public DonorService(IDonorDal IDonorDal)
        {
            iDonorDal = IDonorDal;
        }
        public async Task Add(DonorsDTO c)
        {
            await iDonorDal.Add(c);
        }

        public async Task< Donors> Get(int id)
        {
            return await iDonorDal.Get(id);
        }

        public async Task<List<Donors> >Get()
        {

            return await iDonorDal.Get();
        }
        public async Task< List<Gifts> >GetGifts(int id)
        {

            return await iDonorDal.GetGifts(id);
        }

      
        public async Task Remove(int id)
        {
           await iDonorDal.Remove(id);
        }

        public async Task Update(int id, DonorsDTO contactDTO)
        {
            await iDonorDal.Update(id, contactDTO);
        }
        public async Task< Donors> FindDonorByGift(int id)
        {
            return  await iDonorDal.FindDonorByGift( id);
        }
        public List<Donors> FindDonorByName( string cont)
        {
            return iDonorDal.FindDonorByName( cont);

        }
        public Donors FindDonorByMail(string cont)
        {
            return iDonorDal.FindDonorByMail(cont);

        }

    }
}
