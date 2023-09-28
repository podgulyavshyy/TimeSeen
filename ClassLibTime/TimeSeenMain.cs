namespace ClassLibTime;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class TimeSeenMain
{
    static async Task Main()
    {

        using (HttpClient httpClient = new HttpClient())
        {
            try
            {

                string apiUrl = "https://sef.podkolzin.consulting/api/users/lastSeen?offset=1";

                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);


                if (response.IsSuccessStatusCode)
                {

                    string jsonContent = await response.Content.ReadAsStringAsync();


                    //Console.WriteLine(jsonContent);
                    ReturnDate(jsonContent);
                }
                else
                {
                    Console.WriteLine($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }

    public static void ReturnDate(string jsonData)
    {
        var data = JsonConvert.DeserializeObject<Return>(jsonData);

        if (data != null && data.data != null && data.data.Count > 0)
        {
            foreach (var user in data.data)
            {
                string nickname = user.nickname;
                string lastName = user.lastName;
                

                Console.WriteLine("Nickname: " + nickname);
                Console.WriteLine("Is Online " + user.isOnline);
                Console.WriteLine("Is Online " + user.lastSeenDate);
                if (user.isOnline == false)
                {
                    Console.WriteLine(DateGetter(user.lastSeenDate ?? DateTime.UtcNow));
                }
                Console.WriteLine();
            }
        }

    }

    public static string DateGetter(DateTime lastSeen)
    {
        DateTime currentUtcDateTime = DateTime.Now;
        int delta = (lastSeen - currentUtcDateTime).Duration().Seconds;

        if (delta < 30)
        {
            return "just now";
        }
        if (30 << delta < 60)
        {
            return "less than a minute ago";
        }
        if (60 << delta < 3540)
        {
            return "couple of minutes ago";
        }
        if (3540 << delta < 7140)
        {
            return "hour ago";
        }
        if (7140 < delta || DateTime.Today == lastSeen.Date)
        {
            return "today";
        } 
        if (7140 < delta || DateTime.Today != lastSeen.Date)
        {
            return "yesterday";
        }
        if (604800 < delta)
        {
            return "this week";
        }
        return "long time ago";
    }

    public static string test()
    {
        return "test";
    }
}