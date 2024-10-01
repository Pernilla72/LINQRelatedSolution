using System.Security.Cryptography.X509Certificates;

namespace LINQRelated
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DemoPerCentChance();
            //DemoBMI();
            //DemoExtentionMethodAsArguments();
            //DemoExtentionMethodHavingAnInterfaceParameter();
            PrintDemo();
        }

        private static void PrintDemo()
        {
           List<int> ints = new List<int>() { 1962, 2009, 1976, 2006, 1937, 1959, 1939};
            ints.Print();
            List<Patient> patients = new List<Patient>()
            {
                new Patient() {HeightInCm = 190, WeightInKg = 80.0 },
                new Patient() {HeightInCm = 184.9, WeightInKg = 92.4 },
                new Patient() {HeightInCm = 168, WeightInKg = 57.8 }
            };
            patients.Print(p => p.HeightInCm);
        }

        private static void DemoExtentionMethodHavingAnInterfaceParameter()
        {
            // --- Example using int
            int x = 10;
            int y = 12;
            bool isLess = /*ExtentionMethods.IsLessThan(x, y)*/ x.IsLessThan(y);
            if (isLess) 
                Console.WriteLine($"{x} is less than {y}");

            //___ Example using dateTime.

            DateTime start = new DateTime(2024, 09, 29);
            DateTime stop = new DateTime(2024, 09, 30);
            isLess = /*ExtentionMethods.IsLessThan(start, stop)*/ start.IsLessThan(stop);
            if (isLess)
                Console.WriteLine($"{start.ToShortDateString()}is less than {stop.ToShortDateString()}");

            //---- Example using Patient class

            Patient a = new Patient { WeightInKg = 60.0, HeightInCm = 157.5};
            Patient b = new Patient { WeightInKg = 87.0, HeightInCm = 171.5};
            isLess = /*ExtentionMethods.IsLessThan(a, b)*/ a.IsLessThan(b);
            if (isLess )
                Console.WriteLine($"{a.BMI()} is less than {b.BMI()}");
        }

        private static void DemoExtentionMethodAsArguments()
        {
            int number = 10;
            // Calling on the methods in the convntional way using several statments.
            int square = ExtentionMethods.Square(number);
            int squarePlus10 = ExtentionMethods.Plus10(square);
            int squarePlus10DividedBy2 = ExtentionMethods.DividedBy2(squarePlus10);
            Console.WriteLine(squarePlus10DividedBy2);

            //Calling on the methods in the conventional way using single statment ("oneLiner")
            squarePlus10DividedBy2 = ExtentionMethods.DividedBy2(ExtentionMethods.Plus10(ExtentionMethods.Square(number)));

            //Extention methons, usning this i metodens argument. 
            squarePlus10DividedBy2 = number
                .Square()
                .Plus10()
                .DividedBy2();
        }

        private static void DemoBMI()
        {
            Patient patient = new Patient() { HeightInCm = 171, WeightInKg = 70 };
            double bmi = /*ExtentionMethods.BMI(patient)*/ patient.BMI();
            Console.WriteLine($"BMI: {Math.Round(bmi,0)}");
        }

        private static void DemoPerCentChance()
        {
            if (/*ExtentionMethods.PerCentChance(50)*/ 50.PerCentChance())
                Console.WriteLine("Du hade tur");
            else
                Console.WriteLine("Du hade otur");
        }
    }
}
