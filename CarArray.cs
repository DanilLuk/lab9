using System;
using lab9;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public class CarArray
    {
        Random rng = new Random();
        Car[] carArr;
        private static int arrCount = 0;

        public CarArray() // конструктор без параметров
        {
            carArr = new Car[0];
            arrCount++;
        }

        public static int Count => arrCount;
        public static void CountReset()
        {
            arrCount = 0;
        }
        public int Length => carArr.Length;

        public CarArray(int length, string keyword) // конструктор с параметром 
        {
            if (keyword == "random") // для случайных значений
            {
                carArr = new Car[length];
                
                for (int i = 0; i < carArr.Length; i++)
                {
                    carArr[i] = new Car(rng.Next(20, 50), rng.Next(5, 50));
                }
            }
            else
            {
                carArr = new Car[length];
                for (int i = 0; i < carArr.Length; i++)
                {
                    bool isChecked = false;
                    double valueVol;
                    double valueFlow;
                    do
                    {
                        Console.WriteLine($"Flow value for car {i + 1}:");
                        string buffer = Console.ReadLine();
                        isChecked = double.TryParse(buffer, out valueFlow);
                        if (!isChecked || valueFlow <= 0)
                            Console.WriteLine("Invalid");
                    } while (!isChecked || valueFlow <= 0);
                    do
                    {
                        Console.WriteLine($"Volume value for car {i + 1}:");
                        string buffer = Console.ReadLine();
                        isChecked = double.TryParse(buffer, out valueVol);
                        if (!isChecked || valueVol < 0)
                            Console.WriteLine("Invalid");
                    } while (!isChecked || valueVol < 0);
                    carArr[i] = new Car(valueFlow, valueVol);
                }
            }
            arrCount++;
        }

        public CarArray(CarArray copiedArr) // копирование массива
        {
            carArr = new Car[copiedArr.carArr.Length];
            for (int i = 0; i < copiedArr.carArr.Length; i++)
            {
                carArr[i] = new Car(copiedArr.carArr[i].FuelFlow, copiedArr.carArr[i].FuelVolume);
            }
            arrCount++;
        }

        public void ArrayPrint() // просмотр элементов
        {
            if (carArr.Length > 0)
            {
                for (int i = 0; i < carArr.Length; i++)
                {
                    Console.WriteLine($"Car number {i + 1}:");
                    carArr[i].Print();
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Array is empty");
            }
        }

        public Car this[int index]
        {
            get
            {
                if (index >= 0 &&  index < carArr.Length)
                {
                    return carArr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }

            set
            {
                if (index >= 0 && index < carArr.Length)
                {
                    carArr[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range");
                }
            }
        }
    }
}
