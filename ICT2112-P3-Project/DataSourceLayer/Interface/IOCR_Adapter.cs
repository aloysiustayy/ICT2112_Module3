using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSourceLayer.Interface
{
    public interface IOCR_Adapter
    {
        HttpContent ConvertToJSON(string base64EncodedImage);
        string ConvertFromJSON(string jsonResponse);
    }
}
