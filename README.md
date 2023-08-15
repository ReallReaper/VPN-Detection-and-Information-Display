# **Description:**

### **English:**
This C# program detects whether a public IP address belongs to a Virtual Private Network (VPN) and displays detailed information about the location and VPN status. It utilizes the vpnapi.io API to retrieve information about the IP address, including whether it belongs to a VPN, proxy, Tor, or relay.

## **Features:**
- Retrieves the current public IP address of the device.
- Sends a request to the vpnapi.io API to determine if the IP address is associated with a VPN.
- If a VPN is detected, it displays detailed information, including location and security properties.
- If no VPN is detected, it shows a message indicating that the IP address is not from a VPN.
- Includes a 10-second delay before exiting the application.

## **Components:**
- `GetPublicIPAddress()`: Retrieves the current public IP address using the ipify.org API.
- `DetectVPN(string ipAddress, string apiKey)`: Detects if the IP address is from a VPN using the vpnapi.io API.
- `Main(string[] args)`: The main function that handles the program logic.
- It uses the `System.Net.Http` and `Newtonsoft.Json.Linq` libraries to perform HTTP requests and parse JSON responses.

This program is useful for identifying whether an IP address is masked by a VPN service and for obtaining additional information about its location and security.

### **Spanish:**
Este programa en C# detecta si una dirección IP pública pertenece a una Red Privada Virtual (VPN) y muestra información detallada sobre la ubicación y el estado de la VPN. Utiliza la API vpnapi.io para obtener información sobre la dirección IP, incluyendo si pertenece a un VPN, proxy, Tor o relay.

## **Características:**
- Obtiene la dirección IP pública actual del dispositivo.
- Envía una solicitud a la API de vpnapi.io para determinar si la dirección IP está asociada a una VPN.
- Si se detecta una VPN, muestra información detallada, incluyendo la ubicación y las propiedades de seguridad.
- Si no se detecta una VPN, muestra un mensaje indicando que la dirección IP no proviene de un VPN.
- Incluye un retraso de 10 segundos antes de salir de la aplicación.

## **Componentes:**
- `GetPublicIPAddress()`: Obtiene la dirección IP pública actual utilizando la API de ipify.org.
- `DetectVPN(string ipAddress, string apiKey)`: Detecta si la dirección IP proviene de una VPN utilizando la API de vpnapi.io.
- `Main(string[] args)`: La función principal que maneja la lógica del programa.
- Utiliza las bibliotecas `System.Net.Http` y `Newtonsoft.Json.Linq` para realizar solicitudes HTTP y analizar respuestas JSON.

Este programa es útil para identificar si una dirección IP está oculta detrás de un servicio de VPN y para obtener información adicional sobre su ubicación y seguridad.
