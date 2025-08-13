namespace MSMA.Models
{
    public class Gifts
    {
        public int Id { get; set; }

        public string Category { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public IEnumerable<Cards> Cards { get; set; }
        public int IdGeter { get; set; }
        public int DonorId { get; set; }      
        public Donors Donor { get; set; }
        public string Img { get; set; }


    }
}
