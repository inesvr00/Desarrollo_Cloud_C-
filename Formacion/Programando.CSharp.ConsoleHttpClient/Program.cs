﻿using System.Net;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Programando.CSharp.ConsoleEF.Model;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Text;


namespace Programando.CSharp.ConsoleHttpClient
{
    internal class Program
    {
        private static HttpClient _httpClient;

        static void Main(string[] args)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5034/api/");
            //_httpClient.BaseAddress = new Uri("http://api.zippopotam.us/es/");

            PostCustomer();
        }

        static void Eco()
        { 
            var http = new HttpClient();
            http.BaseAddress = new Uri("https://postman-echo.com/");

            http.DefaultRequestHeaders.Clear();
            http.DefaultRequestHeaders.Add("X-Param1", "Demo");
            http.DefaultRequestHeaders.Add("X-Param2", "Demo");
            http.DefaultRequestHeaders.Add("User Agent", "HttpClient .NET Core");

            http.DefaultRequestHeaders.Add("Accept", "application/json");
            http.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var obj = new { Nombre = "Inés Victoria", Country = "Spain" };
            var body = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            var response = http.PostAsync("post?p1=demo1&p2=demo2", body).Result;
            if(response.StatusCode == HttpStatusCode.OK)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(data);
            }
        }
        static void GetCustomers()
        {
            Console.Clear();
            Console.Write("ID Cliente:");
            var id = Console.ReadLine();

            // Realizamos una llamada GET al microservicio y obtenemos la respuesta
            HttpResponseMessage response = _httpClient.GetAsync($"customers/{id}").Result;

            // Analizamos el código HTTP de respuesta

            // IsSuccessStatusCode es TRUE si la llamada retorna código de estado entre 200 y 299
            if (response.IsSuccessStatusCode)
            { }

            // Buscamos que la respuesta sea HttpStatusCode.OK equivalente a 200
            if (response.StatusCode == HttpStatusCode.OK)
            {
                // Recuperamos el contenido del cuerpo del mensaje en formato JSON
                string data = response.Content.ReadAsStringAsync().Result;

                // Convertimos el JSON en un Objeto
                Customer cliente = JsonConvert.DeserializeObject<Customer>(data);

                Console.WriteLine($"Cliente: {cliente.CompanyName} - {cliente.Country}");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");
        }

        static void GetCustomers2()
        {
            Console.Clear();
            Console.Write("ID Cliente:");
            var id = Console.ReadLine();

            // Realizamos una llamada GET al microservicio y obtenemos la respuesta
            var response = _httpClient.GetAsync($"customers/{id}").Result;


            // Buscamos que la respuesta sea HttpStatusCode.OK equivalente a 200
            var cliente = response.StatusCode == HttpStatusCode.OK ?
                JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result) :
                null;

            if (cliente != null)
                Console.WriteLine($"Cliente: {cliente.CompanyName} - {cliente.Country}");
        }

        static void GetCustomers3()
        {
            Console.Clear();
            Console.Write("ID Cliente:");
            var id = Console.ReadLine();

            // Realizamos una llamada GET al microservicio y obtenemos la respuesta
            var response = _httpClient.GetAsync($"customers/{id}").Result;


            // Buscamos que la respuesta sea HttpStatusCode.OK equivalente a 200
            var cliente = response.StatusCode == HttpStatusCode.OK ?
                JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result) :
                null;

            if (cliente != null)
                Console.WriteLine($"Cliente: {cliente["CompanyName"]} - {cliente["Country"]}");

        }
        static void GetCustomers4()
        {
            Console.Clear();
            Console.Write("ID Cliente: ");
            var id = Console.ReadLine();

            Customer cliente = _httpClient.GetFromJsonAsync<Customer>($"customers/{id}").Result;

            if (cliente != null) Console.WriteLine($"Cliente: {cliente.CompanyName} - País: {cliente.Country}");
            else Console.WriteLine("Cliente no encontrado");
        }

        static void PostCustomer()
        {
            Customer cliente = new Customer()
            {
                CustomerID = "DD022",
                CompanyName = "Empresa DD022, SL",
                ContactName = "Inés Victoria",
                City = "Las Palmas GC",
                Country = "Spain"
            };

            string clienteJSON = JsonConvert.SerializeObject(cliente);

            StringContent contenido = new StringContent(clienteJSON, Encoding.UTF8, "application/json");

            HttpResponseMessage response = _httpClient.PostAsync("customers", contenido).Result;
            if (response.StatusCode == HttpStatusCode.Created)
            {
                Customer data = JsonConvert.DeserializeObject<Customer>(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine($"Creado el cliente {data.ContactName} con compañía {data.CompanyName}");
            }
            else Console.WriteLine($"Error: {response.StatusCode}");


        }

        static void PutCustomer()
        {
            Console.Clear();
            Console.Write("ID Cliente: ");
            string id = Console.ReadLine();

            var cliente = _httpClient.GetFromJsonAsync<Customer>($"customer/{id}").Result;

            cliente.ContactName = "María Antonia";
            cliente.Phone = "928 409 092";

            string clienteJSON = JsonConvert.SerializeObject(cliente);
            StringContent contenido = new StringContent(clienteJSON, Encoding.UTF8, "application/json");


        }

        static void DeleteCustomers()
        {
            Console.Clear();
            Console.Write("ID Cliente: ");
            string id = Console.ReadLine();

            HttpResponseMessage response = _httpClient.DeleteAsync($"customer/{id}/").Result;

            if (response.StatusCode  == HttpStatusCode.NoContent)
            {
                Console.WriteLine("No content");
            }

            var cliente = _httpClient.GetFromJsonAsync<Customer>($"customer/{id}").Result;

        }

        static void GetCustomersPostalCode()
        {
            Console.Clear();
            Console.Write("Código Postal: ");
            string code = Console.ReadLine();

            var response = _httpClient.GetAsync($"es/{code}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var info = JsonConvert.DeserializeObject<PostalCodeInfo>(data);

                Console.WriteLine($"{info.Country} - {info.CountryAbbreviation}");
                foreach (var item in info.Places)
                {
                    Console.WriteLine($" -> {item.PlaceName} ({item.State})");
                }
            }
            else Console.WriteLine($"Error: {response.StatusCode.ToString()}");
        }

        static void GetCustomersPostalCode1b()
        {
            Console.Clear();
            Console.Write("Código Postal: ");
            string code = Console.ReadLine();

            var response = _httpClient.GetAsync($"es/{code}").Result;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                var info = JsonConvert.DeserializeObject<dynamic>(data);

                Console.WriteLine($"{info.country} - {info["country abbreviation"]}");
                foreach (var item in info.places)
                {
                    Console.WriteLine($" -> {item["place name"]} ({item.state})");
                }
            }
            else Console.WriteLine($"Error: {response.StatusCode.ToString()}");
        }

        static void GetCustomersPostalCode2()
        {
            Console.Clear();
            Console.Write("Código Postal: ");
            string code = Console.ReadLine();

            var info = _httpClient.GetFromJsonAsync<PostalCodeInfo>($"es/{code}").Result;

            Console.WriteLine($"{info.Country} - {info.CountryAbbreviation}");
            foreach (var item in info.Places)
            {
                Console.WriteLine($" -> {item.PlaceName} ({item.State})");
            }
        }

        static void GetCustomersPostalCode2b()
        {
            Console.Clear();
            Console.Write("Código Postal: ");
            string code = Console.ReadLine();

            var info = _httpClient.GetFromJsonAsync<dynamic>($"es/{code}").Result;

            Console.WriteLine($"{info["country"]} - {info["country abbreviation"]}");
            foreach (var item in info["places"])
            {
                Console.WriteLine($" -> {item["place name"]} ({item["state"]})");
            }
        }

        static void GetCustomersEMT()
        {
            var xClientId = "1dc96c7e-3a0f-4c13-86fe-ad08013a6df3";
            var passKey = "4696A912D79283E6BE01CC320D786CBCD80C5902433783AA9CA1F12DB323C0EF5238E31B202E56348FFE0A37D1C5BA2DB4B627DBEFD7226D720A68D28A883E16";
        }
    
        
    }

    public class PostalCodeInfo
    {
        [JsonProperty("post code")]
        [JsonPropertyName("post code")]
        public string PostCode { get; set; }

        public string Country { get; set; }

        [JsonProperty("country abbreviation")]
        [JsonPropertyName("country abbreviation")]
        public string CountryAbbreviation { get; set; }

        public List<PostalCodePlace> Places { get; set; }
        //public List<Dictionary<string, string>> Places { get; set; }
    }

    public class PostalCodePlace
    {
        [JsonProperty("place name")]
        [JsonPropertyName("place name")]
        public string PlaceName { get; set; }

        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string State { get; set; }

        [JsonProperty("state abbreviation")]
        [JsonPropertyName("state abbreviation")]
        public string StateAbbreviation { get; set; }
    }
}
