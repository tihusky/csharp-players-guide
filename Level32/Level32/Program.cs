using Level32;

static void Test1()
{
    var p = new Person("Mirko", new DateTime(1987, 7, 20));

    Console.WriteLine($"{p.Name} was born on a {p.BirthDate.DayOfWeek}.");
    Console.WriteLine($"They are {p.Age} years old.");
}

static void Test2()
{
    var gradebook = new Gradebook();

    var s1 = new Student("Mirko");
    s1.AddGrade("Programming", 100);
    s1.AddGrade("English", 90);

    gradebook.Add(s1);

    var s2 = new Student("John");
    s2.AddGrade("Programming", 85);
    s2.AddGrade("English", 100);

    gradebook.Add(s2);

    foreach (Student s in gradebook)
    {
        Console.WriteLine($"{s.Name}'s Grades");
        Console.WriteLine("---------------------------");

        foreach ((string courseName, int grade) in s.Grades)
        {
            Console.WriteLine($"{courseName}: {grade}");
        }

        Console.WriteLine();
    }
}

static void Test3()
{
    var number = new Nullable<int>();

    if (number.HasValue)
    {
        Console.WriteLine($"The secret number is {number}.");
    }
    else
    {
        Console.WriteLine("The secret number hasn't been specified.");
    }
}

Test3();