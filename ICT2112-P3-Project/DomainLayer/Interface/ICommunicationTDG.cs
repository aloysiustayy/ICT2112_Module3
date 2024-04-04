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

        public void InsertZoomLink(CommsPlatformChat_SDM chatId);

        public void CreateZoomMeeting(CommsPlatformChat_SDM meeting);
    }
}
