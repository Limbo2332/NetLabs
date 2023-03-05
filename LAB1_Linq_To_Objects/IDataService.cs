using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1_Linq_To_Objects
{
    interface IDataService
    {
        public void GetCustomers();
        public void GetCarsAfter2010();
        public void GroupCarsByModel();
        public void SortCarsByMileage();
        public void FindAllRentals2022();
        public void DecartMultiply();
        public void InnerJoin();
        public void SumMoney();
        public void UseSkip();
        public void UseJoin();
        public void UseGroupJoin();
        public void UseConcatAndDitinct();
        public void UseAll();
        public void FirstWithLastNameStartedVasylenko();
        public void FindPaymentsInDate();
        public void FindOwnerOfCar();
        public void AverageYearOfCars();
        public void MaxSum();
        public void FindCarOneColor();
        public void UseSelectMany();

    }
}
