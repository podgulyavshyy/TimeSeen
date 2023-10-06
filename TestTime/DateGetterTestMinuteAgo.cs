namespace TestTime;
using ClassLibTime;

public class DateGetterTestMinuteAgo
{
    [Fact]
    public void DateGetterTestMinuteAgoFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(45);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        //Act
        string test = TimeSeenMain.DateGetter(dateTime30SecondsAgo, Settings.setLanguage());
        //Assert
        Assert.Equal("less than a minute ago", test);
    }
}