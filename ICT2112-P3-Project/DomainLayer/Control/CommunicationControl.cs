using DomainLayer.Entity;
using DomainLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Control
{
    public class CommunicationControl
    {
        private readonly ICommunicationTDG _communicationDbContext;

        public CommunicationControl(ICommunicationTDG communicationDbContext)
        {
            _communicationDbContext = communicationDbContext;
        }

        public void CreateChat()
        {

        }
        public void RetrieveChat()
        {

        }

        public void DeleteChat()
        {

        }

        public void CreateZoomMeeting()
        {

        }

        public void RetrieveZoomMeeting()
        {

        }

        public void AddMessages()
        {

        }
    }
}
