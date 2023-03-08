using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects.TempClasses
{
    public class TempClassForDecart
    {
        public int PaymentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Sum { get; set; }
    }
    public class TempClassForInnerJoin
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public decimal Sum { get; set; }
    }

    public class TempClassForJoin
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Year { get; set; }
    }
    public class TempClassForGroupJoin
    {
        public CarModel Model { get; set; }
        public IEnumerable<Rental>? Rentals { get; set; }
    }
    public class TempClassForPaymentsInDate
    {
        public int PaymentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }
    }
    public class CarCustomer
    {
        public Car? Car { get; set; }
        public Customer? Customer { get; set; }
    }
    public class TempClassForCarsOneColor
    {
        public CarBodyColor Color { get; set; }
        public int Count { get; set; }
    }
}
