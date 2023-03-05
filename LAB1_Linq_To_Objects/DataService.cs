using LAB1_Linq_To_Objects.Classes;
using LAB1_Linq_To_Objects.Enums;
using System.Linq;

namespace LAB1_Linq_To_Objects
{
    class DataService : IDataService
    {
        public DataService()
        {
            foreach (var rental in DataContext.Rentals)
            {
                foreach (var payment in rental.Payments)
                {
                    payment.Rental = rental;
                }
            }
            foreach (var car in DataContext.Cars)
            {
                foreach (var rental in car.Rentals)
                {
                    rental.Car = car;
                }
            }

            foreach (var customer in DataContext.Customers)
            {
                foreach (var rental in customer.Rentals)
                {
                    rental.Customer = customer;
                }
            }
        }
        public void PrintName(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void GetCustomers()
        {
            PrintName("1. Проста вибiрка. Отримати колекцiю всiх клiєнтiв");

            var q1 = from c in DataContext.Customers
                     select c;

            foreach (var customer in q1)
            {
                Console.WriteLine(customer.ToString());
            }
        }

        public void GetCarsAfter2010()
        {
            PrintName("2. Фiльтрацiя. Отримати колекцiю автомобiлiв, випущених пiсля 2010 року");

            var q2 = from c in DataContext.Cars
                     where c.YearOfManufacture > 2010
                     select c;

            foreach (var car in q2)
            {
                Console.WriteLine(car.ToString());
            }
        }

        public void GroupCarsByModel()
        {
            PrintName("3. Групування. Отримати групи автомобiлiв, за їх моделлю");

            var q3 = from c in DataContext.Cars
                     group c by c.Model;

            foreach (var carModel in q3)
            {
                Console.WriteLine(carModel.Key + ":");

                foreach (var value in carModel)
                {
                    Console.WriteLine("\t" + value);
                }
            }
        }

        public void SortCarsByMileage()
        {
            PrintName("4. Сортування. Вiдсортувати автомобiлi за пробiгом, в разi рiвностi - за роком виготовлення");

            var q4 = from c in DataContext.Cars
                     orderby c.Mileage, c.YearOfManufacture
                     select c;

            foreach (var car in q4)
            {
                Console.WriteLine(car + $" Пробiг: {car.Mileage} км");
            }
        }

        public void FindAllRentals2022()
        {
            PrintName("5. Фiльтрацiя та сортування. Знайти всi угоди прокатiв, якi розпочалися в 2022 роцi та вiдсортувати їх за датою");

            var q5 = from r in DataContext.Rentals
                     where r.StartDate.Year == 2022
                     orderby r.StartDate, r.EndDate
                     select r;

            foreach (var rental in q5)
            {
                Console.WriteLine(rental);
            }
        }

        public void DecartMultiply()
        {
            PrintName("6. Декартовий добуток. Знайти декартовий добуток колекцiй Rental та Payment");

            var q6 = from r in DataContext.Rentals
                     from p in DataContext.Payments
                     select new { StartDate = r.StartDate, EndDate = r.EndDate, Sum = p.Sum };

            foreach (var result in q6)
            {
                Console.WriteLine($"{result.StartDate:d} {result.EndDate:d} {result.Sum}");
            }
        }

        public void InnerJoin()
        {
            PrintName("7. Inner Join. Знайти inner join з'єднання колекцiй Customers i Rentals та вивести пару значень: iм'я клiєнта та суму його платежу");

            var q7 = from c in DataContext.Customers
                     from r in DataContext.Rentals
                     where c.Rentals != null
                     from q in c.Rentals
                     where q == r
                     select new
                     {
                         Name = c.Name,
                         Sum = q.DepositSum
                     };

            foreach (var result in q7)
            {
                Console.WriteLine($"{result.Name} {result.Sum}");
            }
        }

        public void SumMoney()
        {
            PrintName("8. Використання Sum. Вивести суму зароблених коштiв з платежiв користувачiв");

            var q8 = DataContext.Payments.Sum(x => x.Sum);

            Console.WriteLine(q8);
        }

        public void UseSkip()
        {
            PrintName("9. Використання Skip. Вивести колекцiю користувачiв, починаючи з 2 iндексу");

            var q9 = DataContext.Customers.Skip(2);

            foreach (var customer in q9)
            {
                Console.WriteLine(customer);
            }
        }

        public void UseJoin()
        {
            PrintName("10. Використання Join. Вивести для машини конкретного року випуску дату її прокатiв.");

            var q10 = DataContext.Rentals.Join(DataContext.Cars, r => r.Car.Id, c => c.Id,
                (r, c) => new { StartDate = r.StartDate, EndDate = r.EndDate, Year = c.YearOfManufacture });

            foreach (var result in q10)
            {
                Console.WriteLine($"Машина року випуску {result.Year} мала прокат вiд {result.StartDate:d} до {result.EndDate:d}");
            }
        }

        public void UseGroupJoin()
        {
            PrintName("11. Використання GroupJoin. Вивести модель машини та всi суми, якi були заплаченi по угодi прокату");

            var q11 = DataContext.Cars.GroupJoin(DataContext.Rentals, c => c.Id, r => r.Car.Id, (c, rentals) => new
            {
                Model = c.Model,
                Rentals = rentals
            });

            foreach (var result in q11)
            {
                Console.Write($"Машина моделi {result.Model}: ");

                foreach (var rental in result.Rentals)
                {
                    Console.Write(rental.DepositSum + ", ");
                }
                Console.WriteLine();
            }
        }
        public void UseConcatAndDitinct()
        {
            PrintName("12. Використання Concat/Distinct. Вивести машини, модель яких \"Volkswagen\" або тих, в яких прокат бiльше 20000 км.");

            var q12 = DataContext.Cars.Where(c => c.Model == CarModel.Volkswagen)
                            .Concat(DataContext.Cars.Where(c => c.Mileage > 20000)).Distinct();

            foreach (var car in q12)
            {
                Console.WriteLine(car + " Прокат: " + car.Mileage + " км.");
            }
        }

        public void UseAll()
        {
            PrintName("13. Використання All. Чи всi машини були виготовленi до 2021 року. ");

            var q13 = DataContext.Cars.All(c => c.YearOfManufacture < 2021);

            Console.WriteLine(q13);
        }

        public void FirstWithLastNameStartedVasylenko()
        {
            PrintName("14. Використання FirstOrDefault. Чи є хоча б один клiєнт, прiзвище якого \"Василенко\"");

            var q14 = DataContext.Customers.FirstOrDefault(x => x.Name.StartsWith("Василенко"));

            Console.WriteLine(q14);
        }

        public void FindPaymentsInDate()
        {
            PrintName("15. Знайти колекцiю платежiв, якi були здiйсненi пiд час угоди прокату");

            var q15 = DataContext.Payments.Where(p => (p.Rental.StartDate < p.Date && p.Date > p.Rental.EndDate));

            foreach (var payment in q15)
            {
                Console.WriteLine(payment);
            }
        }

        public void FindOwnerOfCar()
        {
            PrintName("16. Вивести машину та iм'я клiєнту, який брав її у прокат");

            var q16 = DataContext.Cars.Join(DataContext.Customers, car => car.Rentals, customer => customer.Rentals, (car, customer) => new
            {
                Model = car.Model,
                Color = car.Color,
                Name = customer.Name,
            }, new DataEqualityComparer());

            foreach (var result in q16)
            {
                Console.WriteLine($"{result.Name} брав у прокат машину моделi {result.Model} кольору {result.Color}");
            }
        }

        public void AverageYearOfCars()
        {
            PrintName("17. Використання Average. Вивести середнiй рiк виготовлення машин");

            var q17 = DataContext.Cars.Average(c => c.YearOfManufacture);

            Console.WriteLine(q17);
        }

        public void MaxSum()
        {
            PrintName("18. Використання Max. Знайти максимальну суму, яку отримував автопарк за прокат машини");

            var q18 = DataContext.Rentals.Max(r => r.DepositSum);

            Console.WriteLine(q18);
        }

        public void FindCarOneColor()
        {
            PrintName("19. Вивести кiлькiсть машин одного кольору, якi знаходяться на прокатi.");

            var q19 = DataContext.Cars.GroupBy(c => c.Color).Select(c => new { Model = c.Key, Count = c.Count() });

            foreach (var result in q19)
            {
                Console.WriteLine($"{result.Model} - {result.Count}");
            }
        }

        public void UseSelectMany()
        {
            PrintName("20. Використання SelectMany. Вибiрка усiх угод прокату клiєнтiв. ");

            var q20 = DataContext.Customers.SelectMany(c => c.Rentals);

            foreach (var result in q20)
            {
                Console.WriteLine(result);
            }
        }
    }
}
