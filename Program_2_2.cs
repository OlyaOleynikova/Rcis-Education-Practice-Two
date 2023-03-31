//.......................................2.2.......................................

using System;
using System.Collections.Generic;

public class Program
{

public class Student
    {
        public string surName { get; set; }
        public DateTime dateBirth { get; set; }
        public string groupNumb { get; set; }
        public int[] perfomance { get; }

        public Student(string surName, DateTime date, string gNumb)
        {
            this.surName = surName;
            dateBirth = date;
            groupNumb = gNumb;
            perfomance = Perfomance();
        }

        ~Student()
        {
        }

        public int[] Perfomance()
        {
            Random rnd = new Random();
            int[] per = new int[5];

            for (int i = 0; i < 5; ++i)
            {
                per[i] = rnd.Next(2, 5);
            }

            return per;
        }

    }

    internal class Train
    {
        public string destinationName { get; }
        public int trainNum { get; }
        public DateTime timeToStart { get; }

        public Train(string destName, int trainNum, DateTime timeToStart)
        {
            destinationName = destName;
            this.trainNum = trainNum;
            this.timeToStart = timeToStart;
        }
    }

    internal class Numbs
    {
        public int a { get; set; }
        public int b { get; set; }

        public Numbs(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public void Print(int num)
        {
            Console.WriteLine(num);
        }

        public int ChangeNumb(int num)
        {
            Console.Write("Enter Numb: ");
            num = Convert.ToInt32(Console.ReadLine());
            return num;
        }

        public int SumNumbs(int a, int b) => a + b;

        public int CompareNumbs(int a, int b)
        {
            if (a > b) return a;
            return b;
        }
    }

    public class Counter
    {
        public int i { get; set; } = 1;

        public int Increase() => ++i;
        public int Reduce() => --i;
    }

    class Person : IDisposable
    {
        public string name { get; set; }
        public int age { get; set; }

        public Person()
        {
            name = "Оля";
            age = 18;
        }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public void Dispose()
        {
            Console.WriteLine($"{name} был(а) удален(а) :)");
        }

    //Task 1
        public static void Main()
        {
            List<Student> students = new List<Student>
            {
                new Student("Николенко", new DateTime(2005, 4, 22), "612"),
                new Student("Зара", new DateTime(2005, 4, 14), "412"),
                new Student("Павлова", new DateTime(2005, 3, 19), "612"),
                new Student("Олейникова", new DateTime(2005, 5, 10), "612")
            };

            for (int i = 0; i < students.Count; ++i)
            {
                Console.Write($"Студент(ка): {students[i].surName}, " +
                              $"Дата рождения: {students[i].dateBirth}, " +
                              $"Группа: {students[i].groupNumb}, " +
                              $"Оценки: ");
                Print(students[i].perfomance);
                Console.WriteLine();
            }

            students[2].surName = "Павлова";
            students[3].dateBirth = new DateTime(2005, 3, 10);
            students[1].groupNumb = "612";

            Student studentCheck = new Student("", DateTime.Now, "");

            Console.Write("Введите фамилию студента(ки): ");
            studentCheck.surName = Console.ReadLine();

            Console.Write("Введите дату рождения студента(ки) (d.m.yyyy): ");
            studentCheck.dateBirth = Convert.ToDateTime(Console.ReadLine());

            for (int i = 0; i < students.Count; ++i)
            {
                if (students[i].surName == studentCheck.surName && students[i].dateBirth == studentCheck.dateBirth)
                {
                    Console.Write($"Студент: {students[i].surName}\n" +
                                  $"Дата рождения: {students[i].dateBirth}\n" +
                                  $"Группа: {students[i].groupNumb}\n" +
                                  $"Оценки: ");
                    Print(students[i].perfomance);
                    break;
                }
            }
        }
        
    //Task 2    
        // public static void Main()
        // {
        //     List<Train> trains = new List<Train>()
        //     {
        //         new Train("Юрга - Томск", 45, DateTime.Now),
        //         new Train("Юрга - Владивосток", 234, new DateTime(2023, 4, 10, 14, 15, 00)),
        //         new Train("Юрга - Москва", 574, new DateTime(2023, 4, 11, 16, 00, 00))
        //     };
        //
        //     for (int i = 0; i < trains.Count; ++i)
        //     {
        //         Console.WriteLine($"Название поезда: {trains[i].destinationName}, Номер: {trains[i].trainNum}");
        //     }
        //
        //     Console.WriteLine();
        //     Console.Write("Введите номер поезда: ");
        //     int trainNum = Convert.ToInt32(Console.ReadLine());
        //
        //     for (int i = 0; i < trains.Count; ++i)
        //     {
        //         if (trains[i].trainNum == trainNum)
        //         {
        //             Console.WriteLine($"Название поезда: {trains[i].destinationName}\n" +
        //                               $"Номер: {trains[i].trainNum}\n" +
        //                               $"Время отправления: {trains[i].timeToStart}");
        //         }
        //     }
        // }
        //
    //Task 3    
        // public static void Main()
        // {
        //     Numbs numbs = new Numbs(5, 13);
        //
        //     numbs.Print(numbs.a);
        //     numbs.Print(numbs.b);
        //
        //     numbs.a = numbs.ChangeNumb(numbs.a);
        //     numbs.b = numbs.ChangeNumb(numbs.b);
        //
        //     Console.WriteLine($"Sum: {numbs.SumNumbs(numbs.a, numbs.b)}");
        //
        //     Console.WriteLine($"Greater numb: {numbs.CompareNumbs(numbs.a, numbs.b)}");
        //
        // }
        //
    //Task 4    
        // public static void Main()
        // {
        //     Counter counter = new Counter();
        //     Console.Write("Введите начальное значение счетчика: ");
        //     counter.i = Convert.ToInt32(Console.ReadLine());
        //     Console.WriteLine(counter.i);
        //
        //     while (counter.i != 10 & counter.i < 10)
        //     {
        //         counter.Increase();
        //     }
        //
        //     Console.WriteLine(counter.i);
        //
        //     while (counter.i != 5)
        //     {
        //         counter.Reduce();
        //     }
        //
        //     Console.WriteLine(counter.i);
        // }
        //
    //Task 5    
        // public static void Main()
        // {
        //     Person nastya = new Person("Настя", 17);
        //     Person vika = new Person("Вика", 18);
        //     Person noname = new Person();
        //
        //     try
        //     {
        //         Console.WriteLine(nastya.name + ' ' + nastya.age);
        //         Console.WriteLine(vika.name + ' ' + vika.age);
        //         Console.WriteLine(noname.name + ' ' + noname.age);
        //     }
        //     finally
        //     {
        //         nastya.Dispose();
        //         vika.Dispose();
        //         noname.Dispose();
        //     }
        // }

        public static void Print(int[] list)
        {
            for (int i = 0; i < list.Length; ++i)
            {
                Console.Write($"{list[i]} ");
            }
        }
    }
}