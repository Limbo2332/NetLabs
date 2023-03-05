using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects.Classes
{
    class Car
    {
        public int Id { get; set; }
        public CarModel Model { get; set; }
        public int YearOfManufacture { get; set; }
        public CarType Type { get; set; }
        public CarBodyColor Color { get; set; }
        public double Mileage { get; set; }

        public ICollection<Rental> Rentals { get; set; }

        public override string ToString()
        {
            return $"Це машина моделi {Model}, що зроблена в {YearOfManufacture}.";
        }
    }
}
