using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects.Classes
{
    public class Rental
    {

        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal DepositSum { get; set; }
        public decimal Price 
        { 
            get 
            {
                if(Car != null)
                {
                    int durationInDays = (EndDate - StartDate).Days;

                    decimal coef = (Car.YearOfManufacture - 1990) / 200.0M * durationInDays;

                    var dict = new Dictionary<CarModel, decimal>()
                    {
                        {CarModel.Skoda, 1.2M },
                        {CarModel.Mazda, 1.3M },
                        {CarModel.Hyundai, 1.5M },
                        {CarModel.Audi, 2M },
                        {CarModel.Chevrolet, 1.1M },
                        {CarModel.Nissan, 1.9M },
                        {CarModel.Volkswagen, 1M },
                    };

                    return coef * dict[Car.Model];
                }

                return 0;
            }
        }

        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public Car? Car { get; set; }
        public override string ToString()
        {
            return $"Прокат з {StartDate:d} до {EndDate:d}";
        }
    }
}
