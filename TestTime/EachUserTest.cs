namespace TestTime;
using ClassLibTime;

public class EachUserTest
{
    [Fact]
    public void EachUserTestFunc()
    {
        //Arrange
        Dictionary<int, string> testDictionary = new Dictionary<int, string>();
        testDictionary.Add(1, "{\n  \"total\": 1,\n  \"data\": [\n    {\n      \"userId\": \"string\",\n      \"nickname\": \"string\",\n      \"firstName\": \"string\",\n      \"lastName\": \"string\",\n      \"registrationDate\": \"2023-09-28T16:00:16.507Z\",\n      \"lastSeenDate\": \"2023-09-28T16:00:16.507Z\",\n      \"isOnline\": true\n    }\n  ]\n}");
        //Act
        string test = TimeSeenMain.EachUser(testDictionary);
        //Assert
        Assert.Equal("User is online", test);
    }
}