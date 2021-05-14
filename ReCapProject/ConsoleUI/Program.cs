using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

using Entities;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { ColorName = "Turuncu"});
            Console.WriteLine(colorManager.GetAll());
        }

        //private static void CarTest()
        //{
        //    CarManager carManager = new CarManager(new EfCarDal());

        //    //carManager.Delete(new Car { CarId = 9 });
        //    //carManager.Add(new Car { CarName = "Tesla", BrandId = 1, DailyPrice = 50, ColorId = 2, ModelYear = 2020, Description="Sıfır" });
        //    //carManager.Update(new Car { CarId = 8, CarName = "Opel", ColorId = 2 });

        //    foreach (var item in carManager.GetAll())
        //    {
        //        Console.WriteLine(item.CarName);
        //    }




        //}


    }
}
