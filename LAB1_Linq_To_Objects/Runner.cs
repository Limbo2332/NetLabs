using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_Linq_To_Objects
{
    class Runner
    {
        private readonly IDataService _dataService;

        public Runner(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Для виходу з програми введiть 0.");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();

            int choice;

            Console.Write("Введiть номер запиту (1-20): ");

            while (int.TryParse(Console.ReadLine(), out choice))
            {

                Console.WriteLine();
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        _dataService.GetCustomers();
                        break;
                    case 2:
                        _dataService.GetCarsAfter2010();
                        break;
                    case 3:
                        _dataService.GroupCarsByModel();
                        break;
                    case 4:
                        _dataService.SortCarsByMileage();
                        break;
                    case 5:
                        _dataService.FindAllRentals2022();
                        break;
                    case 6:
                        _dataService.DecartMultiply();
                        break;
                    case 7:
                        _dataService.InnerJoin();
                        break;
                    case 8:
                        _dataService.SumMoney();
                        break;
                    case 9:
                        _dataService.UseSkip();
                        break;
                    case 10:
                        _dataService.UseJoin();
                        break;
                    case 11:
                        _dataService.UseGroupJoin();
                        break;
                    case 12:
                        _dataService.UseConcatAndDitinct();
                        break;
                    case 13:
                        _dataService.UseAll();
                        break;
                    case 14:
                        _dataService.FirstWithLastNameStartedVasylenko();
                        break;
                    case 15:
                        _dataService.FindPaymentsInDate();
                        break;
                    case 16:
                        _dataService.FindOwnerOfCar();
                        break;
                    case 17:
                        _dataService.AverageYearOfCars();
                        break;
                    case 18:
                        _dataService.MaxSum();
                        break;
                    case 19:
                        _dataService.FindCarOneColor();
                        break;
                    case 20:
                        _dataService.UseSelectMany();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ввели неправильне число, спробуйте ще раз");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }

                Console.WriteLine();
                Console.Write("Введiть номер запиту (1-20): ");
            }
        }
    }
}
