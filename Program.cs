using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FleetSim.Objects;//my class & interface folders are here

namespace FleetSim
{
    class Program
    {
        public static List<Car> LoadCars()
        {
            var theCars = new List<Car>
                {
                new Car()
                {
                    VIN = Guid.Empty,
                    Color = 2,
                    LastServicedMileage = 0,
                    LastServicedDate = "M/dd/yyyy h:mm:ss.fff.tt",
                    Mileage = 0,
                    Model = "Mazda CX5",
                    ModelYear = "2015",
                    EngineRebuilt = false,
                    Tuneup = false,
                },
                new Car()
                {
                    VIN = Guid.Empty,
                    Color = 1,
                    LastServicedMileage = 0,
                    LastServicedDate = "M/dd/yyyy h:mm:ss.fff.tt",
                    Mileage = 0,
                    Model = "Honda CRV",
                    ModelYear = "2014",
                    EngineRebuilt = false,
                    Tuneup = false
                },
                new Car()
                {
                    VIN = Guid.Empty,
                    Color = 3,
                    LastServicedMileage = 0,
                    LastServicedDate = "M/dd/yyyy h:mm:ss.fff.tt",
                    Mileage = 0,
                    Model = "Jeep Wrangler",
                    ModelYear = "2010",
                    EngineRebuilt = false,
                    Tuneup = false
                },
                new Car()
                {
                    VIN = Guid.Empty,
                    Color = 1,
                    LastServicedMileage = 0,
                    LastServicedDate = "M/dd/yyyy h:mm:ss.fff.tt",
                    Mileage = 0,
                    Model = "Alpha Romeo Stelvio",
                    ModelYear = "2018",
                    EngineRebuilt = false,
                    Tuneup = false
                },
                new Car()
                {
                    VIN = Guid.Empty,
                    Color = 2,
                    LastServicedMileage = 0,
                    LastServicedDate = "M/dd/yyyy h:mm:ss.fff.tt",
                    Mileage = 0,
                    Model = "Ford F150",
                    ModelYear = "2004",
                    EngineRebuilt = false,
                    Tuneup = false
                },
            };
            /*foreach (Car theCar in theCars)
            {
                Console.WriteLine(theCar.Model + " " + theCar.ModelYear);
            }*/
            return theCars;

        }


        /*public static int GetRandomNumber()
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(5000, 15001);
            Console.WriteLine("random number = " + randomNumber);
            return randomNumber;
        }*/
        //I had to replace this code because I was getting repeat random #'s
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber()
        {
            lock (syncLock)
            { // synchronize
                return random.Next(5000, 15001);
            }
        }

        enum CarColors : byte
        {
            red = 1,
            white = 2,
            blue = 3
        }

        static void Main(string[] args)
        {
            try
            {
                List<Car> carList = LoadCars();//creates & loads list of Cars; and returns it

                /*if you don't want to call a function you can do it like this:
                var cars = new List<Car>();
                {
                    new Car() {
                        VIN = Guid.Empty,
                        Color = 2,
                        LastServicedMileage = 0,
                        LastServicedDate = "M/dd/yyyy h:mm:ss.fff.tt",
                        Mileage = 0,
                        Model = "Ford F150",
                        ModelYear = "2004",
                        EngineRebuilt = false,
                        Tuneup = false
                    };
                {*/

                    

                var serviceList = new List<string>  { };//list to hold maintenance items

                byte i = 0;

                while (i < 10)
                {

                    foreach (var car in carList)
                    {

                        int miles = GetRandomNumber();//generates a random # between 5000-15,000

                        car.Mileage += miles;

                        if (car.EngineRebuilt == true)
                        {
                            serviceList.Add($"{car.Model} {car.ModelYear} " +
                                $"Engine Rebuilt on  { car.LastServicedDate} ");

                            car.EngineRebuilt = false;
                        }
                        else if (car.Tuneup == true)
                        {
                            serviceList.Add($"{car.Model} {car.ModelYear} " +
                            $"Engine Tuned Up at { car.LastServicedDate} " +
                            $" {car.LastServicedMileage} ");
                            car.Tuneup = false;
                        }

                    }

                    i++;
                }

                //Write Service Log from Service List
                Console.WriteLine("                  FLEETSIM SERVICE LOG");
                Console.WriteLine("                  ____________________");
                Console.WriteLine(" ");
                foreach (var car in carList)//Write out Service List

                {
                    string carColor = Enum.GetName(typeof(CarColors), car.Color);
                    Console.WriteLine($"{ car.Model} {car.ModelYear} {carColor} " +
                        $"VIN#: {car.VIN} ");
                    Console.WriteLine($"=================================================" +
                        $"=============================");

                    foreach (string service in serviceList)
                    {
                        if (((service.Contains(car.Model)) &&
                                (service.Contains(car.ModelYear))))
                        {
                            Console.WriteLine($"   {service}");
                        }
                    }

                    Console.WriteLine(" ");

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error has occurred " + e);   
            }
            finally
            {
                Console.ReadKey();
            }
        }

        
    }
}
