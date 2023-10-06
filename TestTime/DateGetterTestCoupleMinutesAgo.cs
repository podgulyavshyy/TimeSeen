namespace TestTime;
using ClassLibTime;

public class DateGetterTestCoupleMinutesAgo
{
    [Fact]
    public void DateGetterTestMinuteAgoFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(1000);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        //Act
        string test = TimeSeenMain.DateGetter(dateTime30SecondsAgo, Settings.setLanguage());
        //Assert
        Assert.Equal("couple of minutes ago", test);
    }
}