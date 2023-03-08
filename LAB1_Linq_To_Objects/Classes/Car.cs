using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects.Classes
{
    public class Car
    {
        public int Id { get; set; }
        public CarModel Model { get; set; }
        public int YearOfManufacture { get; set; }
        public CarType Type { get; set; }
        public CarBodyColor Color { get; set; }
        public decimal Mileage { get; set; }

        public override string ToString()
        {
            return $"Це машина моделi {Model}, що зроблена в {YearOfManufacture}.";
        }
    }
}
