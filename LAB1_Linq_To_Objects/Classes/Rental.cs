using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects.Classes
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DepositSum { get; set; } 
        public decimal Price { get; set; }

        public int CustomerId { get; set; }
        public int CarId { get; set; }

        public override string ToString()
        {
            return $"Прокат з {StartDate:d} до {EndDate:d}";
        }
    }
}
