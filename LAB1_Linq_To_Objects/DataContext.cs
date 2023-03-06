using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects
{
    class DataContext
    {
        public static ICollection<Car> Cars = new List<Car>()
        {
            new Car(){
                 Id = 1,
                 Color = CarBodyColor.Violet,
                 Mileage = 30000,
                 Model = CarModel.Volkswagen,
                 Type = CarType.PassengerCar,
                 YearOfManufacture = 2001,
            },
            new Car(){
                Id = 2,
                Color = CarBodyColor.Red,
                Mileage = 300000,
                Model = CarModel.Audi,
                Type = CarType.Bus,
                YearOfManufacture = 1990,
            },
            new Car(){
                Id = 3,
                Color = CarBodyColor.Red,
                Mileage = 0,
                Model = CarModel.Chevrolet,
                Type = CarType.PassengerCar,
                YearOfManufacture = 2022,
            },
        };
        public static ICollection<Customer> Customers = new List<Customer>()
        {
            new Customer(){ Id = 1, Address = "Небесної Сотнi, 48А", Name = "Василенко Гаврило Петрович",
                    PhoneNumber = "0964021250" },
            new Customer(){ Id = 2, Address = "Свободи, 98Б", Name = "Гавриленко Василина Романiвна",
                    PhoneNumber = "0973242351"},
            new Customer(){ Id = 3, Address = "Кiнцева, 3", Name = "Король Юрiй Георгiйович",
                    PhoneNumber = "0985325236"},
            new Customer(){ Id = 4, Address = "Кiнцева, 3", Name = "Кiрiєнко Борислав Андрiйович",
                    PhoneNumber = "0684325724"},
        };

        public static ICollection<Rental> Rentals = new List<Rental>()
        {
            new Rental() { Id = 1, StartDate = new DateTime(2022, 06, 24), EndDate = new DateTime(2023, 01, 24), DepositSum = 500000M,
                Car_Id = 1, Customer_Id = 1 },
            new Rental() { Id = 2, StartDate = new DateTime(2022, 07, 01), EndDate = new DateTime(2023, 01, 01), DepositSum = 600000M,
                Car_Id = 1, Customer_Id = 1 },
            new Rental() { Id = 3, StartDate = new DateTime(2022, 11, 24), EndDate = new DateTime(2022, 12, 24), DepositSum = 100000M,
                Car_Id = 1, Customer_Id = 1 },
            new Rental() { Id = 4, StartDate = new DateTime(2023, 01, 15), EndDate = new DateTime(2023, 01, 20), DepositSum = 15000M,
                Car_Id = 1, Customer_Id = 1 },
            new Rental() { Id = 5, StartDate = new DateTime(2022, 01, 01), EndDate = new DateTime(2023, 03, 01), DepositSum = 1500000M,
                Car_Id = 1, Customer_Id = 1 },
            new Rental() { Id = 6, StartDate = new DateTime(2022, 06, 24), EndDate = new DateTime(2023, 01, 24), DepositSum = 500000M,
               Car_Id = 2, Customer_Id = 2 },
            new Rental() { Id = 7, StartDate = new DateTime(2022, 11, 24), EndDate = new DateTime(2022, 12, 24), DepositSum = 100000M,
                Car_Id = 2, Customer_Id = 2 },
            new Rental() { Id = 8, StartDate = new DateTime(2022, 01, 01), EndDate = new DateTime(2022, 03, 01), DepositSum = 1000000M,
                Car_Id = 2, Customer_Id = 2 },
            new Rental() { Id = 9, StartDate = new DateTime(2022, 06, 24), EndDate = new DateTime(2023, 01, 24), DepositSum = 500000M,
                Car_Id = 3, Customer_Id = 3 },
            new Rental() { Id = 10, StartDate = new DateTime(2022, 11, 24), EndDate = new DateTime(2022, 12, 24), DepositSum = 100000M,
                Car_Id = 3, Customer_Id = 4 },
        };

        public static ICollection<Payment> Payments = new List<Payment>()
        {
            new Payment() { Id = 1, Type = PaymentType.Outpost, Date = new DateTime(2022, 06, 24), Sum = 500000M, Rental_Id = 1},
            new Payment() { Id = 2, Type = PaymentType.Outpost, Date = new DateTime(2022, 07, 01), Sum = 600000M, Rental_Id = 2},
            new Payment() { Id = 3, Type = PaymentType.Payout, Date = new DateTime(2022, 11, 24), Sum = 50000M, Rental_Id = 3},
            new Payment() { Id = 4, Type = PaymentType.Payout, Date = new DateTime(2022, 12, 24), Sum = 50000M, Rental_Id = 3},
            new Payment() { Id = 5, Type = PaymentType.Outpost, Date = new DateTime(2023, 01, 15), Sum = 15000M, Rental_Id = 4},
            new Payment() { Id = 6, Type = PaymentType.Payout, Date = new DateTime(2022, 01, 01), Sum = 200000M, Rental_Id = 5},
            new Payment() { Id = 7, Type = PaymentType.Payout, Date = new DateTime(2022, 04, 01), Sum = 300000M, Rental_Id = 5},
            new Payment() { Id = 8, Type = PaymentType.Payout, Date = new DateTime(2022, 07, 01), Sum = 500000M, Rental_Id = 5},
            new Payment() { Id = 9, Type = PaymentType.Payout, Date = new DateTime(2022, 10, 01), Sum = 500000M, Rental_Id = 5},
            new Payment() { Id = 10, Type = PaymentType.Outpost, Date = new DateTime(2022, 06, 24), Sum = 500000M, Rental_Id = 6},
            new Payment() { Id = 11, Type = PaymentType.Payout, Date = new DateTime(2022, 11, 24), Sum = 50000M, Rental_Id = 7},
            new Payment() { Id = 12, Type = PaymentType.Payout, Date = new DateTime(2022, 12, 24), Sum = 50000M, Rental_Id = 7},
            new Payment() { Id = 13, Type = PaymentType.Payout, Date = new DateTime(2022, 01, 01), Sum = 200000M, Rental_Id = 8},
            new Payment() { Id = 14, Type = PaymentType.Payout, Date = new DateTime(2022, 04, 01), Sum = 300000M, Rental_Id = 8},
            new Payment() { Id = 15, Type = PaymentType.Payout, Date = new DateTime(2022, 07, 01), Sum = 500000M, Rental_Id = 8},
            new Payment() { Id = 16, Type = PaymentType.Outpost, Date = new DateTime(2022, 06, 24), Sum = 500000M, Rental_Id = 9},
            new Payment() { Id = 17, Type = PaymentType.Outpost, Date = new DateTime(2022, 11, 24), Sum = 50000M, Rental_Id = 10}
        };


    }
}
