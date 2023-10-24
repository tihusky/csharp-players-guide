var computationResult = await DoWork();

Console.WriteLine(computationResult);

Task<int> AddOnEuropa(int a, int b)
{
    return Task.Run(() =>
    {
        Thread.Sleep(3000);
        return a + b;
    });
}

async Task<int> DoWork()
{
    var res1 = await AddOnEuropa(2, 3);
    var res2 = await AddOnEuropa(4, 5);
    var res3 = await AddOnEuropa(res1, res2);

    return res3;
}