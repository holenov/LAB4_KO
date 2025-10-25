using System;
using System.Linq;
using System.Text;

class Equation
{
    public double A { get; set; }
    public double B { get; set; }

    public Equation(double a, double b)
    {
        A = a;
        B = b;
    }

    public virtual void Show()
    {
        Console.WriteLine($"A = {A}, B = {B}");
    }
}

class Child1 : Equation
{
    public Child1(double a, double b) : base(a, b) { }

    public override void Show()
    {
        Console.WriteLine($"Лінійне рівняння: y = {A}x + {B}");
    }
}

class Child2 : Equation
{
    public double C { get; set; }

    public Child2(double a, double b, double c) : base(a, b)
    {
        C = c;
    }

    public override void Show()
    {
        Console.WriteLine($"Квадратне рівняння: y = {A}x² + {B}x + {C}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;
        Random rand = new Random();
        Console.WriteLine("=== Лінійні рівняння (Child1) ===");
        Child1[] arr1 = new Child1[5];
        for (int i = 0; i < arr1.Length; i++)
            arr1[i] = new Child1(rand.Next(-10, 10), rand.Next(-10, 10));

        Console.WriteLine("\nПочатковий масив:");
        foreach (var obj in arr1) obj.Show();

        arr1 = arr1.OrderBy(x => x.A).ToArray();

        Console.WriteLine("\nПісля сортування за коефіцієнтом при X:");
        foreach (var obj in arr1) obj.Show();

        Console.WriteLine("\n=== Квадратні рівняння (Child2) ===");
        Child2[] arr2 = new Child2[5];
        for (int i = 0; i < arr2.Length; i++)
            arr2[i] = new Child2(rand.Next(-10, 10), rand.Next(-10, 10), rand.Next(-10, 10));

        Console.WriteLine("\nПочатковий масив:");
        foreach (var obj in arr2) obj.Show();

        arr2 = arr2.OrderBy(x => x.A).ToArray();

        Console.WriteLine("\nПісля сортування за коефіцієнтом при X²:");
        foreach (var obj in arr2) obj.Show();

        Console.ReadLine();
    }
}
