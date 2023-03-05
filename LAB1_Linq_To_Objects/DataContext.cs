using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;

namespace LAB1_Linq_To_Objects
{
    class DataContext
    {
        public static ICollection<Payment> Payments = new List<Payment>()
        {
            new Payment() { Id = 1, Type = PaymentType.Outpost, Date = new DateTime(2022, 06, 24), Sum = 500000M},
            new Payment() { Id = 2, Type = PaymentType.Outpost, Date = new DateTime(2022, 07, 01), Sum = 600000M},
            new Payment() { Id = 3, Type = PaymentType.Payout, Date = new DateTime(2022, 11, 24), Sum = 50000M},
            new Payment() { Id = 4, Type = PaymentType.Payout, Date = new DateTime(2022, 12, 24), Sum = 50000M},
            new Payment() { Id = 5, Type = PaymentType.Outpost, Date = new DateTime(2023, 01, 15), Sum = 15000M},
            new Payment() { Id = 6, Type = PaymentType.Payout, Date = new DateTime(2022, 01, 01), Sum = 200000M},
            new Payment() { Id = 7, Type = PaymentType.Payout, Date = new DateTime(2022, 04, 01), Sum = 300000M},
            new Payment() { Id = 8, Type = PaymentType.Payout, Date = new DateTime(2022, 07, 01), Sum = 500000M},
            new Payment() { Id = 9, Type = PaymentType.Payout, Date = new DateTime(2022, 10, 01), Sum = 500000M},
            new Payment() { Id = 10, Type = PaymentType.Outpost, Date = new DateTime(2022, 06, 24), Sum = 500000M},
            new Payment() { Id = 11, Type = PaymentType.Payout, Date = new DateTime(2022, 11, 24), Sum = 50000M},
            new Payment() { Id = 12, Type = PaymentType.Payout, Date = new DateTime(2022, 12, 24), Sum = 50000M},
            new Payment() { Id = 13, Type = PaymentType.Payout, Date = new DateTime(2022, 01, 01), Sum = 200000M},
            new Payment() { Id = 14, Type = PaymentType.Payout, Date = new DateTime(2022, 04, 01), Sum = 300000M},
            new Payment() { Id = 15, Type = PaymentType.Payout, Date = new DateTime(2022, 07, 01), Sum = 500000M},
            new Payment() { Id = 16, Type = PaymentType.Outpost, Date = new DateTime(2022, 06, 24), Sum = 500000M},
            new Payment() { Id = 17, Type = PaymentType.Outpost, Date = new DateTime(2022, 11, 24), Sum = 50000M}
        };
        public static ICollection<Rental> Rentals = new List<Rental>()
        {
            new Rental() { Id = 1, StartDate = new DateTime(2022, 06, 24), EndDate = new DateTime(2023, 01, 24), DepositSum = 500000M,
                Payments = new List<Payment>(){ Payments.ElementAt(0) } },
            new Rental() { Id = 2, StartDate = new DateTime(2022, 07, 01), EndDate = new DateTime(2023, 01, 01), DepositSum = 600000M,
                Payments = new List<Payment>(){ Payments.ElementAt(1) }},
            new Rental() { Id = 3, StartDate = new DateTime(2022, 11, 24), EndDate = new DateTime(2022, 12, 24), DepositSum = 100000M,
                Payments = new List<Payment>(){ Payments.ElementAt(2), Payments.ElementAt(3) }},
            new Rental() { Id = 4, StartDate = new DateTime(2023, 01, 15), EndDate = new DateTime(2023, 01, 20), DepositSum = 15000M,
                Payments = new List<Payment>(){ Payments.ElementAt(4)}},
            new Rental() { Id = 5, StartDate = new DateTime(2022, 01, 01), EndDate = new DateTime(2023, 03, 01), DepositSum = 1500000M,
                Payments = new List<Payment>(){ Payments.ElementAt(5), Payments.ElementAt(6), Payments.ElementAt(7), Payments.ElementAt(8) }},
            new Rental() { Id = 6, StartDate = new DateTime(2022, 06, 24), EndDate = new DateTime(2023, 01, 24), DepositSum = 500000M,
                Payments = new List<Payment>(){ Payments.ElementAt(9)}},
            new Rental() { Id = 7, StartDate = new DateTime(2022, 11, 24), EndDate = new DateTime(2022, 12, 24), DepositSum = 100000M,
                Payments = new List<Payment>(){ Payments.ElementAt(10), Payments.ElementAt(11)}},
            new Rental() { Id = 8, StartDate = new DateTime(2022, 01, 01), EndDate = new DateTime(2022, 03, 01), DepositSum = 1000000M,
                Payments = new List<Payment>(){ Payments.ElementAt(12), Payments.ElementAt(13), Payments.ElementAt(14)}},
            new Rental() { Id = 9, StartDate = new DateTime(2022, 06, 24), EndDate = new DateTime(2023, 01, 24), DepositSum = 500000M,
                Payments = new List<Payment>(){ Payments.ElementAt(15)}},
            new Rental() { Id = 10, StartDate = new DateTime(2022, 11, 24), EndDate = new DateTime(2022, 12, 24), DepositSum = 100000M,
                Payments = new List<Payment>(){ Payments.ElementAt(16)}}
        };
        public static ICollection<Car> Cars = new List<Car>()
        {
            new Car(){
                 Id = 1,
                 Color = CarBodyColor.Violet,
                 Mileage = 30000,
                 Model = CarModel.Volkswagen,
                 Type = CarType.PassengerCar,
                 YearOfManufacture = 2001,
                 Rentals = new List<Rental>() 
                 {
                    Rentals.ElementAt(0), Rentals.ElementAt(1), Rentals.ElementAt(2), Rentals.ElementAt(3), Rentals.ElementAt(4),
                 }
            },
            new Car(){
                Id = 2,
                Color = CarBodyColor.Red,
                Mileage = 300000,
                Model = CarModel.Audi,
                Type = CarType.Bus,
                YearOfManufacture = 1990,
                Rentals = new List<Rental>()
                {
                    Rentals.ElementAt(5), Rentals.ElementAt(6), Rentals.ElementAt(7),
                }
            },
            new Car(){
                Id = 3,
                Color = CarBodyColor.Red,
                Mileage = 0,
                Model = CarModel.Chevrolet,
                Type = CarType.PassengerCar,
                YearOfManufacture = 2022,
                Rentals = new List<Rental>()
                {
                    Rentals.ElementAt(8), Rentals.ElementAt(9)
                }
            },
        };
        public static ICollection<Customer> Customers = new List<Customer>()
        {
            new Customer(){ Id = 1, Address = "Небесної Сотнi, 48А", Name = "Василенко Гаврило Петрович",
                    PhoneNumber = "0964021250", Rentals = new List<Rental>()
                    {
                        Rentals.ElementAt(0), Rentals.ElementAt(1), Rentals.ElementAt(2), Rentals.ElementAt(3), Rentals.ElementAt(4),
                    }},
                new Customer(){ Id = 2, Address = "Свободи, 98Б", Name = "Гавриленко Василина Романiвна",
                    PhoneNumber = "0973242351", Rentals = new List<Rental>()
                    {
                        Rentals.ElementAt(5), Rentals.ElementAt(6), Rentals.ElementAt(7),
                    }},
                new Customer(){ Id = 3, Address = "Кiнцева, 3", Name = "Король Юрiй Георгiйович",
                    PhoneNumber = "0985325236", Rentals = new List<Rental>()
                    {
                        Rentals.ElementAt(8), Rentals.ElementAt(9)
                    }},
                new Customer(){ Id = 4, Address = "Кiнцева, 3", Name = "Кiрiєнко Борислав Андрiйович",
                    PhoneNumber = "0684325724", Rentals = new List<Rental>()
                    {
                        Rentals.ElementAt(8), Rentals.ElementAt(9)
                    }},
        };

    }
}
