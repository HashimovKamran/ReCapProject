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
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            GetCarDetails(carManager);
            GetAll(carManager);

            Console.WriteLine("\n====================================== Rent A Car ======================================");
            Console.WriteLine("1. Araba Ekle\n" + "2. Araba Sil\n" + "3. Araba Güncelle\n" + "4. Araba Listele\n\n" +
                "5. Kullanıcı Ekle\n" + "6. Kullanıcı Sil\n" + "7. Kullanıcı Güncelle\n" + "8. Kullanıcı Listele\n\n" +
                "9. Müşteri Ekle\n" + "10. Müşteri Sil\n" + "11. Müşteri Güncelle\n" + "12. Müşteri Listele\n\n" +
                "13. Araba Kirala\n" + "14. Araba Teslim Al\n" + "15. Araba Kirası Güncelle\n" + "16. Kiralanmış Arabaları Listele\n\n" +
                "99. Çıkış\n");

            
            bool exit = true;

            Console.WriteLine("\n------------------------------------------------------------------------");

            while (exit)
            {
                Console.Write("\nBir işlem seçin: ");
                int number = Convert.ToInt32(Console.ReadLine());

                switch (number)
                {
                    case 1:
                        GetAll(brandManager);
                        GetAll(colorManager);

                        Console.Write("\nBrand Id: ");
                        int brandIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nColor Id: ");
                        int colorIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nDaily Price: ");
                        decimal dailyPriceForAdd = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("\nDescription : ");
                        string descriptionForAdd = Console.ReadLine();

                        Console.Write("\nModel Year: ");
                        int modelYearForAdd = Convert.ToInt32(Console.ReadLine());

                        Car carForAdd = new Car { BrandId = brandIdForAdd, ColorId = colorIdForAdd, DailyPrice = dailyPriceForAdd, Description = descriptionForAdd, ModelYear = modelYearForAdd };
                        carManager.Add(carForAdd);
                        break;

                    case 2:
                        GetAll(carManager);

                        Console.Write("Hangi Id'li arabayı silmek istiyorsunuz? ");
                        int carIdForDelete = Convert.ToInt32(Console.ReadLine());
                        carManager.Delete(carManager.GetById(carIdForDelete).Data);
                        break;

                    case 3:
                        GetAll(carManager);

                        Console.Write("\nId: ");
                        int carIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nBrand Id: ");
                        int brandIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nColor Id: ");
                        int colorIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nDaily Price: ");
                        decimal dailyPriceForUpdate = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("\nDescription : ");
                        string descriptionForUpdate = Console.ReadLine();

                        Console.Write("\nModel Year: ");
                        int modelYearForUpdate = Convert.ToInt32(Console.ReadLine());

                        Car carForUpdate = new Car { Id = carIdForUpdate, BrandId = brandIdForUpdate, ColorId = colorIdForUpdate, DailyPrice = dailyPriceForUpdate, Description = descriptionForUpdate, ModelYear = modelYearForUpdate };
                        carManager.Update(carForUpdate);
                        break;

                    case 4:
                        GetAll(carManager);
                        break;

                    case 5:
                        GetAll(userManager);

                        Console.Write("\nFirst Name: ");
                        string firstNameForAdd = Console.ReadLine();

                        Console.Write("\nLast Name: ");
                        string lastNameForAdd = Console.ReadLine();

                        Console.Write("\nEmail: ");
                        string emailForAdd = Console.ReadLine();

                        Console.Write("\nPassword: ");
                        string passwordForAdd = Console.ReadLine();

                        User userForAdd = new User { FirstName = firstNameForAdd, LastName = lastNameForAdd, Email = emailForAdd, Password = passwordForAdd };
                        userManager.Add(userForAdd);
                        break;

                    case 6:
                        GetAll(userManager);

                        Console.Write("Hangi Id'li kullanıcını silmek istiyorsunuz? ");
                        int userIdForDelete = Convert.ToInt32(Console.ReadLine());
                        userManager.Delete(userManager.GetById(userIdForDelete).Data);
                        break;

                    case 7:
                        GetAll(userManager);

                        Console.Write("\nId: ");
                        int userIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nFirst Name: ");
                        string firstNameForUpdate = Console.ReadLine();

                        Console.Write("\nLast Name: ");
                        string lastNameForUpdate = Console.ReadLine();

                        Console.Write("\nEmail: ");
                        string emailForUpdate = Console.ReadLine();

                        Console.Write("\nPassword: ");
                        string passwordForUpdate = Console.ReadLine();

                        User userForUpdate = new User { Id = userIdForUpdate, FirstName = firstNameForUpdate, LastName = lastNameForUpdate, Email = emailForUpdate, Password = passwordForUpdate };
                        userManager.Update(userForUpdate);
                        break;

                    case 8:
                        GetAll(userManager);
                        break;

                    case 9:
                        GetAll(customerManager);
                        GetAll(userManager);

                        Console.Write("\nUser Id: ");
                        int userIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nCustomer Name: ");
                        string customerNameForAdd = Console.ReadLine();

                        Customer customerForAdd = new Customer { UserId = userIdForAdd, CompanyName = customerNameForAdd };
                        customerManager.Add(customerForAdd);
                        break;
                    
                    case 10:
                        GetAll(customerManager);

                        Console.Write("Hangi Id'li müşterini silmek istiyorsunuz? ");
                        int customerIdForDelete = Convert.ToInt32(Console.ReadLine());
                        customerManager.Delete(customerManager.GetById(customerIdForDelete).Data);
                        break;

                    case 11:
                        GetAll(customerManager);
                        GetAll(userManager);

                        Console.Write("\nId: ");
                        int customerIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nUser Id: ");
                        int customerUserIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nCustomer Name: ");
                        string customerNameForUpdate = Console.ReadLine();

                        Customer customerForUpdate = new Customer { Id = customerIdForUpdate, UserId = customerUserIdForUpdate, CompanyName = customerNameForUpdate };
                        customerManager.Update(customerForUpdate);
                        break;

                    case 12:
                        GetAll(customerManager);
                        break;

                    case 13:
                        GetAll(carManager);
                        GetAll(customerManager);
                        GetAll(rentalManager);

                        Console.Write("\nCar Id: ");
                        int carIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nCustomer Id: ");
                        int customerIdForAdd = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nRent Date: ");
                        DateTime rentDateForAdd = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("\nReturn Date: ");
                        DateTime returnDateForAdd = Convert.ToDateTime(Console.ReadLine());

                        Rental rentalForAdd = new Rental { CarId = carIdForAdd, CustomerId = customerIdForAdd, RentDate = rentDateForAdd, ReturnDate = returnDateForAdd };
                        rentalManager.Add(rentalForAdd);
                        break;

                    case 14:
                        GetAll(rentalManager);

                        Console.Write("Hangi Id'li kiralanmış arabanı teslim almak istiyorsunuz? ");
                        int rentalIdForDelete = Convert.ToInt32(Console.ReadLine());
                        rentalManager.Delete(rentalManager.GetById(rentalIdForDelete).Data);
                        break;

                    case 15:
                        GetAll(carManager);
                        GetAll(customerManager);
                        GetAll(rentalManager);

                        Console.Write("\nId: ");
                        int rentalIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nCar Id: ");
                        int rentalCarIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nCustomer Id: ");
                        int rentalCustomerIdForUpdate = Convert.ToInt32(Console.ReadLine());

                        Console.Write("\nRent Date: ");
                        DateTime rentDateForUpdate = Convert.ToDateTime(Console.ReadLine());

                        Console.Write("\nReturn Date: ");
                        DateTime returnDateForUpdate = Convert.ToDateTime(Console.ReadLine());

                        Rental rentalForUpdate = new Rental { Id = rentalIdForUpdate, CarId = rentalCarIdForUpdate, CustomerId = rentalCustomerIdForUpdate, RentDate = rentDateForUpdate, ReturnDate = returnDateForUpdate };
                        rentalManager.Update(rentalForUpdate);
                        break;

                    case 16:
                        GetAll(rentalManager);
                        break;

                    case 99:
                        exit = false;
                        break;
                }
            }
        }

        private static void GetCarDetails(CarManager carManager)
        {
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("Car Name : " + car.CarName + "\nBrand Name : " + car.BrandName + "\nColor Name : " + car.ColorName + "\nDail Price : " + car.DailyPrice);
                    Console.WriteLine("-----------------------------------");
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void GetAll(CarManager carManager)
        {
            Console.WriteLine("**************************************************** Araba Listesi ****************************************************");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine("Id: " + car.Id + " BrandId: " + car.BrandId + " ColorId: " + car.ColorId + " Model Year: " + car.ModelYear + " Daily Price: " + car.DailyPrice + " Description: " + car.Description);
            }
        }

        private static void GetAll(BrandManager brandManager)
        {
            Console.WriteLine("**************************** Marka Listesi ****************************");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine("BrandId: " + brand.BrandId + " BrandName: " + brand.BrandName);
            }
        }

        private static void GetAll(ColorManager colorManager)
        {
            Console.WriteLine("**************************** Reng Listesi ****************************");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine("ColorId: " + color.ColorId + " ColorName: " + color.ColorName);
            }
        }

        private static void GetAll(UserManager userManager)
        {
            Console.WriteLine("*************************************************** Kullanıcı Listesi **************************************************");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine("Id: " + user.Id + " First Name: " + user.FirstName + " Last Name: " + user.LastName + " Email: " + user.Email + " Password: " + user.Password);
            }
        }

        private static void GetAll(CustomerManager customerManager)
        {
            Console.WriteLine("**************************************************** Müşteri Listesi ****************************************************");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine("Id: " + customer.Id + " Customer Name: " + customer.CompanyName);
            }
        }

        private static void GetAll(RentalManager rentalManager)
        {
            Console.WriteLine("**************************************************** Kiralanmış Arabalar Listesi ****************************************************");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine("Id: " + rental.Id + " Rent Date: " + rental.RentDate + " Return Date: " + rental.ReturnDate);
            }
        }
    }
}