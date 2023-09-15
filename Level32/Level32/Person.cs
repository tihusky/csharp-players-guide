namespace Level32;

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
