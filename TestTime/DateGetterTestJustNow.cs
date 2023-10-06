namespace TestTime;
using ClassLibTime;

public class DateGetterTestJustNow
{
    [Fact]
    public void DateGetterTestJustNowFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(25);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        //Act
        string test = TimeSeenMain.DateGetter(dateTime30SecondsAgo, Settings.setLanguage());
        //Assert
        Assert.Equal("just now", test);
    }

}