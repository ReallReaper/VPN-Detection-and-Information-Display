using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOU API KEY HERE!";

        // Obtener la dirección IP pública actual
        string ipAddress = await GetPublicIPAddress();
        Console.WriteLine($"Tu dirección IP pública es: {ipAddress}");

        bool vpnDetected = await DetectVPN(ipAddress, apiKey);

        if (vpnDetected)
        {
            Console.WriteLine("Se detectó que la dirección IP es de un VPN.");
            Console.WriteLine("Consola Exit in 10 Seconds");
            Thread.Sleep(10000);
        }
        else
        {
            Console.WriteLine("No se detectó que la dirección IP sea de un VPN.");
            Console.WriteLine("Consola Exit in 10 Seconds");
            Thread.Sleep(10000);
        }
    }

    static async Task<string> GetPublicIPAddress()
    {
        using (HttpClient client = new HttpClient())
        {
            string url = "https://api64.ipify.org?format=raw";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody.Trim();
            }
            else
            {
                Console.WriteLine("Error al obtener la dirección IP: " + response.StatusCode);
                return null;
            }
        }
    }

    static async Task<bool> DetectVPN(string ipAddress, string apiKey)
    {
        using (HttpClient client = new HttpClient())
        {
            string url = $"https://vpnapi.io/api/{ipAddress}?key={apiKey}";
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                var responseData = JObject.Parse(responseBody);
                var security = responseData["security"];
                bool vpnDetected = (bool)security["vpn"];
                bool proxyDetected = (bool)security["proxy"];
                bool torDetected = (bool)security["tor"];
                bool relayDetected = (bool)security["relay"];

                if (vpnDetected)
                {
                    var location = responseData["location"];
                    string city = (string)location["city"];
                    string region = (string)location["region"];
                    string country = (string)location["country"];
                    string continent = (string)location["continent"];
                    string regionCode = (string)location["region_code"];
                    string countryCode = (string)location["country_code"];
                    string continentCode = (string)location["continent_code"];
                    string latitude = (string)location["latitude"];
                    string longitude = (string)location["longitude"];
                    string timeZone = (string)location["time_zone"];
                    string localeCode = (string)location["locale_code"];
                    string metroCode = (string)location["metro_code"];
                    bool isInEuropeanUnion = (bool)location["is_in_european_union"];

                    Console.WriteLine($"VPN Detectado: {vpnDetected}");
                    Console.WriteLine($"Proxy Detectado: {proxyDetected}");
                    Console.WriteLine($"Tor Detectado: {torDetected}");
                    Console.WriteLine($"Relay Detectado: {relayDetected}");
                    Console.WriteLine($"Ubicación: {city}, {region}, {country}, {continent}");
                    Console.WriteLine($"Código de región: {regionCode}");
                    Console.WriteLine($"Código de país: {countryCode}");
                    Console.WriteLine($"Código de continente: {continentCode}");
                    Console.WriteLine($"Latitud: {latitude}, Longitud: {longitude}");
                    Console.WriteLine($"Zona horaria: {timeZone}");
                    Console.WriteLine($"Código local: {localeCode}");
                    Console.WriteLine($"Código de metro: {metroCode}");
                    Console.WriteLine($"¿Está en la Unión Europea?: {isInEuropeanUnion}");

                    return true;
                }
            }
            else
            {
                Console.WriteLine("Error en la solicitud API: " + response.StatusCode);
                Console.WriteLine("Consola Exit in 10 Seconds");
                Thread.Sleep(10000);
            }

            return false;
        }
    }
}
