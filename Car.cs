using System;
using lab9;
using System.Xml.Schema;
using System.Runtime.CompilerServices;

public class Car
{
    private double fuelFlow;
    private double fuelVolume;
    static int count = 0;

    public double FuelFlow 
    {
        get { return fuelFlow; }
        set { fuelFlow = value; }
    }
    public double FuelVolume
    {
        get { return fuelVolume; }
        set { fuelVolume = value; }
    }

    public Car(double fuelFlow, double fuelVolume)
    {
        this.fuelFlow = fuelFlow;
        this.fuelVolume = fuelVolume;

        count++;
    }

    public Car()
    {
        FuelFlow = 0;
        FuelVolume = 0;

        count++;
    }

    public Car(Car copy)
    {
        this.fuelFlow = copy.fuelFlow;
        this.fuelVolume = copy.FuelVolume;

        count++;
    }

    public static double Calculate(Car car) // статическая функция
    {
        return car.fuelVolume / car.fuelFlow * 100; // т.к. расход топлива считается на 100 км
    }

    public double Calculate() // метод класса
    {
        return FuelVolume / FuelFlow * 100; // т.к. расход топлива считается на 100 км
    }

    public void Print() // вывод информации
    {
        Console.WriteLine($"Flow = {FuelFlow}");
        Console.WriteLine($"Volume = {FuelVolume}");
    }

    public static int Count => count; // подсчёт объектов
    public static void ResetCount() // сброс
    {
        count = 0;
    }

    public static Car operator ++( Car car )
    {
        car.FuelFlow += 0.1;
        return car;
    }

    public static Car operator --( Car car )
    {
        if (car.FuelVolume >= 1)
        {
            car.FuelVolume -= 1;
        }
        else
        {
            Console.WriteLine("Fuel volume cannot be lower than 0");
        }
        return car;
    }

    public static explicit operator bool( Car car )
    {
        if (car.FuelVolume - car.FuelFlow >= 5)
        {
            return true;
        }
        return false;
    }

    public static implicit operator double( Car car )
    {
        if (car.FuelVolume < 5)
        {
            return -1;
        }
        return ((car.FuelVolume - 5) / car.FuelFlow);
    }

    public static Car operator +(Car car, double fuel)
    {
        car.fuelVolume += fuel;
        return car;
    }

    public static Car operator +(double fuel, Car car)
    {
        car.fuelFlow += fuel;
        return car;
    }

    public static bool operator ==(Car c1, Car c2)
    {
        if ((c1.fuelFlow == c2.fuelFlow) && (c1.fuelVolume == c2.fuelVolume))
        {
            return true;
        }
        return false;
    }

    public static bool operator !=(Car c1, Car c2)
    {
        if ((c1.fuelFlow != c2.fuelFlow) || (c1.fuelVolume != c2.fuelVolume))
        {
            return true;
        }
        return false;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }
}
