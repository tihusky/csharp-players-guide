var numbers = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };
//var processed = ProcedualLens(numbers);
//var processed = KeywordLens(numbers);
var processed = MethodCallLens(numbers);

Console.ReadKey();

IEnumerable<int> ProcedualLens(int[] nums)
{
    var result = new List<int>();

    foreach (int n in nums)
    {
        if (IsEven(n))
        {
            result.Add(n * 2);
        }
    }

    result.Sort();
    return result;
}

IEnumerable<int> KeywordLens(int[] nums)
{
    return from n in nums
           where IsEven(n)
           orderby n
           select n * 2;
}

IEnumerable<int> MethodCallLens(int[] nums)
{
    return nums
            .Where(IsEven)
            .Order()
            .Select(n => n * 2);
}

bool IsEven(int n) => n % 2 == 0;

/* 
 * For a problem this small any of the three approaches seems fine to me.
 * The query expressions make the code quite a bit shorter though, so I can
 * see why some people prefer them.
 * 
 * To me personally the method call syntax seems more natural and fits the
 * style of the rest of the code, so it's my favorite.
 */