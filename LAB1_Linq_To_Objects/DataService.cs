using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;
using LAB1_Linq_To_Objects.TempClasses;
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
            return from c in _dataContext.Customers
                     select c;
        }

        public IEnumerable<Car> GetCarsAfter(int year = 2010)
        {
            return from c in _dataContext.Cars
                     where c.YearOfManufacture > year
                     select c;
        }

        public IEnumerable<IGrouping<CarModel, Car>> GroupCarsByModel()
        {
            return from c in _dataContext.Cars
                     group c by c.Model;

        }

        public IEnumerable<Car> SortCarsByMileage()
        {
            return from c in _dataContext.Cars
                    orderby c.Mileage, c.YearOfManufacture
                    select c;
        }

        public IEnumerable<Rental> FindAllRentalsIn(int year = 2022)
        {
            return from r in _dataContext.Rentals
                     where r.StartDate.Year == year
                     orderby r.StartDate, r.EndDate
                     select r;
        }

        public IEnumerable<TempClassForDecart> DecartMultiply()
        {
            return from r in _dataContext.Rentals
                     from p in _dataContext.Payments
                     select new TempClassForDecart{ PaymentId = p.Id, StartDate = r.StartDate, EndDate = r.EndDate, Sum = p.Sum };

        }

        public IEnumerable<TempClassForInnerJoin> InnerJoin()
        {
            return from c in _dataContext.Customers
                     from r in _dataContext.Rentals
                     where r.CustomerId == c.Id
                     select new TempClassForInnerJoin
                     {
                         CustomerId = c.Id,
                         Name = c.Name,
                         Sum = r.DepositSum
                     };
        }

        public decimal SumMoney()
        {
            return _dataContext.Payments.Sum(x => x.Sum);
        }

        public IEnumerable<Customer> UseSkip(int index = 2)
        {
            return _dataContext.Customers.Skip(index);
        }

        public IEnumerable<TempClassForJoin> UseJoin()
        {
           return _dataContext.Rentals.Join(_dataContext.Cars, r => r.CarId, c => c.Id,
                (r, c) => 
                new TempClassForJoin{CarId = c.Id,StartDate = r.StartDate, EndDate = r.EndDate, Year = c.YearOfManufacture });
        }

        public IEnumerable<TempClassForGroupJoin> UseGroupJoin()
        {
            return _dataContext.Cars.GroupJoin(_dataContext.Rentals, c => c.Id, r => r.CarId, (c, rentals) => 
            new TempClassForGroupJoin
            {
                Model = c.Model,
                Rentals = rentals
            });
        }
        public IEnumerable<Car> UseConcatAndDitinct(CarModel model = CarModel.Volkswagen, decimal mileage = 20000) 
        {
            return _dataContext.Cars.Where(c => c.Model == model)
                            .Concat(_dataContext.Cars.Where(c => c.Mileage > mileage)).Distinct();
        }

        public bool UseAll(int year = 2021)
        {
            return _dataContext.Cars.All(c => c.YearOfManufacture < year);
        }

        public Customer? FirstWithLastNameStartedWith(string name = "Василенко")
        {
            return _dataContext.Customers.FirstOrDefault(x => x.Name!.StartsWith(name));
        }

        public IEnumerable<TempClassForPaymentsInDate> FindPaymentsInDate()
        {
            return _dataContext.Payments.Join(_dataContext.Rentals, p => p.RentalId, r => r.Id, (p, r) => 
            new TempClassForPaymentsInDate
            {
                PaymentId = p.Id,
                StartDate = r.StartDate,
                EndDate = r.EndDate,
                Date = p.Date,
            }).Where(p => p.StartDate < p.Date && p.EndDate > p.Date);
        }

        public IEnumerable<CarCustomer> FindOwnerOfCar()
        {
            return (from rental in _dataContext.Rentals
                   join car in _dataContext.Cars on rental.CarId equals car.Id
                   join customer in _dataContext.Customers on rental.CustomerId equals customer.Id
                   select new CarCustomer { Car = car, Customer = customer }).Distinct(new CarCustomerEqualityComparer());
        }

        public double AverageYearOfCars()
        {
            return _dataContext.Cars.Average(c => c.YearOfManufacture);
        }

        public decimal MaxSum()
        {
            return _dataContext.Rentals.Max(r => r.DepositSum);
        }

        public IEnumerable<TempClassForCarsOneColor> FindCarOneColor()
        {
            return _dataContext.Cars.GroupBy(c => c.Color).Select(c => 
                new TempClassForCarsOneColor { Color = c.Key, Count = c.Count() 
            });
        }

        public IEnumerable<Customer> UseSelectMany()
        {
            return _dataContext.Customers.Reverse();
        }

    }

}
