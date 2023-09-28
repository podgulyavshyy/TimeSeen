namespace TestTime;
using ClassLibTime;

public class ReturnDateTestOnline
{
    [Fact]
    public void Test2()
    {
        // // test ReturnDate function through mock json (online case)
        string mockJson =
            "{\n  \"total\": 1,\n  \"data\": [\n    {\n      \"userId\": \"string\",\n      \"nickname\": \"string\",\n      \"firstName\": \"string\",\n      \"lastName\": \"string\",\n      \"registrationDate\": \"2023-09-28T16:00:16.507Z\",\n      \"lastSeenDate\": \"2023-09-28T16:00:16.507Z\",\n      \"isOnline\": true\n    }\n  ]\n}";
        string message = TimeSeenMain.ReturnDate(mockJson);
        Assert.Equal("User is online", message);
    }
}