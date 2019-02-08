using RestSharp;
using System;
using System.IO;
using System.Reflection;

namespace AuthExample
{
    public class AuthExample
    {

        static void Main(string[] args)
        {
            IRestClient client = new RestClient("http://localhost:5000");

            Console.WriteLine("Fetch SAML token from IDP [Enter]");
            Console.ReadLine();
            var samlResponseFromIdp = GetSamlResponseFromIdp();

            Console.WriteLine("Get session cookie [Enter]");
            Console.ReadLine();

            var sessionCookie = GetSessionCookie(client, samlResponseFromIdp);
            System.Console.WriteLine("Got session-id: [ " + sessionCookie + " ]");
        }

        private static string GetSamlResponseFromIdp()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "AuthExample.Resources.SAMLResponseFromIdp.xml";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        private static string GetSessionCookie(IRestClient client, string samlResponseFromIdp)
        {
            var request = new RestRequest("/api/incoming/Authorization/", Method.POST);
            request.AddJsonBody(samlResponseFromIdp);
            var response = client.Execute(request);
            return response.Cookies[0].Value;
        }
    }
}
/*
        public static void UpdateThemeEvent()
        {
            System.Console.WriteLine("Send [Update Theme] event");
            System.Console.ReadLine();
            // CMS sent a theme update event
            var request = new RestRequest("/api/incoming/Theme/" + _testData.ThemeId, Method.PUT);
            request.AddJsonBody(new Theme()
            {
                Id = _testData.ThemeId,
                Name = "Space"
            });
            request.AddCookie("session-id", _testData.SessionCookie);

            LogRequest(request);
            LogResponse(_client.Execute(request));
        }

        public static void ListVideos()
        {
            System.Console.WriteLine("Send [List Video]");
            System.Console.ReadLine();
            // Developer enquiries about the available videos
            var request = new RestRequest("/api/Metadata");
            request.AddCookie("session-id", _testData.SessionCookie);

            LogRequest(request);
            LogResponse(_client.Execute(request));
        }

        public static void GetVideo()
        {
            System.Console.WriteLine("Send [Get Video]");
            System.Console.ReadLine();
            // Developer enquiries about the available videos
            var request = new RestRequest("/api/Metadata/" + _testData.CmsContentId);
            request.AddCookie("session-id", _testData.SessionCookie);

            LogRequest(request);
            LogResponse(_client.Execute(request));
        }

        
        private static void LogRequest(IRestRequest request)
        */
