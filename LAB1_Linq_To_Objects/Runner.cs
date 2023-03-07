using LAB1_Linq_To_Objects.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_Linq_To_Objects
{
    class Runner : IRunner
    {
        private readonly IDataService _dataService;
        public Runner(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void Run()
        {
            // Не зміг реалізувати в окремому класі
            var commandDictionary = new Dictionary<CommandNumber, Action>(){
                {CommandNumber.Exit, () => { return; }},
                {CommandNumber.GetCustomers, () => {
                    var customers = _dataService.GetCustomers();
                    MessageHolder.WriteMessage("\n1. Проста вибiрка. Отримати колекцiю всiх клiєнтiв", MessageType.NameOfQuery);
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer.ToString());
                    }
                    Console.WriteLine();
                 }},

                {CommandNumber.GetCarsAfter, () => {
                    var cars = _dataService.GetCarsAfter();
                    MessageHolder.WriteMessage("\n2. Фiльтрацiя. Отримати колекцiю автомобiлiв, випущених пiсля 2010 року",
                        MessageType.NameOfQuery);
                    foreach (var car in cars)
                    {
                        Console.WriteLine(car.ToString());
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.GroupCarsByModel, () => {
                    var cars = _dataService.GroupCarsByModel();
                    MessageHolder.WriteMessage("\n3. Групування. Отримати групи автомобiлiв, за їх моделлю", MessageType.NameOfQuery);
                    foreach (var carModel in cars)
                    {
                        Console.WriteLine(carModel.Key + ":");

                        foreach (var value in carModel)
                        {
                            Console.WriteLine("\t" + value);
                        }
                    }
                    Console.WriteLine();
                 }},

                {CommandNumber.SortCarsByMileage, () => {
                    var cars = _dataService.SortCarsByMileage();
                    MessageHolder.WriteMessage("\n4. Сортування. Вiдсортувати автомобiлi за пробiгом, в разi рiвностi - за роком виготовлення",
                        MessageType.NameOfQuery);
                    foreach (var car in cars)
                    {
                        Console.WriteLine(car + $" Пробiг: {car.Mileage} км");
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.FindAllRentalsIn, () => {
                    const int YEAR = 2022;
                    var rentals = _dataService.FindAllRentalsIn(YEAR);
                    MessageHolder.WriteMessage($"\n5. Фiльтрацiя та сортування. Знайти всi угоди прокатiв, якi розпочалися в {YEAR} роцi та вiдсортувати їх за датою",
                        MessageType.NameOfQuery);
                    foreach (var rental in rentals)
                    {
                        Console.WriteLine(rental);
                        Console.WriteLine(rental.Price);
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.DecartMultiply, () => {
                    var decartResult = _dataService.DecartMultiply();
                    MessageHolder.WriteMessage("\n6. Декартовий добуток. Знайти декартовий добуток колекцiй Rental та Payment",
                        MessageType.NameOfQuery);
                    foreach (var result in decartResult)
                    {
                        Console.WriteLine($"{result.StartDate:d} {result.EndDate:d} {result.Sum}");
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.InnerJoin, () => {
                    var resultInnerJoin = _dataService.InnerJoin();
                    MessageHolder.WriteMessage("\n7. Inner Join. Знайти inner join з'єднання колекцiй Customers i Rentals та вивести пару значень: iм'я клiєнта та суму його платежу",
                        MessageType.NameOfQuery);
                    foreach (var result in resultInnerJoin)
                    {
                        Console.WriteLine($"{result.Name} {result.Sum}");
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.SumMoney, () => {
                    decimal money = _dataService.SumMoney();
                    MessageHolder.WriteMessage("\n8. Використання Sum. Вивести суму зароблених коштiв з платежiв користувачiв",
                        MessageType.NameOfQuery);
                    Console.WriteLine(money);
                    Console.WriteLine();
                }},
                {CommandNumber.UseSkip, () => {
                    const int INDEX = 2;
                    var customers = _dataService.UseSkip(INDEX);
                    MessageHolder.WriteMessage($"\n9. Використання Skip. Вивести колекцiю користувачiв, починаючи з {INDEX} iндексу",
                        MessageType.NameOfQuery);
                    foreach (var customer in customers)
                    {
                        Console.WriteLine(customer);
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.UseJoin, () => {
                    var resultJoin = _dataService.UseJoin();
                    MessageHolder.WriteMessage("\n10. Використання Join. Вивести для машини конкретного року випуску дату її прокатiв.",
                        MessageType.NameOfQuery);
                    foreach (var result in resultJoin)
                    {
                        Console.WriteLine($"Машина року випуску {result.Year} мала прокат вiд {result.StartDate:d} до {result.EndDate:d}");
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.UseGroupJoin, () => {
                    var resultGroupJoin = _dataService.UseGroupJoin();
                    MessageHolder.WriteMessage("\n11. Використання GroupJoin. Вивести модель машини та всi суми, якi були заплаченi по угодi прокату",
                        MessageType.NameOfQuery);
                    foreach (var result in resultGroupJoin)
                    {
                        Console.Write($"Машина моделi {result.Model}: ");

                        foreach (var rental in result.Rentals!)
                        {
                            Console.Write(rental.DepositSum + ", ");
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.UseConcatAndDitinct, () => {
                    CarModel model = CarModel.Volkswagen;
                    const decimal MILEAGE = 20000M;
                    var cars = _dataService.UseConcatAndDitinct(model, MILEAGE);
                    MessageHolder.WriteMessage($"\n12. Використання Concat/Distinct. Вивести машини, модель яких ${model.ToString()} або тих, в яких прокат бiльше {MILEAGE} км.",
                        MessageType.NameOfQuery);
                    foreach (var car in cars)
                    {
                        Console.WriteLine(car + " Прокат: " + car.Mileage + " км.");
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.UseAll, () => {
                    var allCars = _dataService.UseAll();
                    MessageHolder.WriteMessage("\n13. Використання All. Чи всi машини були виготовленi до 2021 року. ",
                        MessageType.NameOfQuery);
                    Console.WriteLine(allCars);
                    Console.WriteLine();
                }},

                {CommandNumber.FirstWithLastNameStartedWith , () => {
                    const string NAME = "Василенко";
                    var customer = _dataService.FirstWithLastNameStartedWith();
                    MessageHolder.WriteMessage($"\n14. Використання FirstOrDefault. Чи є хоча б один клiєнт, прiзвище якого \"{NAME}\"",
                        MessageType.NameOfQuery);
                    Console.WriteLine(customer);
                    Console.WriteLine();
                }},

                {CommandNumber.FindPaymentsInDate, () => {
                    var resultPayments = _dataService.FindPaymentsInDate();
                    MessageHolder.WriteMessage("\n15. Знайти колекцiю платежiв, якi були здiйсненi пiд час угоди прокату",
                        MessageType.NameOfQuery);
                    foreach (var payment in resultPayments)
                    {
                        Console.WriteLine($"{payment.StartDate:d} - {payment.Date:d} - {payment.EndDate:d}");
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.FindOwnerOfCar, () => {
                    var owners = _dataService.FindOwnerOfCar();
                    MessageHolder.WriteMessage("\n16. Вивести машину та iм'я клiєнту, який брав її у прокат",
                        MessageType.NameOfQuery);
                    foreach (var result in owners)
                    {
                        Console.WriteLine($"{result.Name} брав у прокат машину моделi {result.Model} кольору {result.Color}");
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.AverageYearOfCars, () => {
                    var average = _dataService.AverageYearOfCars();
                    MessageHolder.WriteMessage("\n17. Використання Average. Вивести середнiй рiк виготовлення машин",
                        MessageType.NameOfQuery);
                    Console.WriteLine(average);
                    Console.WriteLine();
                }},

                {CommandNumber.MaxSum, () => {
                    decimal maxSum = _dataService.MaxSum();
                    MessageHolder.WriteMessage("\n18. Використання Max. Знайти максимальну суму, яку отримував автопарк за прокат машини",
                        MessageType.NameOfQuery);
                    Console.WriteLine(maxSum);
                    Console.WriteLine();
                }},
                {CommandNumber.FindCarOneColor, () => {
                    var resultFinds = _dataService.FindCarOneColor();
                    MessageHolder.WriteMessage("\n19. Вивести кiлькiсть машин одного кольору, якi знаходяться на прокатi.",
                        MessageType.NameOfQuery);
                    foreach (var result in resultFinds)
                    {
                        Console.WriteLine($"{result.Color} - {result.Count}");
                    }
                    Console.WriteLine();
                }},

                {CommandNumber.UseSelectMany, () => {
                    var customers = _dataService.UseSelectMany();
                    MessageHolder.WriteMessage("\n20. Використання Reverse. Перевернути колекцію клієнтів.",
                        MessageType.NameOfQuery);
                    foreach (var result in customers)
                    {
                        Console.WriteLine(result);
                    }
                    Console.WriteLine();
                }},
            };

            while (true)
            {
                string? input = Console.ReadLine();

                if (String.Compare(input, "exit") == 0) 
                    commandDictionary[0].Invoke();

                if (Enum.TryParse(input, out CommandNumber command) && 
                    commandDictionary.ContainsKey(command))
                {
                    commandDictionary[command].Invoke();
                }
                else
                {
                    MessageHolder.WriteMessage("Неправильний ввiд даних. Спробуйте ще раз.", MessageType.Danger);
                }
            }
        }
    }
}
