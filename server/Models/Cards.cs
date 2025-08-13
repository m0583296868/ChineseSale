namespace MSMA.Models
{
    public class Cards
    {
        public int Id { get; set; }
        public Gifts Gift { get; set; }
        public Users User { get; set; }
      
        public int Amount { get; set; }
        public int GiftId { get; set; }
        public int UserId { get; set; }
        public int OrderId { get; set; }
        //public Orders Order { get; set; }

    }
}
