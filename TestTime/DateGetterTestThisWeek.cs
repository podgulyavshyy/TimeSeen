namespace TestTime;
using ClassLibTime;

public class DateGetterTestThisWeek
{
    [Fact]
    public void DateGetterTestThisWeekFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(500000);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        //Act
        string test = TimeSeenMain.DateGetter(dateTime30SecondsAgo, Settings.setLanguage());
        //Assert
        Assert.Equal("this week", test);
    }
}