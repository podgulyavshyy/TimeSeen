namespace TestTime;
using ClassLibTime;

public class DateGetterTestLongTimeAgo
{
    [Fact]
    public void DateGetterTestLongTimeAgoFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(1000000000);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        //Act
        string test = TimeSeenMain.DateGetter(dateTime30SecondsAgo, Settings.setLanguage());
        //Assert
        Assert.Equal("long time ago", test);
    }
}