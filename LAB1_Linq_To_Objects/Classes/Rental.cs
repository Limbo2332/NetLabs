namespace LAB1_Linq_To_Objects.Classes
{
    class Rental
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DepositSum { get; set; } 

        public ICollection<Payment> Payments { get; set; }
        public Customer Customer { get; set; }
        public Car Car { get; set; }

        public override string ToString()
        {
            return $"Прокат з {StartDate:d} до {EndDate:d}";
        }
    }
}
