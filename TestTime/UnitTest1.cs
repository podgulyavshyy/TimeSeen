namespace TestTime;
using ClassLibTime;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // test correct last seen message, test DateGetter function
        DateTime lastSeenTest = new DateTime(2023, 03, 02, 9, 5, 23);
        string message = TimeSeenMain.DateGetter(lastSeenTest);
        Assert.Equal("long time ago", message);
    }
}