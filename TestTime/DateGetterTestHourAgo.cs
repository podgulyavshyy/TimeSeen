namespace TestTime;
using ClassLibTime;

public class DateGetterTestHourAgo
{
    [Fact]
    public void DateGetterTestHourAgoFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(4000);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        //Act
        string test = TimeSeenMain.DateGetter(dateTime30SecondsAgo, Settings.setLanguage());
        //Assert
        Assert.Equal("hour ago", test);
    }
}