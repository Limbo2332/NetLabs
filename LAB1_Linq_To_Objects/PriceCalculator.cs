using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects
{
    class PriceCalculator : IPriceCalculator
    {
        private readonly IDataContext _dataContext;

        public PriceCalculator(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void CalculateSumRental(int carId, int rentalId)
        {
            var car = _dataContext.Cars.Where(x => x.Id == carId).First();
            var rental = _dataContext.Rentals.Where(x => x.Id == rentalId).First();

            int durationInDays = (rental.EndDate - rental.StartDate).Days;

            decimal coef = (car.YearOfManufacture - 1990)/200.0M * durationInDays;

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

            _dataContext.Rentals.Where(x => x.Id == rentalId).First().Price = coef * dict[car.Model];
        }
    }
}
