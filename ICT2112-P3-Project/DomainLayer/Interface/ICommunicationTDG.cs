using DomainLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Interface
{
    public interface ICommunicationTDG
    {
        //<Photo> in place of <CommsPlatformChat_SDM>
        public List<Photo> CreateChat();

        public List<Photo> InsertChat();

        public List<Photo> UpdateChat();

        public List<Photo> DeleteChat();
    }
}
