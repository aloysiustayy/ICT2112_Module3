using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DomainLayer.Interface;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;

namespace DataSourceLayer.Gateway
{
    public class OCR_API_TDG : IOCR_API_TDG
    {
        public async Task<string> DetectText(string base64EncodedImage)
        {
            var serviceAccountPath = "C:\\Users\\CPZ\\Documents\\tidal-anvil-230402-dfe950b3753e.json";

            // Authenticate with the service account
            var credential = GoogleCredential.FromFile(serviceAccountPath)
                .CreateScoped("https://www.googleapis.com/auth/cloud-vision");

            // Obtain an access token
            var token = await (credential as ITokenAccess).GetAccessTokenForRequestAsync();

            // Prepare the request
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var requestBody = new
            {
                requests = new[]
                {
                    new
                    {
                        image = new {content = base64EncodedImage},
                        features = new[] {new {type = "TEXT_DETECTION"}}
                    }
                }
            };

            var jsonContent = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");

            // Make the POST request to the Vision API
            var response = await httpClient.PostAsync("https://vision.googleapis.com/v1/images:annotate", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }
    }
}