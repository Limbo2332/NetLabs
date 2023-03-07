using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;
using System.Linq;

namespace LAB1_Linq_To_Objects
{
    class DataService : IDataService
    {
        private IDataContext _dataContext;
        public DataService(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var q1 = from c in _dataContext.Customers
                     select c;

            return q1;
        }

        public IEnumerable<Car> GetCarsAfter(int year = 2010)
        {
            var q2 = from c in _dataContext.Cars
                     where c.YearOfManufacture > year
                     select c;
            return q2;
        }

        public IEnumerable<IGrouping<CarModel, Car>> GroupCarsByModel()
        {
            var q3 = from c in _dataContext.Cars
                     group c by c.Model;

            return q3;
        }

        public IEnumerable<Car> SortCarsByMileage()
        {
            var q4 = from c in _dataContext.Cars
                     orderby c.Mileage, c.YearOfManufacture
                     select c;
            return q4;
        }

        public IEnumerable<Rental> FindAllRentalsIn(int year = 2022)
        {
            var q5 = from r in _dataContext.Rentals
                     where r.StartDate.Year == year
                     orderby r.StartDate, r.EndDate
                     select r;
            return q5;
        }

        public IEnumerable<TempClassForDecart> DecartMultiply()
        {
            var q6 = from r in _dataContext.Rentals
                     from p in _dataContext.Payments
                     select new TempClassForDecart{ StartDate = r.StartDate, EndDate = r.EndDate, Sum = p.Sum };

            return q6;
        }

        public IEnumerable<TempClassForInnerJoin> InnerJoin()
        {
            var q7 = from c in _dataContext.Customers
                     from r in _dataContext.Rentals
                     where r.CustomerId == c.Id
                     select new TempClassForInnerJoin
                     {
                         Name = c.Name,
                         Sum = r.DepositSum
                     };
            return q7;
        }

        public decimal SumMoney()
        {
            var q8 = _dataContext.Payments.Sum(x => x.Sum);
            return q8;
        }

        public IEnumerable<Customer> UseSkip(int index = 2)
        {
            var q9 = _dataContext.Customers.Skip(index);
            return q9;
        }

        public IEnumerable<TempClassForJoin> UseJoin()
        {
            var q10 = _dataContext.Rentals.Join(_dataContext.Cars, r => r.CarId, c => c.Id,
                (r, c) => new TempClassForJoin{ StartDate = r.StartDate, EndDate = r.EndDate, Year = c.YearOfManufacture });
            return q10;
        }

        public IEnumerable<TempClassForGroupJoin> UseGroupJoin()
        {
            var q11 = _dataContext.Cars.GroupJoin(_dataContext.Rentals, c => c.Id, r => r.CarId, (c, rentals) => 
            new TempClassForGroupJoin
            {
                Model = c.Model,
                Rentals = rentals
            });
            return q11;
        }
        public IEnumerable<Car> UseConcatAndDitinct(CarModel model = CarModel.Volkswagen, decimal mileage = 20000) 
        {
            var q12 = _dataContext.Cars.Where(c => c.Model == model)
                            .Concat(_dataContext.Cars.Where(c => c.Mileage > mileage)).Distinct();
            return q12;
        }

        public bool UseAll()
        {
            var q13 = _dataContext.Cars.All(c => c.YearOfManufacture < 2021);
            return q13;
        }

        public Customer? FirstWithLastNameStartedWith(string name = "Василенко")
        {
            var q14 = _dataContext.Customers.FirstOrDefault(x => x.Name!.StartsWith(name));
            return q14;
        }

        public IEnumerable<TempClassForPaymentsInDate> FindPaymentsInDate()
        {
            var q15 = _dataContext.Payments.Join(_dataContext.Rentals, p => p.RentalId, r => r.Id, (p, r) => 
            new TempClassForPaymentsInDate
            {
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Date = p.Date,
            }).Where(p => p.StartDate < p.Date && p.EndDate > p.Date);
            return q15;
        }

        public IEnumerable<TempClassForOwners> FindOwnerOfCar()
        {
            var q16 = (from rental in _dataContext.Rentals
                      join car in _dataContext.Cars on rental.CarId equals car.Id
                      join customer in _dataContext.Customers on rental.CustomerId equals customer.Id
                      select new TempClassForOwners
                      {
                          Model = car.Model,
                          Color = car.Color,
                          Name = customer.Name,
                      }).Distinct(new AnonimEqualityComparer());

            return q16;
        }

        public double AverageYearOfCars()
        {
            var q17 = _dataContext.Cars.Average(c => c.YearOfManufacture);
            return q17;
        }

        public decimal MaxSum()
        {
            var q18 = _dataContext.Rentals.Max(r => r.DepositSum);
            return q18;
        }

        public IEnumerable<TempClassForCarsOneColor> FindCarOneColor()
        {
            var q19 = _dataContext.Cars.GroupBy(c => c.Color).Select(c => 
                new TempClassForCarsOneColor { Color = c.Key, Count = c.Count() 
            });
            return q19;
        }

        public IEnumerable<Customer> UseSelectMany()
        {
            var q20 = _dataContext.Customers.Reverse();
            return q20;
        }

    }
    public class TempClassForDecart
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Sum { get; set; }
    }
    public class TempClassForInnerJoin
    {
        public string? Name { get; set; }
        public decimal Sum { get; set; }
    }

    public class TempClassForJoin
    {
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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime Date { get; set; }
    }
    public class TempClassForOwners
    {
        public CarModel Model { get; set; }
        public CarBodyColor Color { get; set; }
        public string? Name { get; set; }
    }
    public class TempClassForCarsOneColor
    {
        public CarBodyColor Color { get; set; }
        public int Count { get; set; }
    }
}
