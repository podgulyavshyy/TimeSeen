using System.Reflection.Metadata;

namespace ClassLibTime;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class TimeSeenMain
{
    public static List<UserData> Users { get; set; }

    static TimeSeenMain()
    {
        Users = new List<UserData>();
    }

    public static async Task Main()
    {


    }

    public static async Task<Dictionary<int, string>> DataGetter()
    {
        int currentOffset = Settings.setOffset();
        int targetOffset = 20;
        Dictionary<int, string> dataDictionary = new Dictionary<int, string>();
        while (true)
        {
            if (currentOffset == targetOffset)
            {
                break;
            }

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {

                    string apiUrl = $"https://sef.podkolzin.consulting/api/users/lastSeen?offset={currentOffset}";

                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {

                        string jsonContent = await response.Content.ReadAsStringAsync();


                        //Console.WriteLine(jsonContent);
                        //ReturnDate(jsonContent);
                        dataDictionary.Add(currentOffset, jsonContent);
                    }
                    else
                    {
                        Console.WriteLine($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                    break;
                }
            }

            currentOffset++;

        }

        return dataDictionary;
    }

    public static string EachUser(Dictionary<int, string> usersDictionary)
    {
        foreach (var userDict in usersDictionary)
        {
            var data = JsonConvert.DeserializeObject<Return>(userDict.Value);
            foreach (var user in data.data)
            {
                if (user.isOnline == false)
                {


                    // Console.WriteLine(DateGetter(user.lastSeenDate ?? DateTime.UtcNow));
                    return DateGetter(user.lastSeenDate ?? DateTime.UtcNow, Settings.setLanguage());
                }
                else
                {
                    //Console.WriteLine("User is online");
                    return "User is online";
                }
            }
        }

        return "";
    }

    public static Dictionary<double, DateTime> Calculations(DateTime lastSeen)
    {
        DateTime currentUtcDateTime = DateTime.Now;
        var delta = (currentUtcDateTime - lastSeen).TotalSeconds;
        Dictionary<double, DateTime> returnDict = new Dictionary<double, DateTime>();
        returnDict.Add(delta, lastSeen);
        return returnDict;
    }

    public static string DateGetter(DateTime lastSeen, int lang)
    {
        Dictionary<double, DateTime> timeDeltaAndLS = Calculations(lastSeen);
        double timeDelta = timeDeltaAndLS.Keys.First();
        DateTime LS = timeDeltaAndLS[timeDelta];
        
        if (lang == 0)
        {
            if (timeDelta < 30)
            {
                return "just now";
            }

            if (30 < timeDelta && timeDelta < 60)
            {
                return "less than a minute ago";
            }

            if (60 < timeDelta && timeDelta < 3540)
            {
                return "couple of minutes ago";
            }

            if (3540 < timeDelta && timeDelta < 7140)
            {
                return "hour ago";
            }

            if (7140 < timeDelta && timeDelta < 172800 && DateTime.Today == LS.Date)
            {
                return "today";
            }

            if (7140 < timeDelta && timeDelta < 172800 && DateTime.Today != LS.Date)
            {
                return "yesterday";
            }

            if (172800 < timeDelta && timeDelta < 604800)
            {
                return "this week";
            }

            return "long time ago";
        }

        if (lang == 1)
        {
            if (timeDelta < 30)
            {
                return "щойно";
            }

            if (30 < timeDelta && timeDelta < 60)
            {
                return "менше хвилини тому";
            }

            if (60 < timeDelta && timeDelta < 3540)
            {
                return "декілька хвилин тому";
            }

            if (3540 < timeDelta && timeDelta < 7140)
            {
                return "годину тому";
            }

            if (7140 < timeDelta && timeDelta < 172800 && DateTime.Today == LS.Date)
            {
                return "сьогодні";
            }

            if (7140 < timeDelta && timeDelta < 172800 && DateTime.Today != LS.Date)
            {
                return "вчора";
            }

            if (172800 < timeDelta && timeDelta < 604800)
            {
                return "цього тижня";
            }

            return "давно";
        }

        return "";
    }
}