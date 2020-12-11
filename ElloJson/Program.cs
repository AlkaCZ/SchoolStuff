using System;
using Newtonsoft.Json; //Must add using

namespace ElloJson
{
    class Person
    {
        [JsonProperty("jmeno")] //Otagovat vlastnosti
       public  string Jmeno { get; set; }

        [JsonProperty("prijmeni")]
        public string Prijmeni { get; set; }

        public override string ToString() => $"Jsem {Jmeno} {Prijmeni}";

    }
    class Group //Class in class
    {
        [JsonProperty("mama")]
        public Person p1 { get; set; }

        [JsonProperty("tata")]
        public Person p2 { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Person olex = new Person { Jmeno = "Olex", Prijmeni = "Sek" };
            Person mira = new Person { Jmeno = "Mira", Prijmeni = "Palek" };

            Group g = new Group { p1 = olex, p2 = mira };

            //Konvertování do Jsonu aka. Serializace

            var JsonPerson = JsonConvert.SerializeObject(olex);
            var JsonGroup = JsonConvert.SerializeObject(g);

            Console.WriteLine(JsonPerson);
            Console.WriteLine(JsonGroup);
            //Konvertování z Jsonu do Person objektu aka. Deserizialzace
            Person test = JsonConvert.DeserializeObject<Person>(JsonPerson);

            Console.WriteLine(test);
            Console.ReadLine();

        }
    }
}
