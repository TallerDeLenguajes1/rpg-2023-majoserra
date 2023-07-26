namespace EspacioTrivia;
using System.Net;
using System.Text.Json;

class obtenerTrivia
{

    public static Root Trivia()
    {
        var url = $"https://opentdb.com/api.php?amount=10&category=17&difficulty=easy&type=boolean";
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = "application/json";
        request.Accept = "application/json";
        Root trivia = null;
        using (WebResponse response = request.GetResponse())
        {
            using (Stream strReader = response.GetResponseStream())
            {
                if (strReader == null) return trivia;
                using (StreamReader objReader = new StreamReader(strReader))
                {
                    string responseBody = objReader.ReadToEnd();
                    trivia = JsonSerializer.Deserialize<Root>(responseBody);
                }
            }
        }
        return trivia;
    }
}