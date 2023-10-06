namespace TestTime;
using ClassLibTime;

public class Test
{

    [Fact]
    public async void Test2()
    {
        // // test ReturnDate function through mock json (online case)
        Dictionary<int, string> test = await TimeSeenMain.DataGetter();
        Assert.Equal("User is online", "");
    }
}