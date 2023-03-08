using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_Linq_To_Objects
{
    interface IDictionaryLogic
    {
        void Exit();
        void GetCustomers();
        void GetCarsAfter();
        void GroupCarsByModel();
        void SortCarsByMileage();
        void FindAllRentalsIn();
        void DecartMultiply();
        void InnerJoin();
        void SumMoney();
        void UseSkip();
        void UseJoin();
        void UseGroupJoin();
        void UseConcatAndDitinct();
        void UseAll();
        void FirstWithLastNameStartedWith();
        void FindPaymentsInDate();
        void FindOwnerOfCar();
        void AverageYearOfCars();
        void MaxSum();
        void FindCarOneColor();
        void UseSelectMany();
    }
}
