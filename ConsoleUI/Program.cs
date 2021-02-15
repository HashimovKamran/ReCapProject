using Business.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine("Car Name : " + car.CarName + "\nBrand Name : " + car.BrandName + "\nColor Name : " + car.ColorName + "\nDail Price : " + car.DailyPrice);
                Console.WriteLine("-----------------------------------");
            }

            Console.WriteLine("**************************************************** Araba Listesi ****************************************************");
            GetAll(carManager);
            Console.WriteLine("\n====================================== Rent A Car ======================================");
            Console.WriteLine("1. Araba Ekle\n" + "2. Araba Sil\n" + "3. Araba Güncelle\n");

            int number = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n------------------------------------------------------------------------");

            switch (number)
            {
                case 1:
                    Console.WriteLine("**************************** Marka Listesi ****************************");
                    GetAll(brandManager);

                    Console.WriteLine("**************************** Reng Listesi ****************************");
                    GetAll(colorManager);

                    Console.Write("\nBrand Id: ");
                    int brandIdForAdd = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Color Id: ");
                    int colorIdForAdd = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Daily Price: ");
                    decimal dailyPriceForAdd = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Description : ");
                    string descriptionForAdd = Console.ReadLine();

                    Console.Write("Model Year: ");
                    int modelYearForAdd = Convert.ToInt32(Console.ReadLine());

                    Car carForAdd = new Car { BrandId = brandIdForAdd, ColorId = colorIdForAdd, DailyPrice = dailyPriceForAdd, Description = descriptionForAdd, ModelYear = modelYearForAdd };
                    carManager.Add(carForAdd);
                    break;

                case 2:
                    Console.WriteLine("**************************** Araba Listesi ****************************");
                    GetAll(carManager);

                    Console.Write("Hangi Id'li arabayı silmek istiyorsunuz? ");
                    int carIdForDelete = Convert.ToInt32(Console.ReadLine());
                    carManager.Delete(carManager.GetById(carIdForDelete));
                    break;

                case 3:
                    Console.WriteLine("**************************** Araba Listesi ****************************");
                    GetAll(carManager);

                    Console.Write("\nCar Id: ");
                    int carIdForUpdate = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Brand Id: ");
                    int brandIdForUpdate = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Color Id: ");
                    int colorIdForUpdate = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Daily Price: ");
                    decimal dailyPriceForUpdate = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Description : ");
                    string descriptionForUpdate = Console.ReadLine();

                    Console.Write("Model Year: ");
                    int modelYearForUpdate = Convert.ToInt32(Console.ReadLine());

                    Car carForUpdate = new Car { Id = carIdForUpdate, BrandId = brandIdForUpdate, ColorId = colorIdForUpdate, DailyPrice = dailyPriceForUpdate, Description = descriptionForUpdate, ModelYear = modelYearForUpdate };
                    carManager.Update(carForUpdate);
                    break;
            }
        }

        private static void GetAll(CarManager carManager)
        {
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("Id: " + car.Id + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
        }

        private static void GetAll(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine("BrandId: " + brand.BrandId + " BrandName: " + brand.BrandName);
            }
        }

        private static void GetAll(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine("ColorId: " + color.ColorId + " ColorName: " + color.ColorName);
            }
        }
    }
}
