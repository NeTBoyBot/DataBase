using System.ComponentModel.DataAnnotations;

namespace PhoenixElo
{
    public class Motorcycle
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int MaxSpeed { get; set; }
    }
}
