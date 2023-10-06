namespace TestTime;
using ClassLibTime;

public class CalculationsTest
{
    [Fact]
    public void CalculationsTestFunc()
    {
        //Arrange
        DateTime currentUtcDateTime = DateTime.Now;
        TimeSpan timeSpan = TimeSpan.FromSeconds(30);
        DateTime dateTime30SecondsAgo = currentUtcDateTime - timeSpan;
        Dictionary<double, DateTime> target = new Dictionary<double, DateTime>();
        target.Add(30, dateTime30SecondsAgo);
        //Act
        Dictionary<double, DateTime> test = TimeSeenMain.Calculations(dateTime30SecondsAgo);
        //Assert
        Assert.Equal(target, test);
        // the actual value has milliseconds after it since program takes some time to run
    }

}