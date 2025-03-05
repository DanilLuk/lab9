using System;
using lab9;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace lab9
{
    public class Program
    {
        public static Car FindLowest(CarArray arr)
        {            
            arr.ArrayPrint();
            Console.WriteLine();

            Car minCar = new Car();
            double minCarDist = 100000; // как можно больший запас хода для поиска минимального
            int minIndex = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Calculate() < minCarDist)
                {
                    minCarDist = arr[i].Calculate();
                    minCar = arr[i];
                    minIndex = i;
                }
            }
            Console.WriteLine($"Car with the lowest distance left: {minIndex + 1}");
            minCar.Print();

            return minCar;
        }

        static void Main(string[] args)
        {
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Car car1 = new Car(10, 50);
                    Car car2 = new Car();

                    // вывод атрибутов
                    Console.WriteLine("Cars atributes:");
                    car1.Print();
                    car2.Print();
                    Console.WriteLine();

                    // функция и метод класса (Задание 1)
                    Console.WriteLine("Method:");
                    Console.WriteLine(car1.Calculate());
                    Console.WriteLine("Static function:");
                    Console.WriteLine(Car.Calculate(car1));
                    Console.WriteLine();

                    // подсчёт
                    Console.WriteLine($"Current car count: {Car.Count}");
                    Console.WriteLine();

                    // операции (Задание 2)
                    Car car3 = new Car(20, 60);

                    Console.WriteLine("Cars atributes before operations:");
                    car1.Print();
                    car2.Print();
                    car3.Print();
                    Console.WriteLine();

                    Console.WriteLine("++car1:");
                    ++car1;
                    car1.Print();
                    Console.WriteLine();

                    Console.WriteLine("--car1:");
                    --car1;
                    car1.Print();
                    Console.WriteLine();

                    bool enoughFuel = (bool)car3;
                    Console.WriteLine("car3 to bool:");
                    Console.WriteLine(enoughFuel);
                    Console.WriteLine();

                    double distanceLeft = car3;
                    Console.WriteLine("car3 to double:");
                    Console.WriteLine(distanceLeft);
                    Console.WriteLine();

                    Console.WriteLine("binary left side +:");
                    car3 = car3 + 3;
                    car3.Print();
                    Console.WriteLine();

                    Console.WriteLine("binary right side +:");
                    car3 = 3 + car3;
                    car3.Print();
                    Console.WriteLine();

                    Car car4 = new Car(car3); // копия car3 для операций сравнения

                    Console.WriteLine("car3 == car4:");
                    Console.WriteLine(car3 == car4);
                    Console.WriteLine();

                    Console.WriteLine("car3 != car4:");
                    Console.WriteLine(car3 != car4);
                    Console.WriteLine();

                    break;

                case "2":
                    bool isChecked = false;

                    Console.WriteLine("Enter length of the random array");
                    int length;
                    do
                    {
                        string buffer = Console.ReadLine();
                        isChecked = int.TryParse(buffer, out length);
                        if (!isChecked || length < 0)
                            Console.WriteLine("Invalid");
                    } while (!isChecked || length < 0);
                    CarArray cars1 = new CarArray(length, "random");
                    cars1.ArrayPrint();
                    Console.WriteLine();

                    Console.WriteLine("Enter length of the normal array");
                    do
                    {
                        string buffer = Console.ReadLine();
                        isChecked = int.TryParse(buffer, out length);
                        if (!isChecked || length < 0)
                            Console.WriteLine("Invalid");
                    } while (!isChecked || length < 0);
                    CarArray cars2 = new CarArray(length, "adsg");
                    cars2.ArrayPrint();
                    Console.WriteLine();

                    Console.WriteLine("Copied cars1 array:");
                    CarArray carsCopy = new CarArray(cars1);
                    carsCopy.ArrayPrint();
                    Console.WriteLine();

                    break;

                case "3":
                    Console.WriteLine("Current array:");
                    CarArray cars3 = new CarArray(5, "random");
                    cars3.ArrayPrint();
                    Console.WriteLine();

                    Console.WriteLine("Changing and getting cars[1]:");
                    cars3[1] = new Car(1000, 1000);
                    cars3[1].Print();
                    Console.WriteLine();

                    Console.WriteLine("Changing and getting cars[100]:");
                    cars3[100] = new Car(1000, 1000);
                    cars3[100].Print();

                    break;

                case "4":
                    CarArray cars4 = new CarArray(10, "random");
                    FindLowest(cars4);

                    break;
            }
        }
    }
}
