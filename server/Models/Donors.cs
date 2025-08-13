namespace MSMA.Models
{
    public class Donors
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public List<Gifts> Gifts { get; set; }
  
    }
}
