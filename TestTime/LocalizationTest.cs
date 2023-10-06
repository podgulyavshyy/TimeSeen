namespace TestTime;
using ClassLibTime;

public class LocalizationTest
{
    [Fact]
    public void LocalizationTestFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(170000);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        //Act
        string test = TimeSeenMain.DateGetter(dateTime30SecondsAgo, 1);
        //Assert
        Assert.Equal("вчора", test);
    }
}