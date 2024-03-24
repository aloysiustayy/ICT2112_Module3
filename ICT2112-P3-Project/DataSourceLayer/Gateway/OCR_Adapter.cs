using DataSourceLayer.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceLayer.Gateway
{
    public class OCR_Adapter : IOCR_Adapter
    {
        public HttpContent ConvertToJSON(string base64EncodedImage)
        {
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
            return content;
        }

        public string ConvertFromJSON(string jsonResponse)
        {
            try
            {
                var responseObject = JsonConvert.DeserializeObject<dynamic>(jsonResponse);
                var text = (string)responseObject.responses[0].fullTextAnnotation.text;
                return text;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while parsing JSON response: {ex.Message}");
                return null;
            }
        }
    }
}
