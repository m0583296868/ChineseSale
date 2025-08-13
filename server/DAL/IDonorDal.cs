using MSMA.Models;
using MSMA.Models.DTO;
using System.Collections.Generic;

namespace MSMA.DAL
{
    public interface IDonorDal
    {
        Task Add(DonorsDTO contact);

        Task Update(int id, DonorsDTO contactDTO);

        Task Remove(int id);

        Task<Donors> Get(int id);

        Task< List<Gifts> >GetGifts(int id);

        Task< List<Donors>> Get();
        Task<Donors> FindDonorByGift( int id);
        List< Donors> FindDonorByName(string cont);
        Donors FindDonorByMail(string cont);


    }
}

