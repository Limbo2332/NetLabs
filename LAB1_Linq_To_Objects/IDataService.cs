using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;
using LAB1_Linq_To_Objects.TempClasses;

namespace LAB1_Linq_To_Objects
{
    interface IDataService
    {
        public IEnumerable<Customer> GetCustomers();
        public IEnumerable<Car> GetCarsAfter(int year = 2010);
        public IEnumerable<IGrouping<CarModel, Car>> GroupCarsByModel();
        public IEnumerable<Car> SortCarsByMileage();
        public IEnumerable<Rental> FindAllRentalsIn(int year = 2022);
        public IEnumerable<TempClassForDecart> DecartMultiply();
        public IEnumerable<TempClassForInnerJoin> InnerJoin();
        public decimal SumMoney();
        public IEnumerable<Customer> UseSkip(int index = 2);
        public IEnumerable<TempClassForJoin> UseJoin();
        public IEnumerable<TempClassForGroupJoin> UseGroupJoin();
        public IEnumerable<Car> UseConcatAndDitinct(CarModel model = CarModel.Volkswagen, decimal mileage = 20000);
        public bool UseAll(int year = 2021);
        public Customer? FirstWithLastNameStartedWith(string name = "Василенко");
        public IEnumerable<TempClassForPaymentsInDate> FindPaymentsInDate();
        public IEnumerable<CarCustomer> FindOwnerOfCar();
        public double AverageYearOfCars();
        public decimal MaxSum();
        public IEnumerable<TempClassForCarsOneColor> FindCarOneColor();
        public IEnumerable<Customer> UseSelectMany();

    }
}
