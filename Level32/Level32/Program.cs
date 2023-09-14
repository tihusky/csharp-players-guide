Person p = new Person("Mirko", new DateTime(1987, 7, 20));

Console.WriteLine($"{p.Name} was born on a {p.BirthDate.DayOfWeek}.");
Console.WriteLine($"They are {p.Age} years old.");

/***** Type Definitions *****/

public class Person
{
    public string Name { get; }
    public DateTime BirthDate { get; }

    public int Age
    {
        get
        {
            DateTime now = DateTime.Now;
            TimeSpan delta = now - BirthDate;

            return (int)(delta.TotalDays / 365);
        }
    }

    public Person(string name, DateTime birthDate)
    {
        Name = name;
        BirthDate = birthDate;
    }
}