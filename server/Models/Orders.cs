using System.ComponentModel;

namespace MSMA.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public Users User { get; set; }

        [DefaultValue(true)]
        public bool isTyuya { get; set; } = true;
    }
}
