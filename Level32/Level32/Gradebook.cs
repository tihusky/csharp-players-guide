using System.Collections;

namespace Level32;

public class Gradebook : IEnumerable, IEnumerator
{
    private readonly List<Student> _students = new();
    private int _currentIndex = -1;

    object IEnumerator.Current
    {
        get
        {
            return Current;
        }
    }

    public Student Current
    {
        get
        {
            if (_currentIndex < _students.Count)
            {
                return _students[_currentIndex];
            }
            
            throw new IndexOutOfRangeException();
        }
        
    }

    public void Add(Student student)
    {
        _students.Add(student);
    }

    public void Reset()
    {
        _currentIndex = -1;
    }

    public bool MoveNext()
    {
        _currentIndex++;

        return _currentIndex < _students.Count;
    }

    public IEnumerator GetEnumerator() => this;
}
