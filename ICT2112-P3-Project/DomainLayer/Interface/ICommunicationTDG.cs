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
        public void CreateChat(CommsPlatformChat_SDM chatId);

        public CommsPlatformChat_SDM ReadChat(CommsPlatformChat_SDM chatId);

        public void UpdateChat(CommsPlatformChat_SDM chatId);

        public void DeleteChat(CommsPlatformChat_SDM chatId);

        public void InsertZoomLink(CommsPlatformChat_SDM chatId);
    }
}
