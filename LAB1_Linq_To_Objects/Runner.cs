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
        private readonly IDictionaryLogic _dictionaryLogic;
        public Runner(IDictionaryLogic dictionaryLogic)
        {
            _dictionaryLogic = dictionaryLogic;
        }

        public void Run()
        {
            var commandDictionary = new Dictionary<CommandNumber, Action>(){
                {CommandNumber.Exit, () => _dictionaryLogic.Exit() },
                {CommandNumber.GetCustomers, () => _dictionaryLogic.GetCustomers()},
                {CommandNumber.GetCarsAfter, () => _dictionaryLogic.GetCarsAfter()},
                {CommandNumber.GroupCarsByModel, () => _dictionaryLogic.GroupCarsByModel()},
                {CommandNumber.SortCarsByMileage, () => _dictionaryLogic.SortCarsByMileage()},
                {CommandNumber.FindAllRentalsIn, () => _dictionaryLogic.FindAllRentalsIn()},
                {CommandNumber.DecartMultiply, () => _dictionaryLogic.DecartMultiply()},
                {CommandNumber.InnerJoin, () => _dictionaryLogic.InnerJoin()},
                {CommandNumber.SumMoney, () => _dictionaryLogic.SumMoney()},
                {CommandNumber.UseSkip, () => _dictionaryLogic.UseSkip()},
                {CommandNumber.UseJoin, () => _dictionaryLogic.UseJoin()},
                {CommandNumber.UseGroupJoin, () => _dictionaryLogic.UseGroupJoin()},
                {CommandNumber.UseConcatAndDitinct, () => _dictionaryLogic.UseConcatAndDitinct()},
                {CommandNumber.UseAll, () => _dictionaryLogic.UseAll()},
                {CommandNumber.FirstWithLastNameStartedWith , () => _dictionaryLogic.FirstWithLastNameStartedWith()},
                {CommandNumber.FindPaymentsInDate, () => _dictionaryLogic.FindPaymentsInDate()},
                {CommandNumber.FindOwnerOfCar, () => _dictionaryLogic.FindOwnerOfCar()},
                {CommandNumber.AverageYearOfCars, () => _dictionaryLogic.AverageYearOfCars()},
                {CommandNumber.MaxSum, () => _dictionaryLogic.MaxSum()},
                {CommandNumber.FindCarOneColor, () => _dictionaryLogic.FindCarOneColor()},
                {CommandNumber.UseSelectMany, () => _dictionaryLogic.UseSelectMany()},
            };

            MessageHolder.WriteMessage("Для виходу з програми введiть \"exit\"", MessageType.Danger);

            while (true)
            {
                MessageHolder.WriteMessage("Введiть номер запиту (1-20): ", MessageType.Default);
                string? input = Console.ReadLine();

                if (string.Compare(input, "exit") == 0) 
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
