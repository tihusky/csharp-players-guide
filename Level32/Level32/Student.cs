namespace Level32;

public class Student
{
    public string Name { get; }
    public Dictionary<string, int> Grades { get; } = new();

    public Student(string name)
    {
        Name = name;
    }

    public void AddGrade(string courseName, int grade)
    {
        Grades[courseName] = grade;
    }
}
