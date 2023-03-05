using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects.Classes
{
    class Payment
    {
        public int Id { get; set; }
        public PaymentType Type { get; set; }
        public decimal Sum { get; set; }
        public DateTime Date { get; set; }
        
        public Rental Rental { get; set; }

        public override string ToString()
        {
            return $"Цей платiж коштує: {Sum}$";
        }
    }
}
