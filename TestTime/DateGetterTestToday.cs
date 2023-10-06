namespace TestTime;
using ClassLibTime;

public class DateGetterTestToday
{
    [Fact]
    public void DateGetterTestTodayFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(9000);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        //Act
        string test = TimeSeenMain.DateGetter(dateTime30SecondsAgo, Settings.setLanguage());
        //Assert
        Assert.Equal("today", test);
    }
}