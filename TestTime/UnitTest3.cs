namespace TestTime;
using ClassLibTime;

public class UnitTest3
{
    [Fact]
    public void Test3()
    {
        // test ReturnDate function through mock json (offline case)
        string mockJson =
            "{\n  \"total\": 1,\n  \"data\": [\n    {\n      \"userId\": \"string\",\n      \"nickname\": \"string\",\n      \"firstName\": \"string\",\n      \"lastName\": \"string\",\n      \"registrationDate\": \"2023-09-28T16:00:16.507Z\",\n      \"lastSeenDate\": \"2023-09-20T16:00:16.507Z\",\n      \"isOnline\": false\n    }\n  ]\n}";
        string message = TimeSeenMain.ReturnDate(mockJson);
        Assert.Equal("long time ago", message);
    }
}