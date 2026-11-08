using System;

class Program
{
    static void Main()
    {
        Exercise1();
        Exercise2();
        Exercise3();
        Exercise4();
        Exercise5();
        Exercise6();
        Exercise7();
    }

    static void Exercise1()
    {
        Console.WriteLine("Exercise 1 - for loop");
        for (int i = 0; i <= 10; i++)
            Console.Write(i == 10 ? $"{i}\n" : $"{i}, ");
        Console.WriteLine();
    }

    static void Exercise2()
    {
        Console.WriteLine("Exercise 2 - while loop");
        int i = 0;
        while (i <= 10)
        {
            Console.Write(i == 10 ? $"{i}\n" : $"{i}, ");
            i++;
        }
        Console.WriteLine();
    }

    static void Exercise3()
    {
        Console.WriteLine("Exercise 3 - do while loop");
        int i = 0;
        do
        {
            Console.Write(i == 10 ? $"{i}\n" : $"{i}, ");
            i++;
        } while (i <= 10);
        Console.WriteLine();
    }

    static void Exercise4()
    {
        Console.WriteLine("Exercise 4 - divisible by 3 and 4");
        for (int i = 0; i <= 100; i++)
        {
            if (i % 3 == 0 && i % 4 == 0)
                Console.Write($"{i} ");
        }
        Console.WriteLine("\n");
    }

    static void Exercise5()
    {
        Console.WriteLine("Exercise 5 - looping constructs");
        Console.WriteLine("Nested loops:");
        for (int row = 1; row <= 4; row++)
        {
            for (int column = 1; column <= row; column++)
                Console.Write("* ");
            Console.WriteLine();
        }

        Console.Write("Even numbers up to 6 (continue and break): ");
        for (int i = 0; i <= 10; i++)
        {
            if (i % 2 != 0) continue;
            if (i > 6) break;
            Console.Write($"{i} ");
        }
        Console.WriteLine("\n");
    }

    static void Exercise6()
    {
        Console.WriteLine("Exercise 6 - Car class");
        Car petrolCar = new Car("Toyota");
        Car electricCar = new ElectricCar("Tesla");
        petrolCar.Accelerate(30);
        electricCar.Accelerate(20);

        Car[] cars = { petrolCar, electricCar };
        foreach (Car car in cars)
            Console.WriteLine(car.Describe());
        Console.WriteLine();
    }

    static void Exercise7()
    {
        Console.WriteLine("Exercise 7 - validation and exception handling");
        while (true)
        {
            Console.Write("Enter a positive whole number: ");
            string? input = Console.ReadLine();
            if (input == null) break;

            try
            {
                int number = int.Parse(input);
                if (number <= 0)
                    throw new ArgumentOutOfRangeException(nameof(number));
                Console.WriteLine($"Accepted: {number}");
                break;
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a whole number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("The number is too large.");
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The number must be greater than zero.");
            }
        }
    }
}

class Car
{
    private readonly string brand;
    public string Brand => brand;
    public int Speed { get; private set; }

    public Car(string brand)
    {
        if (string.IsNullOrWhiteSpace(brand))
            throw new ArgumentException("Brand is required.", nameof(brand));
        this.brand = brand;
    }

    public void Accelerate(int amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException(nameof(amount));
        Speed += amount;
    }

    public virtual string Describe() => $"{Brand} car: {Speed} km/h";
}

class ElectricCar : Car
{
    public ElectricCar(string brand) : base(brand) { }

    public override string Describe() => $"{Brand} electric car: {Speed} km/h";
}
