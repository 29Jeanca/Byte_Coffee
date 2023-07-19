using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using System.IO;

namespace Byte_Coffee.Clases
{
    public class ImgurUploader
    {

        private const string ClientId = "9b402cbf6f8d889";
        private const string ClientSecret = "9faa8d3359ba574e3c80789d5f5cd72a0edfe6f3";
        private const string ApiEndpoint = "https://api.imgur.com/3/upload";

        public static string ImageUrl { get; private set; }


        public static async Task<string> UploadImageAsync(string imagePath)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.imgur.com/3/image");
            request.Headers.Add("Authorization", $"Client-ID {ClientId}");

            byte[] imageBytes = File.ReadAllBytes(imagePath);
            string base64Image = Convert.ToBase64String(imageBytes);
            var content = new MultipartFormDataContent();
            content.Add(new StringContent(base64Image), "image");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();

            JObject jsonResponse = JObject.Parse(responseContent);
            return jsonResponse["data"]["link"].ToString();
        }
    }
}