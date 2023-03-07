using LAB1_Linq_To_Objects.Classes;

namespace LAB1_Linq_To_Objects
{
    interface IDataContext
    {
        IEnumerable<Car> Cars { get; }
        IEnumerable<Customer> Customers { get; }
        IEnumerable<Rental> Rentals { get; }
        IEnumerable<Payment> Payments { get; }

    }
}
