using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DataSourceLayer.Interface;
using DomainLayer.Interface;
using Google.Apis.Auth.OAuth2;
using Newtonsoft.Json;

namespace DataSourceLayer.Gateway
{
    public class OCR_API_TDG : IOCR_API_TDG
    {
        private readonly IOCR_Adapter _adapter;

        public OCR_API_TDG(IOCR_Adapter adapter)
        {
            _adapter = adapter;
        }

        public async Task<string> DetectText(string base64EncodedImage)
        {
            // Remember to change to Your Own Google Vision API credentials
            var serviceAccountPath = "C:\\Users\\CPZ\\Documents\\tidal-anvil-230402-dfe950b3753e.json";

            // Authenticate with the service account
            var credential = GoogleCredential.FromFile(serviceAccountPath)
                .CreateScoped("https://www.googleapis.com/auth/cloud-vision");

            // Obtain an access token
            var token = await (credential as ITokenAccess).GetAccessTokenForRequestAsync();

            // Prepare the request
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var content = _adapter.ConvertToJSON(base64EncodedImage);

            // Make the POST request to the Vision API
            var response = await httpClient.PostAsync("https://vision.googleapis.com/v1/images:annotate", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            var textDetected = _adapter.ConvertFromJSON(responseContent);
            return textDetected;
        }
    }
}