namespace TestTime;
using ClassLibTime;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        
        string message = TimeSeenMain.test();
        Assert.Equal("test", message);
    }
}