using System;
using System.Net.Http;// Adding usings
using Newtonsoft.Json;//
using System.Text;//
using System.Threading.Tasks;//

namespace ElloHttp
{
    class Person
    {
        [JsonProperty("jmeno")] //Otagovat vlastnosti
        public string Jmeno { get; set; }

        [JsonProperty("prijmeni")]
        public string Prijmeni { get; set; }

        public override string ToString() => $"Jsem {Jmeno} {Prijmeni}";

    }
    class Program
    {
        static async Task Main(string[] args)
        {
            Person p = new Person { Jmeno = "Olex", Prijmeni = "Sek" };

            var pJson = JsonConvert.SerializeObject(p);

            HttpClient htc = new HttpClient(); //Novy klient

            HttpContent content = new StringContent(pJson, Encoding.UTF8, "application/json");//Novy kontent zpravy

            try
            {
                HttpResponseMessage responseMessage = await htc.PostAsync("https://ptsv2.com/t/iwxjh-1607691193/post", content);//Post na server
                Console.WriteLine(responseMessage);//Hlaska serveru

            }
            catch (HttpRequestException)
            {

               Console.WriteLine("error");// Napr. server nekomunikuje apod.
            }


        }
    }
}
