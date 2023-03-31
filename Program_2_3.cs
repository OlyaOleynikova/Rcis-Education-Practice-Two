//.......................................2.3.......................................

using System;
using System.Runtime.CompilerServices;

public class Program
{
    
    public class Worker
    {
        private string name;
        private string surName;
        private int rate;
        private int days;

        public string Name
        {
            get { return name; }
        }
        public string SurName
        {
            get { return surName; }
        }

        public int Rate
        {
            get { return rate; }
        }

        public int Days
        {
            get { return days; }
        }

        public Worker(string name, string surName, int rate, int days)
        {
            this.name = name;
            this.surName = surName;
            this.rate = rate;
            this.days = days;
        }

        public void GetSalary(int rate, int days) => Console.WriteLine($"Зарплата сотрудника: {rate * days}р.");

    }
    
    public class Calculation
    {
        private string calculationLine;
    
        public string CalculationLine
        {
            get { return calculationLine; }
        }
    
        public Calculation(string calculationLine)
        {
            this.calculationLine = calculationLine;
        }
    
        public void SetCalculationLine(string line)
        {
            calculationLine = line;
        }
    
        public string GetCalculationLine(string line)
        {
            return line;
        }
    
        public void SetLastSymbolCalculationLine ( char symbol)
        {
            calculationLine += Convert.ToString(symbol);
        }
    
        public char GetLastSymbol(string line)
        {
            char lastSymbol = Convert.ToChar(line.Substring(line.Length - 1));
            return lastSymbol;
        }
        
        public string DeleteLastSymbol(string line)
        {
            line = line.Substring(0, line.Length - 1);
            return line;
        }
    
    }
    
//Task1-2    
    // public static void Main()
    // {
    //     Worker worker = new Worker("Полли", "Уокер", 200, 60);
    //
    //     Console.WriteLine($"Имя работника: {worker.Name}\n" +
    //                       $"Фамилия работника: {worker.SurName}\n" +
    //                       $"Ставка работника за день: {worker.Rate}\n" +
    //                       $"Кол-во отработанных дней: {worker.Days}р.");
    //     worker.GetSalary(worker.Rate, worker.Days);
    // }
    
//Task 3
    public static void Main()
    {
        Calculation calc = new Calculation("osidfgwve");
        Console.WriteLine(calc.GetCalculationLine(calc.CalculationLine));

        calc.SetCalculationLine("pdosefher");
        Console.WriteLine(calc.GetCalculationLine(calc.CalculationLine));

        calc.SetLastSymbolCalculationLine('c');
        Console.WriteLine(calc.GetCalculationLine(calc.CalculationLine));

        char lastSymbol = calc.GetLastSymbol(calc.CalculationLine);
        Console.WriteLine(lastSymbol);

        string line = calc.DeleteLastSymbol(calc.CalculationLine);
        Console.WriteLine(line);
    }
}