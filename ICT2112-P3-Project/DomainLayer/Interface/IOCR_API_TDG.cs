using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface IOCR_API_TDG
    {
        public Task<string> DetectText(string base64EncodedImage);
    }
}
