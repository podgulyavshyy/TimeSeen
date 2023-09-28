namespace TestTime;
using ClassLibTime;

public class UnitTest2
{
    [Fact]
    public void Test1()
    {
        // test if user is online
        string mockJson =
            "{\n  \"total\": 1,\n  \"data\": [\n    {\n      \"userId\": \"string\",\n      \"nickname\": \"string\",\n      \"firstName\": \"string\",\n      \"lastName\": \"string\",\n      \"registrationDate\": \"2023-09-28T16:00:16.507Z\",\n      \"lastSeenDate\": \"2023-09-28T16:00:16.507Z\",\n      \"isOnline\": true\n    }\n  ]\n}";
        string message = TimeSeenMain.ReturnDate(mockJson);
        Assert.Equal("User is online", message);
    }
}